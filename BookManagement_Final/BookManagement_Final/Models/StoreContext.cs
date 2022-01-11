
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore_project.Models
{
    
    
        public class StoreContext : DbContext
        {
            public StoreContext (DbContextOptions options)
                : base(options)
            {

            }

            public DbSet<Admin> Admins { get; set; }
            public DbSet<User> users { get; set; }
            public DbSet<Bookstore> bookstores { get; set; }
            public DbSet<categoryviewmodel> Category { get; set; }
            


        }
    }

