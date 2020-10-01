using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Services;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
