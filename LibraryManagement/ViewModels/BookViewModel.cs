using LibraryManagement.Models;
using System.Collections.Generic;

namespace LibraryManagement.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Auther> Authers { get; set; }

    }
}
