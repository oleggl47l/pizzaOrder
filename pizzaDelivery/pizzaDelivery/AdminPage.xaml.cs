using System;
using System.Collections.Generic;
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
    public partial class AdminPage : Window {
        public AdminPage() {
            InitializeComponent();
            contentFrame.Navigate(new AdminUsersPage());
        }

        private void Button_Users_Click(object sender, RoutedEventArgs e) {
            contentFrame.Navigate(new AdminUsersPage());
        }

        private void Button_Orders_Click(object sender, RoutedEventArgs e) {
            contentFrame.Navigate(new AdminOrdersPage());
        }

        private void Button_Pizzas_Click(object sender, RoutedEventArgs e) {
            contentFrame.Navigate(new AdminPizzasPage());
        }

        private void btnBackToAuth_Click(object sender, RoutedEventArgs e) {
            AuthWindow authWindow = new AuthWindow();   
            authWindow.Show();
            Close();
        }
    }
}
