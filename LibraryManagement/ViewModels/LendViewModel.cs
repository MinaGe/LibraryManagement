
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    public class LendViewModel
    {
        public Book book { get; set; }
        public IEnumerable<Customer> customers { get; set; }
    }
}
