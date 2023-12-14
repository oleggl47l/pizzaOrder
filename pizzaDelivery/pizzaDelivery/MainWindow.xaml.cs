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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pizzaDelivery {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        ApplicationContext db;

        public MainWindow() {
            InitializeComponent();

            db = new ApplicationContext();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e) {
            string fName = textBoxFName.Text.Trim();
            string lName = textBoxLName.Text.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();
            string phoneNum = textBoxPhoneNum.Text.Trim();
            string address = textBoxAddress.Text.Trim();
            string password = passwordBox.Password.Trim();
            string password_2 = passwordBox_2.Password.Trim();

            if (fName.Length < 2 || fName.Length > 30) {
                textBoxFName.ToolTip = "Длина имени должна быть не менее 2 и не более 30 символов.";
                textBoxFName.Background = Brushes.PaleVioletRed;
            }
            else {
                textBoxFName.ToolTip = "";
                textBoxFName.Background = Brushes.Transparent;
            }

            if (lName.Length < 2 || lName.Length > 30) {
                textBoxLName.ToolTip = "Длина фамилии должна быть не менее 2 и не более 30 символов.";
                textBoxLName.Background = Brushes.PaleVioletRed;
            }
            else {
                textBoxLName.ToolTip = "";
                textBoxLName.Background = Brushes.Transparent;
            }

            if (email.Length < 5 || email.Length > 50 || !email.Contains("@") || !email.Contains(".")) {
                textBoxEmail.ToolTip = "Email введен некорректно.";
                textBoxEmail.Background = Brushes.PaleVioletRed;
            }
            else {
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;
            }

            if (phoneNum.Length < 11 || phoneNum.Length > 16) {
                textBoxPhoneNum.ToolTip = "Номер телефона введен некорректно.";
                textBoxPhoneNum.Background = Brushes.PaleVioletRed;
            }
            else {
                textBoxPhoneNum.ToolTip = "";
                textBoxPhoneNum.Background = Brushes.Transparent;
            }

            if (address.Length < 5 || address.Length > 80) {
                textBoxAddress.ToolTip = "Адрес введен некорректно.";
                textBoxAddress.Background = Brushes.PaleVioletRed;
            }
            else {
                textBoxAddress.ToolTip = "";
                textBoxAddress.Background = Brushes.Transparent;
            }

            if (password.Length < 8 || password.Length > 50) {
                passwordBox.ToolTip = "Длина пароля должна быть не менее 8 и не более 50 символов.";
                passwordBox.Background = Brushes.PaleVioletRed;
            }
            else {
                passwordBox.ToolTip = "";
                passwordBox.Background = Brushes.Transparent;
            }

            if (password_2 != password) {
                passwordBox_2.ToolTip = "Пароли не совпадают.";
                passwordBox_2.Background = Brushes.PaleVioletRed;
            }
            else {
                passwordBox_2.ToolTip = "";
                passwordBox_2.Background = Brushes.Transparent;
            }

            if (fName.Length >= 2 && fName.Length <= 30
                && lName.Length >= 2 && lName.Length <= 30
                && email.Length >= 5 && email.Length <= 50 && email.Contains("@") && email.Contains(".")
                && phoneNum.Length >= 11 && phoneNum.Length <= 16
                && address.Length >= 5 && address.Length <= 80
                && password.Length >= 8 && password.Length <= 50
                && password_2 == password) {
                User user = new User(fName, lName, address, email, phoneNum, password);
                db.Users.Add(user);
                db.SaveChanges();

                PizzasWindow pizzasWindow = new PizzasWindow(user);
                pizzasWindow.Show();
                Close();

                MessageBox.Show("Succeed");
            }
        }


        private void Button_AuthWin_Click(object sender, RoutedEventArgs e) {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }
    }
}
