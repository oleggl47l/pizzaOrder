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
    public partial class AdminPizzasPage : Page {

        private List<Pizza> pizzas;

        public AdminPizzasPage() {
            InitializeComponent();
            LoadPizzas();
        }

        private void LoadPizzas() {
            using (ApplicationContext db = new ApplicationContext()) {
                pizzas = db.Pizzas.ToList();
                datagridPizzas.ItemsSource = pizzas;
            }
        }

        private void Button_DeletePizzas_Click(object sender, RoutedEventArgs e) {
            List<Pizza> selectedPizzas = datagridPizzas.SelectedItems.Cast<Pizza>().ToList();

            var confirmationWindow = new ConfirmationYesNo();
            var result = confirmationWindow.ShowDialog();

            if (result == true) {
                using (ApplicationContext db = new ApplicationContext()) {
                    foreach (Pizza pizza in selectedPizzas) {
                        Pizza pizzasToDelete = db.Pizzas.FirstOrDefault(p => p.id == pizza.id);
                        if (pizzasToDelete != null) {
                            db.Pizzas.Remove(pizzasToDelete);
                        }
                    }
                    db.SaveChanges();
                }

                LoadPizzas();
            }
        }
    }
}
