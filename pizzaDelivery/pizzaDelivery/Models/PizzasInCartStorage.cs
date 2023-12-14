using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzaDelivery {
    internal class PizzasInCartStorage {
        public static ObservableCollection<Pizza> PizzasInCart { get; } = new ObservableCollection<Pizza>();

    }
}
