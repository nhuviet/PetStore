using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pet_Store_BE.Models;

namespace Pet_Store_BE.Data
{
    public class Pet_Store_BEContext : DbContext
    {
        public Pet_Store_BEContext (DbContextOptions<Pet_Store_BEContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pet { get; set; }

        public DbSet<Pet_Store_BE.Models.Customer> Customer { get; set; }

        public DbSet<Pet_Store_BE.Models.Product> Product { get; set; }
    }
}
