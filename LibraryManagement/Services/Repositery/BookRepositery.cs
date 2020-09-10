using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Repositery
{
    public class BookRepositery : Repositery<Book>, IBookRepositery
    {
        public BookRepositery(LibraryDbContext context):base(context)
        {

        }
        public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate)
        {
            return context.Books
                 .Include(a => a.Auther)
                 .Where(predicate);
        }

        public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate)
        {
            return context.Books
                   .Include(a => a.Auther)
                   .Include(a => a.Customer)
                   .Where(predicate);
        }

        public IEnumerable<Book> GetAllWithAuthor()
        {
            return context.Books.Include(a => a.Auther);
        }
    }
}
