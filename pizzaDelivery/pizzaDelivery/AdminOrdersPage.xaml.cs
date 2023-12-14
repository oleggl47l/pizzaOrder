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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pizzaDelivery {
    /// <summary>
    /// Interaction logic for AdminOrdersPage.xaml
    /// </summary>
    public partial class AdminOrdersPage : Page {

        private List<Order> orders;

        public AdminOrdersPage() {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers() {
            using (ApplicationContext db = new ApplicationContext()) {
                orders = db.Orders.ToList();
                datagridOrders.ItemsSource = orders;
            }
        }

        private void btnDeleteOrders_Click(object sender, RoutedEventArgs e) {
            List<Order> selectedOrders= datagridOrders.SelectedItems.Cast<Order>().ToList();

            var confirmationWindow = new ConfirmationYesNo();
            var result = confirmationWindow.ShowDialog();

            if (result == true) {
                using (ApplicationContext db = new ApplicationContext()) {
                    foreach (Order order in selectedOrders) {
                        Order orderToDelete = db.Orders.FirstOrDefault(o => o.id == order.id);
                        if (orderToDelete != null) {
                            db.Orders.Remove(orderToDelete);
                        }
                    }
                    db.SaveChanges();
                }

                LoadUsers();
            }
        }
    }
}
