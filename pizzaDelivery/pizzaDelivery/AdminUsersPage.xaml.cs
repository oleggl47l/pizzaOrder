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
    public partial class AdminUsersPage : Page {
        private List<User> users;

        public AdminUsersPage() {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers() {
            using (ApplicationContext db = new ApplicationContext()) {
                users = db.Users.ToList();
                datagridUsers.ItemsSource = users;
            }
        }

        private void Button_DeleteUsers_Click(object sender, RoutedEventArgs e) {
            List<User> selectedUsers = datagridUsers.SelectedItems.Cast<User>().ToList();

            var confirmationWindow = new ConfirmationYesNo();
            var result = confirmationWindow.ShowDialog();

            if (result == true) {
                using (ApplicationContext db = new ApplicationContext()) {
                    foreach (User user in selectedUsers) {
                        User userToDelete = db.Users.FirstOrDefault(u => u.id == user.id);
                        if (userToDelete != null) {
                            db.Users.Remove(userToDelete);
                        }
                    }
                    db.SaveChanges();
                }

                LoadUsers();
            }
        }

    }
}
