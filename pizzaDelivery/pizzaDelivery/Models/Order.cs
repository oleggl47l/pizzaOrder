using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzaDelivery {
    internal class Order {
        public int id { get; set; }
        public int UserId { get; set; }
        public string PizzasById { get; set; } 
        public decimal Total { get; set; } 

        // Navigation properties
        public virtual User User { get; set; }
    }
}
