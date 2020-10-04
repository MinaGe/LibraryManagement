using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryManagement.Models;
using LibraryManagement.Services;
using LibraryManagement.Services.Repositery;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepositery _bookRepository;
        private readonly IAutherReositery _authorRepository;
        private readonly ICuntomerRepositery _customerRepository;

        public HomeController(IBookRepositery bookRepository,
                              IAutherReositery authorRepository,
                              ICuntomerRepositery  customerRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            // create home view model
            var homeVM = new HomeViewModel()
            {
                AuthorCount = _authorRepository.Count(x => true),
                CustomerCount = _customerRepository.Count(x => true),
                BookCount = _bookRepository.Count(x => true),
                LendBookCount = _bookRepository.Count(x => x.Customer != null)
            };
            // call view
            return View(homeVM);
        }
    }
}
