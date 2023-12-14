using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pizzaDelivery {
    public partial class PizzasWindow : Window {

        private User loggedInUser;
        private ObservableCollection<Pizza> pizzasInCart;
        private OrderWindow orderWindow;

        internal PizzasWindow(User loggedInUser) {
            InitializeComponent();
            LoadPizzas();
            this.loggedInUser = loggedInUser;
            pizzasInCart = PizzasInCartStorage.PizzasInCart; 

        }

        private void LoadPizzas() {
            List<Pizza> pizzas;
            using (ApplicationContext db = new ApplicationContext()) {
                pizzas = db.Pizzas.ToList();
            }

            pizzasItemsControl.ItemsSource = pizzas;
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e) {
            Pizza selectedPizza = (Pizza)((Button)sender).DataContext;
            pizzasInCart.Add(selectedPizza);
            
        }

        private void btnToCart_Click(object sender, RoutedEventArgs e) {
            if (orderWindow == null || !orderWindow.IsVisible) {
                orderWindow = new OrderWindow(pizzasInCart, loggedInUser);
                orderWindow.Show();
            }
            else 
                orderWindow.Activate();
        }

        private void btnToProfile_Click(object sender, RoutedEventArgs e) {
            UserPageWindow userPageWindow = new UserPageWindow(loggedInUser);
            userPageWindow.Show();
            Close();
        }
    }
}
