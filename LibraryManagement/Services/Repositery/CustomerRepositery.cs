using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Repositery
{
    public class CustomerRepositery : Repositery<Customer>, ICuntomerRepositery
    {
        public CustomerRepositery(LibraryDbContext context):base(context)
        {

        }
    }
}
