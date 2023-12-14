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
    public partial class AuthWindow : Window {

        public AuthWindow() {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e) {
            string email = textBoxEmail.Text.Trim().ToLower();
            string password = passwordBox.Password.Trim();


            if (email.Length < 5 || email.Length > 50 || !email.Contains("@") || !email.Contains(".")) {
                textBoxEmail.ToolTip = "Email введен некорректно.";
                textBoxEmail.Background = Brushes.PaleVioletRed;
            }
            else if (password.Length < 8 || password.Length > 50) {
                passwordBox.ToolTip = "Длина пароля должна быть не менее 8 и не более 50 символов.";
                passwordBox.Background = Brushes.PaleVioletRed;
            }

            else {
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;
                passwordBox.ToolTip = "";
                passwordBox.Background = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContext db = new ApplicationContext()) {
                    authUser = db.Users.Where(b => b.Email == email && b.Password == password).FirstOrDefault();
                }

                if (authUser != null) {

                    if (authUser.Email == "admin@gmail.com") {
                        AdminPage adminPage = new AdminPage();
                        adminPage.Show();
                    }
                    else {
                        PizzasWindow pizzasWindow = new PizzasWindow(authUser);
                        pizzasWindow.Show();
                    }
                    Close();
                }

                else
                    MessageBox.Show("Введен неверно логин или пароль.");
            }
        }

        private void Button_MainWin_Click(object sender, RoutedEventArgs e) {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

    }
}
