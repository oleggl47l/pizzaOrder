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
    /// Interaction logic for ConfirmationYesNo.xaml
    /// </summary>
    public partial class ConfirmationYesNo : Window {
        public ConfirmationYesNo() {
            InitializeComponent();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e) {
            DialogResult = true;
        }

        private void btnNo_Click(object sender, RoutedEventArgs e) {
            DialogResult = false;
        }
    }
}
