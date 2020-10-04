using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class Return : Controller
    {
        private readonly IBookRepositery bookRepositery;
        private readonly ICuntomerRepositery cuntomerRepositery;

        public Return(IBookRepositery bookRepositery, ICuntomerRepositery cuntomerRepositery)
        {
            this.bookRepositery = bookRepositery;
            this.cuntomerRepositery = cuntomerRepositery;
        }


        [Route("Return")]
        public IActionResult List()
        {
            // load all borrowed books
            var borrowedBooks = bookRepositery.FindWithAuthorAndBorrower(x => x.CustomerId != 0);
            // Check the books collection
            if (borrowedBooks == null || borrowedBooks.ToList().Count() == 0)
            {
                return View("Empty");
            }
            return View(borrowedBooks);
        }


        public IActionResult ReturnABook(int bookId)
        {
            // load the current book
            var book = bookRepositery.GetById(bookId);
            // remove borrower
            book.Customer = null;

            book.CustomerId = 0;
            // update database
            bookRepositery.Update(book);
            // redirect to list method
            return RedirectToAction("List");
        }
    }
}
