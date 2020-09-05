using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Auther
    {
        public int AutherId { get; set; }
        public string  Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
