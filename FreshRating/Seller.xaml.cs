using Microsoft.Win32;
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

namespace FreshRating
{
    /// <summary>
    /// Логика взаимодействия для Bayer.xaml
    /// </summary>
    public partial class Seller : Window
    {
        public Seller()
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

        

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            LK.Visibility = Visibility.Hidden;
            INFO.Visibility = Visibility.Visible;

        }

        private void ListViewItem_Selected_LK_Menu(object sender, RoutedEventArgs e)
        {
           
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            LK.Visibility = Visibility.Hidden;
            INFO.Visibility = Visibility.Visible;
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            LK.Visibility = Visibility.Visible;
            INFO.Visibility = Visibility.Hidden;
        }
        int sum_ob = 0;
        int sum_pers = 0; 
        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Da = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Выберите файлы",
                InitialDirectory = @"C:\",
            };
            Da.Filter = "Изображения (*.BMP, *.JPG, *.GIF, *.TIF, *.JPEG, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.jpeg; *.png; *.ico; *.emf; *.wmf";


            if (Da.ShowDialog() == true)
            {

               MessageBox.Show("Документ успешно добавлен в базу " + Environment.NewLine + $"Кол - во добавленных объектов = {Da.FileNames.Length}");
                sum_ob += Da.FileNames.Length;
                label_Copy6.Content = sum_ob;
            }


        }

        private void button_Pers(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Da = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Выберите файлы",
                InitialDirectory = @"C:\",
            };
            Da.Filter = "Изображения (*.BMP, *.JPG, *.GIF, *.TIF, *.JPEG, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.jpeg; *.png; *.ico; *.emf; *.wmf";


            if (Da.ShowDialog() == true)
            {

                MessageBox.Show("Документ успешно добавлен в базу " + Environment.NewLine + $"Кол - во добавленных объектов = {Da.FileNames.Length}");
                sum_pers += Da.FileNames.Length;
                label_Copy8.Content = sum_pers;
            }
        }

        private void Ustav(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Da = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Выберите файлы",
                InitialDirectory = @"C:\"
            };
            Da.Filter = "Изображения (*.BMP, *.JPG, *.GIF, *.TIF, *.JPEG, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.jpeg; *.png; *.ico; *.emf; *.wmf";

            if (Da.ShowDialog() == true)
            {
                MessageBox.Show("Документ успешно добавлен в базу");
                label_Copy9.Content = "Устав добавлен";
                button_Copy3.Content = "Обновить";
            }
        }

        private void Arenda(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Документ успешно добавлен в базу");
            label_Copy10.Content = "Договор аренды добавлен";
            button_Copy4.Content = "Обновить";
        }
    }
}
