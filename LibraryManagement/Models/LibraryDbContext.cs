using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext()
        {

        }
        public LibraryDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Auther> Authers { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
