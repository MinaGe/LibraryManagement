using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Repositery
{
    public class AutherRepositery : Repositery<Models.Auther>, IAutherReositery
    {
        public AutherRepositery(LibraryDbContext context):base(context)
        {

        }
      
        public IEnumerable<Models.Auther> GetAllWithBooks()
        {
            return context.Authers.Include(a => a.Books);
        }

        public Models.Auther GetWithBooks(int id)
        {
            return context.Authers.Where(a => a.AutherId == id).Include(a => a.Books).FirstOrDefault();
        }

        public void Update(Controllers.Auther author)
        {
            throw new NotImplementedException();
        }
    }
}
