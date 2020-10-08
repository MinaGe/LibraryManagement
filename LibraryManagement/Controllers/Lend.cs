using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Services;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class Lend : Controller
    {
        private readonly IBookRepositery bookRepositery;
        private readonly ICuntomerRepositery customerRepositery;

        public Lend(IBookRepositery bookRepositery, ICuntomerRepositery customerRepositery)
        {
            this.bookRepositery = bookRepositery;
            this.customerRepositery = customerRepositery;
        }
        [Route("Lend")]
        public IActionResult List()
        {
            var availablebooks = bookRepositery.FindWithAuthor(x => x.CustomerId == null);
            if (availablebooks.Count()==0)
            {
                return View("Empty");
            }
            else
            {
                return View(availablebooks);
            }
        }
        public IActionResult LendBook(int bookId)
        {
            var Lendvm = new LendViewModel()
            {
                book = bookRepositery.GetById(bookId), customers = customerRepositery.GetAll() 
            };
            return View(Lendvm);
        }
        [HttpPost]
        public IActionResult LendBook(LendViewModel lendViewModel)
        {
            var book = bookRepositery.GetById(lendViewModel.book.BookId);
            var customer = customerRepositery.GetById((int)lendViewModel.book.CustomerId);
            book.Customer = customer;
            bookRepositery.Update(book);
            return RedirectToAction("List");


        }
       
    }
}
