using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Services;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class Book : Controller
    {
        private readonly IBookRepositery bookRepositery;
        private readonly IAutherReositery autherReositery;

        public Book(IBookRepositery bookRepositery,IAutherReositery autherReositery)
        {
            this.bookRepositery = bookRepositery;
            this.autherReositery = autherReositery;
        }
        public IActionResult List(int? authorId, int? borrowerId)
        {
            if (authorId == null && borrowerId == null)
            {
                // show all books
                var books = bookRepositery.GetAllWithAuthor();
                // check books
                return CheckBooks((IEnumerable<Book>)books);
            }
            else if (authorId != null)
            {
                // filter by author id
                var author = autherReositery
                    .GetWithBooks((int)authorId);

                // check author books
                if (author.Books.Count() == 0)
                {
                    return View("EmptyAuther", author);
                }
                else
                {
                    return View(author.Books);
                }
            }
            else if (borrowerId != null)
            {
                // filter by borrower id
                var books = bookRepositery
                    .FindWithAuthorAndBorrower(book => book.CustomerId == borrowerId);
                // check borrower books
                return CheckBooks((IEnumerable<Book>)books);
            }
            else
            {
                // throw exception
                throw new ArgumentException();
            }
        }

   

        public IActionResult CheckBooks(IEnumerable<Book> books)
        {
            if (books.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(books);
            }
        }
        public IActionResult Create()
        {
            var bookVM = new BookViewModel()
            {
                Authers = autherReositery.GetAll()
            };
            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Create(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                bookViewModel.Authers = autherReositery.GetAll();
                return View(bookViewModel);
            }

            bookRepositery.Create(bookViewModel.Book);

            return RedirectToAction("List");
        }
        public IActionResult Update (int BookId)
        {
            var bookvm = new BookViewModel()
            { Book = bookRepositery.GetById(BookId), Authers = autherReositery.GetAll() };
            return View(bookvm);
          
        }
        [HttpPost]
        public IActionResult Update(BookViewModel bookViewModel)
        {
            if(!ModelState.IsValid)
            {
                bookViewModel.Authers = autherReositery.GetAll();
                return View(bookViewModel);
            }
            bookRepositery.Update(bookViewModel.Book);
            return RedirectToAction("List");

        }
        public IActionResult Delete(int Bookid)
        {

            var book = bookRepositery.GetById(Bookid);
            bookRepositery.Delete(book);
            return RedirectToAction("List");
        }
    }
}
