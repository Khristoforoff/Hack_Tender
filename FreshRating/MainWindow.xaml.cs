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
using System.Text.RegularExpressions;


namespace FreshRating
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Самое начало
        /// </summary>
        public MainWindow()
        {

        }
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void BuyerClick(object sender, RoutedEventArgs e)
        {
            Window buyer = new Buyer();
            buyer.Show();
        }
        private void SellerClick(object sender, RoutedEventArgs e)
        {
            Window seller = new Seller();
            seller.Show();
        }
    }
}
