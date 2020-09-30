using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
using LibraryManagement.Services;
using LibraryManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICuntomerRepositery cuntomerRepositery;
        private readonly IBookRepositery bookRepositery;

        public CustomerController(ICuntomerRepositery cuntomerRepositery, IBookRepositery bookRepositery)
        {
            this.cuntomerRepositery = cuntomerRepositery;
            this.bookRepositery = bookRepositery;
        }

        [Route("Customer")]
        public IActionResult List()
        {
            var customervm = new List<CustoerViewModel>();
            var Customer = cuntomerRepositery.GetAll();
            if (Customer.Count() == 0)
            {
                return View("Empty");
            }
            foreach (var customer in Customer)
            {
                customervm.Add(new CustoerViewModel { Customer = customer, BookCount = bookRepositery.Count(x => x.CustomerId == customer.CustomerId) });
            }
            return View(customervm);

        }
        public IActionResult Delete(int id)

        {
            var customer = cuntomerRepositery.GetById(id);
            cuntomerRepositery.Delete(customer);
            return RedirectToAction("List");

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (Customer customer )
        {
            cuntomerRepositery.Create(customer);
            return RedirectToAction("List");
        }
        public IActionResult Update(int id )
        {
            var customer = cuntomerRepositery.GetById(id);
            return View(customer);

        }
        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            cuntomerRepositery.Update(customer);
            return RedirectToAction("List");
        }
    }
}