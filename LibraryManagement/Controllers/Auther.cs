using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Services;
using LibraryManagement.Services.Repositery;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class Auther : Controller
    {
        private readonly IAutherReositery _Autherrepositery;

        public Auther(IAutherReositery autherRepositery)
        {
            _Autherrepositery = autherRepositery;
        }
        public IActionResult List()
        {
            var auther = _Autherrepositery.GetAllWithBooks();
            if (auther.Count() == 0) return View("empty");
            return View(auther);
        }
        public IActionResult Update(int id)
        {
            var author = _Autherrepositery.GetById(id);

            if (author == null) return NotFound();

            return View(author);
        }

        [HttpPost]
        public IActionResult Update(Auther author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }

            _Autherrepositery.Update(author);

            return RedirectToAction("List");
        }

        public IActionResult Create()
        {
            var viewModel = new CreateAuthorViewModel
            { Referer = Request.Headers["Referer"].ToString() };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateAuthorViewModel authorVM)
        {
            if (!ModelState.IsValid)
            {
                return View(authorVM);
            }

            _authorRepository.Create(authorVM.Author);

            if (!String.IsNullOrEmpty(authorVM.Referer))
            {
                return Redirect(authorVM.Referer);
            }

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var author = _authorRepository.GetById(id);

            _authorRepository.Delete(author);

            return RedirectToAction("List");
        }
    }
}
