using LibraryManagement.Models;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAllWithAuthor()
        {
            throw new NotImplementedException();
        }
    }
}
