using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public interface IAutherReositery:IRepositery<Models.Auther>
    {
        IEnumerable<Models.Auther> GetAllWithBooks();
        Models.Auther GetWithBooks(int id);
        void Update(Controllers.Auther author);
    }
}
