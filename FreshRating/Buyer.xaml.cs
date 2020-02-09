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
using FreshRating;

namespace FreshRating
{
    /// <summary>
    /// Логика взаимодействия для Bayer.xaml
    /// </summary>
    ///
    public partial class Buyer : Window
    {
        public Buyer()
        {
            InitializeComponent();
            
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Window main = new MainWindow();
            main.Show();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //GridBuyer.Items.Add(contractorType,);
        }
    }






    public class Buyerr
    {
        public string Typ { get; set; }
        public string Names { get; set; }
        public string selectedEntity { get; set; }
        public string entityNumber { get; set; }
        public string taskName { get; set; }
        public string categoryName { get; set; }
    }
}