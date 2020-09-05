using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }

        public virtual Auther Auther { get; set; }
        public int AutherId { get; set; }

        public virtual Customer Customer { get; set;  }
        public int CustomerId { get; set; }
    }
}
