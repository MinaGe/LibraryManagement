using LibraryManagement.Models;
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
        public int Count(Func<Auther, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(Auther entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Auther entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auther> Find(Func<Auther, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auther> GetAllWithBooks()
        {
            throw new NotImplementedException();
        }

        public Auther GetWithBooks(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Auther entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Auther> IRepositery<Auther>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Auther> IAutherReositery.GetAllWithBooks()
        {
            throw new NotImplementedException();
        }

        Auther IRepositery<Auther>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Auther IAutherReositery.GetWithBooks(int id)
        {
            throw new NotImplementedException();
        }
    }
}
