using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzaDelivery {
    internal class ApplicationContext : DbContext {
        public DbSet<User> Users { get; set; } 
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationContext() : base("DefaultConnection") {

        }
    }
}
