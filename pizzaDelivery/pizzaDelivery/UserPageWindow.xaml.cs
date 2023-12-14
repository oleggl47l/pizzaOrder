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
    public partial class UserPageWindow : Window {
        //public UserPageWindow() {
        //    InitializeComponent();

        //    ApplicationContext db = new ApplicationContext();
        //    List<User> users = db.Users.ToList();

        //    listOfUsers.ItemsSource = users;
        //}

        private User loggedInUser;

        internal UserPageWindow(User user) {
            InitializeComponent();

            loggedInUser = user;


            // Populate UI elements with user information
            DisplayUserInfo();
        }

        private void DisplayUserInfo() {
            
            txtFirstName.Text = loggedInUser.FirstName;
            txtLastName.Text = loggedInUser.LastName;
            txtAddress.Text = loggedInUser.Address;
            txtEmail.Text = loggedInUser.Email;
            txtPhoneNum.Text = loggedInUser.PhoneNum;
        }

        private void Button_EditMyInfo_Click(object sender, RoutedEventArgs e) {
            txtFirstName.IsReadOnly = false;
            txtLastName.IsReadOnly = false;
            txtAddress.IsReadOnly = false;
            txtEmail.IsReadOnly = false;
            txtPhoneNum.IsReadOnly = false;

           
            btnSaveMyInfo.Style = (Style)FindResource("MaterialDesignFlatMidBgButton");
        }

        private void Button_SaveMyInfo_Click(object sender, RoutedEventArgs e) {
            txtFirstName.IsReadOnly = true;
            txtLastName.IsReadOnly = true;
            txtAddress.IsReadOnly = true;
            txtEmail.IsReadOnly = true;
            txtPhoneNum.IsReadOnly = true;

            btnSaveMyInfo.Style = (Style)FindResource("MaterialDesignFlatButton");

            loggedInUser.FirstName = txtFirstName.Text;
            loggedInUser.LastName = txtLastName.Text;
            loggedInUser.Address = txtAddress.Text;
            loggedInUser.Email = txtEmail.Text;
            loggedInUser.PhoneNum = txtPhoneNum.Text;

            using (ApplicationContext db = new ApplicationContext()) {
                User userInDb = db.Users.FirstOrDefault(u => u.id == loggedInUser.id);

                if (userInDb != null) {
                    userInDb.FirstName = loggedInUser.FirstName;
                    userInDb.LastName = loggedInUser.LastName;
                    userInDb.Address = loggedInUser.Address;
                    userInDb.Email = loggedInUser.Email;
                    userInDb.PhoneNum = loggedInUser.PhoneNum;

                    db.SaveChanges();
                }
            }
        }

        private void btnBackToPizzas_Click(object sender, RoutedEventArgs e) {
            PizzasWindow pizzasWindow = new PizzasWindow(loggedInUser);
            pizzasWindow.Show();
            Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e) {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Close();
        }
    }
}
