using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public interface IAutherReositery:IRepositery<Auther>
    {
        IEnumerable<Auther> GetAllWithBooks();
        Auther GetWithBooks(int id);
    }
}
