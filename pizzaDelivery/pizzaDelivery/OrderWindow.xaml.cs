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
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window {
        private ObservableCollection<Pizza> pizzasInCart;
        private decimal totalPrice;
        private User loggedInUser;
        public OrderWindow(ObservableCollection<Pizza> pizzasInCart, User loggedInUser) {
            InitializeComponent();
            this.pizzasInCart = PizzasInCartStorage.PizzasInCart;
            this.loggedInUser = loggedInUser;
            UpdateTotalPrice();
            LoadCart();
        }
        private void LoadCart() {
            cartItemsControl.ItemsSource = pizzasInCart;
        }

        internal void UpdateTotalPrice() {
            totalPrice = pizzasInCart.Sum(pizza => pizza.Price);

            totalPriceTextBlock.Text = $"Общая сумма: {totalPrice} руб.";
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e) {
            if (pizzasInCart.Count == 0) {
                MessageBox.Show("Корзина пуста. Добавьте пиццы перед подтверждением заказа.");
                return;
            }

            var confirmationWindow = new ConfirmationYesNo();
            var result = confirmationWindow.ShowDialog();

            if (result == true) {
                Order newOrder = new Order {
                    UserId = loggedInUser.id,
                    Total = totalPrice,
                    PizzasById = string.Join(",", pizzasInCart.Select(pizza => pizza.id.ToString())),
                };

                using (ApplicationContext db = new ApplicationContext()) {
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                }

                pizzasInCart.Clear();
                UpdateTotalPrice();

                MessageBox.Show($"Заказ успешно оформлен. Номер заказа: {newOrder.id}");
            }
        }


        private void btnDelFromCart_Click(object sender, RoutedEventArgs e) {
            Pizza selectedPizza = ((Button)sender).DataContext as Pizza;
            pizzasInCart.Remove(selectedPizza);
            UpdateTotalPrice();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e) {
            LoadCart();
            UpdateTotalPrice();
        }
    }
}
