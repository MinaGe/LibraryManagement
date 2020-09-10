using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Repositery
{
    public class AutherRepositery : Repositery<Auther>, IAutherReositery
    {
        public AutherRepositery(LibraryDbContext context):base(context)
        {

        }
      
        public IEnumerable<Auther> GetAllWithBooks()
        {
            return context.Authers.Include(a => a.Books);
        }

        public Auther GetWithBooks(int id)
        {
            return context.Authers.Where(a => a.AutherId == id).Include(a => a.Books).FirstOrDefault();
        }

       

      

       
    }
}
