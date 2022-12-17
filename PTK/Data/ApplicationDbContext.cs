using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PTK.Models;

namespace PTK.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PTK.Models.Pizza> Pizza { get; set; }

        public DbSet<PTK.Models.Chef> Chef { get; set; }

        public DbSet<PTK.Models.Menu> Menu { get; set; }

      
        public DbSet<PTK.Models.ChefofPizza> ChefofPizza { get; set; }
       // public object PizzaChef { get; internal set; }
    }
}
