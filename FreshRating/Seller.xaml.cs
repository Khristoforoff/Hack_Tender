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
        private System.Data.DataSet dataSet;

        static string[] entityNames1 = { "Жил", "Инфра", "Юг", "Север", "Теле", "Бизнес", "Электро", "Восток", "Запад", "Бел", "Мех", "Энерго", "А-", "Б-", "В-", "М-", "Норд", "Пресс", "Порт", "Вест", "Ост", "Газ", "Инж", "Пож", "Мор", "Сель", "ТД ", "Арм", "Информ", "Регион", "Байт", "НТЦ-", "ОМФ-", "Радио", "Альянс", "Гидро", "Тепло", "Металл", "БМ-" };
        static string[] entityNames2 = { "Строй", "Линк", "Контакт", "Скан", "Быт", "Групп", "Софт", "План", "Сервис", "Тех", "Снаб", "Техника", "Систем", "Система", "Ресурс", "Терра", "Экспресс", "Системс", "Автоматика", "Класс", "Канал", "Комплект", "Стандарт", "Премьер", "Град", "Проджектс", "Арсенал", "Маркет", "Форм", "Пром", "Контроль", "Инжиниринг" };
        static string[] physNames = new string[] { "Александр", "Максим", "Дмитрий", "Кирилл", "Никита", "Михаил", "Егор", "Матвей", "Андрей", "Илья", "Алексей", "Роман", "Сергей", "Владислав", "Ярослав", "Тимофей", "Денис", "Владимир", "Павел", "Глеб", "Константин", "Богдан", "Евгений", "Николай", "Степан", "Тимур", "Марк", "Семён", "Фёдор", "Георгий", "Антон", "Вадим", "Игорь", "Григорий", "Виктор", "Станислав", "Олег", "Пётр", "Юрий", "Виталий", "Василий", "Всеволод", "Марат" };
        static string[] physSurnames = new string[] { "Сергеев", "Иванов", "Константинов", "Петров", "Смирнов", "Кузнецов", "Попов", "Васильев", "Петров", "Соколов", "Михайлов", "Новиков", "Федоров", "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов", "Егоров", "Павлов", "Козлов", "Степанов", "Николаев", "Орлов", "Андреев", "Макаров", "Никитин", "Захаров", "Зайцев", "Соловьев", "Борисов", "Яковлев", "Григорьев", "Романов", "Воробьев", "Сергеев", "Кузьмин", "Фролов", "Александров" };
        static string[] physPatNames = new string[] { "Александрович", "Максимович", "Дмитриевич", "Кириллович", "Никитич", "Михайлович", "Егорович", "Матвеевич", "Андреевич", "Ильич", "Алексеевич", "Романович", "Сергеевич", "Владиславович", "Ярославович", "Тимофеевич", "Денисович", "Владимирович", "Павлович", "Глебович", "Константинович", "Богданович", "Евгеньевич", "Николаевич", "Степанович", "Тимурович", "Маркович", "Семёнович", "Фёдорович", "Георгиевич", "Антонович", "Вадимович", "Игоревич", "Григорьевич", "Викторович", "Станиславович", "Олегович", "Петрович", "Юрьевич", "Витальевич", "Васильевич", "Всеволодович", "Маратович" };
        static string[,] tasks = new string[,] { { "Выполнение работ по монтажу, пусконаладочным работам и подключению локальных вычислительных сетей", "Монтаж технологического оборудования (локальных вычислительных сетей)", "Поставка коммутационного оборудования локальной вычислительной сети" }, { "Выполнение работ по капитальному ремонту подвала и систем водоотведения (магистрали)", "Выполнение работ по комплексному капитальному ремонту здания образовательной организации", "Выполнение работ по капитальному ремонту в ГБУ" }, { "Выполнение работ по постановке на Государственный кадастровый учет бесхозяйных объектов коммунальной инфраструктуры", "Выполнение кадастровых работ по подготовке технических планов с целью образования нескольких сооружений путем раздела единого сооружения", "Выполнение кадастровых работ по земельным участкам, занимаемым объектами метрополитена" } };
        static string[] taskCategories = new string[] { "Монтаж локальных сетей", "Капитальный ремонт строений", "Выполнение кадастровых работ" };

        static string[,] orders, sortedOrders;

        static string contractorType;

        static string INN;

        static string KPP;

        static string OGRN;

        static string OGRNIP;

        static string contractorName;

        static int selectedEntity;

        static int ordersEntityNumber;

        static int suppliersEntityNumber;

        static int whatWeGenerate;

        static int taskIndex;

        static int categoryIndex;

        static string taskName;

        static string categoryName;

        static string orderCost;

        static float requiredRating1;

        static float requiredRating2;

        static float requiredRating3;

        static float supplierRating1 = 7;

        static float supplierRating2 = 7;

        static float supplierRating3 = 7;

        static float ratingDelta;

        static bool isChecked;

        static int genIndex; // 1 - физические лица, 2 - ИП, 3 - физлица + ИП, 4 - юрлица, 5 - физлица и юрлица
                             // 6 - ИП и юрлица, 7 - физлица, ИП и юрлица

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
            Orders.Visibility = Visibility.Hidden;
        }

        private void ListViewItem_Selected_LK_Menu(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            LK.Visibility = Visibility.Hidden;
            INFO.Visibility = Visibility.Visible;
            Orders.Visibility = Visibility.Hidden;
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            LK.Visibility = Visibility.Visible;
            INFO.Visibility = Visibility.Hidden;
            Orders.Visibility = Visibility.Hidden;

        }


        private void ListViewItem_Loaded(object sender, RoutedEventArgs e)
        {
            LK.Visibility = Visibility.Hidden;
            INFO.Visibility = Visibility.Visible;
            Orders.Visibility = Visibility.Hidden;
        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {
            Orders.Visibility = Visibility.Visible;
            LK.Visibility = Visibility.Hidden;
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
            Da.Filter = "Изображения (*.docx,*.BMP, *.JPG, *.GIF, *.TIF, *.JPEG, *.PNG, *.ICO, *.EMF, *.WMF)|*.docx;*.bmp;*.jpg;*.gif; *.tif; *.jpeg; *.png; *.ico; *.emf; *.wmf";

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
            label_Copy10.Visibility = Visibility.Hidden;
            label_Copy11.Visibility = Visibility.Visible;
            button_Copy4.Content = "Обновить";

        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            


        }

        static void PopulateListBox()
        {
            
        }

        static void GenerateOrders()
        {
            ordersEntityNumber = 100;

            Random rand = new Random(DateTime.Now.Millisecond);

            genIndex = 7;

            orders = new string[8, ordersEntityNumber];


            for (int n = 0; n < ordersEntityNumber; n++)
            {
                INN = "";
                KPP = "";
                OGRN = "";
                OGRNIP = "";

                ratingDelta = 0;

                categoryIndex = rand.Next(0, 3);

                taskIndex = rand.Next(0, 3);

                categoryName = taskCategories[categoryIndex];

                taskName = tasks[categoryIndex, taskIndex];

                if (genIndex == 1)
                {
                    contractorName = physSurnames[rand.Next(0, physSurnames.Length)] + " ";
                    //System.Threading.Thread.Sleep(rand.Next(10, 200));
                    contractorName = contractorName + physNames[rand.Next(0, physNames.Length)] + " ";
                    //System.Threading.Thread.Sleep(rand.Next(10, 200));
                    contractorName = contractorName + physPatNames[rand.Next(0, physPatNames.Length)];

                    contractorType = "Физическое лицо";
                    for (int i = 0; i < 12; i++)
                    {
                        INN = INN + (rand.Next(0, 10)).ToString();
                        //System.Threading.Thread.Sleep(rand.Next(10, 60));
                    }





                    //Console.WriteLine(contractorName);
                }

                if (genIndex == 2)
                {
                    contractorName = "ИП " + physSurnames[rand.Next(0, physSurnames.Length)] + " ";
                    //System.Threading.Thread.Sleep(rand.Next(10, 200));
                    contractorName = contractorName + physNames[rand.Next(0, physNames.Length)] + " ";
                    //System.Threading.Thread.Sleep(rand.Next(10, 200));
                    contractorName = contractorName + physPatNames[rand.Next(0, physPatNames.Length)];
                    contractorType = "Индивидуальный предприниматель";

                    for (int i = 0; i < 12; i++)
                    {
                        INN = INN + (rand.Next(0, 10)).ToString();
                        //System.Threading.Thread.Sleep(rand.Next(10, 60));
                    }

                    for (int i = 0; i < 15; i++)
                    {
                        OGRNIP = OGRNIP + (rand.Next(0, 10)).ToString();
                        //System.Threading.Thread.Sleep(rand.Next(10, 60));
                    }

                    //Console.WriteLine(contractorName);
                }

                if (genIndex == 3)
                {
                    selectedEntity = rand.Next(0, 2);
                    if (selectedEntity == 0)
                    {
                        contractorName = physSurnames[rand.Next(0, physSurnames.Length)] + " ";
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + physNames[rand.Next(0, physNames.Length)] + " ";
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + physPatNames[rand.Next(0, physPatNames.Length)];
                        contractorType = "Физическое лицо";

                        for (int i = 0; i < 12; i++)
                        {
                            INN = INN + (rand.Next(0, 10)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 60));
                        }
                    }


                    if (selectedEntity == 1)
                    {
                        contractorName = "ИП " + physSurnames[rand.Next(0, physSurnames.Length)] + " ";
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + physNames[rand.Next(0, physNames.Length)] + " ";
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + physPatNames[rand.Next(0, physPatNames.Length)];
                        contractorType = "Индивидуальный предприниматель";

                        for (int i = 0; i < 12; i++)
                        {
                            INN = INN + (rand.Next(0, 10)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 60));
                        }
                    }
                    //Console.WriteLine(contractorName);

                }

                if (genIndex == 4)
                {
                    contractorName = entityNames1[rand.Next(0, entityNames1.Length)];
                    //System.Threading.Thread.Sleep(rand.Next(10, 200));
                    contractorName = contractorName + entityNames2[rand.Next(0, entityNames2.Length)];
                    contractorType = "Юридическое лицо";

                    for (int i = 0; i < 10; i++)
                    {
                        INN = INN + (rand.Next(0, 10)).ToString();
                        //System.Threading.Thread.Sleep(rand.Next(10, 60));
                    }

                    for (int i = 0; i < 9; i++)
                    {
                        KPP = KPP + (rand.Next(0, 10)).ToString();
                        //System.Threading.Thread.Sleep(rand.Next(10, 60));
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        OGRN = OGRN + (rand.Next(0, 13)).ToString();
                        //System.Threading.Thread.Sleep(rand.Next(10, 60));
                    }
                    //Console.WriteLine(contractorName);
                }

                if (genIndex == 5)
                {
                    selectedEntity = rand.Next(0, 2);
                    if (selectedEntity == 0)
                    {
                        contractorName = physSurnames[rand.Next(0, physSurnames.Length)] + " ";
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + physNames[rand.Next(0, physNames.Length)] + " ";
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + physPatNames[rand.Next(0, physPatNames.Length)];
                        contractorType = "Физическое лицо";

                        for (int i = 0; i < 12; i++)
                        {
                            INN = INN + (rand.Next(0, 10)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 60));
                        }
                    }


                    if (selectedEntity == 1)
                    {
                        contractorName = entityNames1[rand.Next(0, entityNames1.Length)];
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + entityNames2[rand.Next(0, entityNames2.Length)];
                        contractorType = "Юридическое лицо";

                        for (int i = 0; i < 10; i++)
                        {
                            INN = INN + (rand.Next(0, 10)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 60));
                        }

                        for (int i = 0; i < 9; i++)
                        {
                            KPP = KPP + (rand.Next(0, 10)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 60));
                        }
                    }
                    //Console.WriteLine(contractorName);

                }

                if (genIndex == 6)
                {
                    selectedEntity = rand.Next(0, 2);
                    if (selectedEntity == 0)
                    {
                        contractorName = "ИП " + physSurnames[rand.Next(0, physSurnames.Length)] + " ";
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + physNames[rand.Next(0, physNames.Length)] + " ";
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + physPatNames[rand.Next(0, physPatNames.Length)];
                        contractorType = "Индивидуальный предприниматель";

                        for (int i = 0; i < 12; i++)
                        {
                            INN = INN + (rand.Next(0, 10)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 60));
                        }
                    }


                    if (selectedEntity == 1)
                    {
                        contractorName = entityNames1[rand.Next(0, entityNames1.Length)];
                        //System.Threading.Thread.Sleep(rand.Next(10, 60));
                        contractorName = contractorName + entityNames2[rand.Next(0, entityNames2.Length)];
                        contractorType = "Юридическое лицо";

                        for (int i = 0; i < 10; i++)
                        {
                            INN = INN + (rand.Next(0, 10)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        }

                        for (int i = 0; i < 9; i++)
                        {
                            KPP = KPP + (rand.Next(0, 10)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        }
                    }
                    //Console.WriteLine(contractorName);

                }

                if (genIndex == 7)
                {
                    selectedEntity = rand.Next(0, 3);
                    if (selectedEntity == 0)
                    {
                        contractorName = physSurnames[rand.Next(0, physSurnames.Length)] + " ";
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + physNames[rand.Next(0, physNames.Length)] + " ";
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + physPatNames[rand.Next(0, physPatNames.Length)];
                        contractorType = "Физическое лицо";

                        for (int i = 0; i < 12; i++)
                        {
                            INN = INN + (rand.Next(0, 10)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 60));
                        }
                    }


                    if (selectedEntity == 1)
                    {
                        contractorName = "ИП " + physSurnames[rand.Next(0, physSurnames.Length)] + " ";
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + physNames[rand.Next(0, physNames.Length)] + " ";
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + physPatNames[rand.Next(0, physPatNames.Length)];
                        contractorType = "Индивидуальный предприниматель";

                        for (int i = 0; i < 12; i++)
                        {
                            INN = INN + (rand.Next(0, 10)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 60));
                        }
                    }


                    if (selectedEntity == 2)
                    {
                        contractorName = entityNames1[rand.Next(0, entityNames1.Length)];
                        //System.Threading.Thread.Sleep(rand.Next(10, 200));
                        contractorName = contractorName + entityNames2[rand.Next(0, entityNames2.Length)];
                        contractorType = "Юридическое лицо";

                        for (int i = 0; i < 10; i++)
                        {
                            INN = INN + (rand.Next(0, 10)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 60));
                        }

                        for (int i = 0; i < 9; i++)
                        {
                            KPP = KPP + (rand.Next(0, 10)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 60));
                        }
                    }
                    //Console.WriteLine(contractorName);

                }


                requiredRating1 = rand.Next(5, 10);

                requiredRating2 = rand.Next(5, 10);

                requiredRating3 = rand.Next(5, 10);

                orderCost = rand.Next(2000, 1500000).ToString();

                orders[0, n] = orderCost;
                orders[1, n] = taskName;
                orders[2, n] = categoryName;
                orders[3, n] = contractorName;
                orders[4, n] = requiredRating1.ToString();
                orders[5, n] = requiredRating2.ToString();
                orders[6, n] = requiredRating3.ToString();
                if ((requiredRating1 - supplierRating1) > 0) ratingDelta = ratingDelta + (requiredRating1 - supplierRating1);
                if ((requiredRating2 - supplierRating2) > 0) ratingDelta = ratingDelta + (requiredRating2 - supplierRating2);
                if ((requiredRating3 - supplierRating3) > 0) ratingDelta = ratingDelta + (requiredRating3 - supplierRating3);
                orders[7, n] = ratingDelta.ToString();
            }

        }

        private void listBox_Loaded(object sender, RoutedEventArgs e)
        {
            GenerateOrders();

            listBoxCost.Items.Clear();
            listBoxTask.Items.Clear();
            listBoxCategory.Items.Clear();
            listBoxCustomer.Items.Clear();
            listBoxRating1.Items.Clear();
            listBoxRating2.Items.Clear();
            listBoxRating3.Items.Clear();

            for (int i = 0; i < ordersEntityNumber; i++)
            {
                listBoxCost.Items.Add(orders[0, i]);
                listBoxTask.Items.Add(orders[1, i]);
                listBoxCategory.Items.Add(orders[2, i]);
                listBoxCustomer.Items.Add(orders[3, i]);
                listBoxRating1.Items.Add(orders[4, i]);
                listBoxRating2.Items.Add(orders[5, i]);
                listBoxRating3.Items.Add(orders[7, i]); // Заменить на 6 !!!



            }

        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            isChecked = !isChecked;

            sortedOrders = new string[8, ordersEntityNumber];

            if (isChecked)
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < ordersEntityNumber; j++)
                    {
                        sortedOrders[i, j] = orders[i, j];
                    }
                }

                for (int i = 0; i < ordersEntityNumber; i++)
                {
                    //Вложенный цикл (количество повторений, равно количеству элементов массива минус 1 и минус количество выполненных повторений основного цикла)
                    for (int j = 0; j < ordersEntityNumber - 1 - i; j++)
                    {
                        //Если элемент массива с индексом j больше следующего за ним элемента
                        if (float.Parse(sortedOrders[7, j]) > float.Parse(sortedOrders[7, j + 1]))
                        {
                            //Меняем местами элемент массива с индексом j и следующий за ним
                            Swap(ref sortedOrders[0, j], ref sortedOrders[0, j + 1]);
                            Swap(ref sortedOrders[1, j], ref sortedOrders[1, j + 1]);
                            Swap(ref sortedOrders[2, j], ref sortedOrders[2, j + 1]);
                            Swap(ref sortedOrders[3, j], ref sortedOrders[3, j + 1]);
                            Swap(ref sortedOrders[4, j], ref sortedOrders[4, j + 1]);
                            Swap(ref sortedOrders[5, j], ref sortedOrders[5, j + 1]);
                            Swap(ref sortedOrders[6, j], ref sortedOrders[6, j + 1]);
                            Swap(ref sortedOrders[7, j], ref sortedOrders[7, j + 1]);
                        }
                    }

                    
                }

                listBoxCost.Items.Clear();
                listBoxTask.Items.Clear();
                listBoxCategory.Items.Clear();
                listBoxCustomer.Items.Clear();
                listBoxRating1.Items.Clear();
                listBoxRating2.Items.Clear();
                listBoxRating3.Items.Clear();

                for (int i = 0; i < ordersEntityNumber; i++)
                {
                    listBoxCost.Items.Add(sortedOrders[0, i]);
                    listBoxTask.Items.Add(sortedOrders[1, i]);
                    listBoxCategory.Items.Add(sortedOrders[2, i]);
                    listBoxCustomer.Items.Add(sortedOrders[3, i]);
                    listBoxRating1.Items.Add(sortedOrders[4, i]);
                    listBoxRating2.Items.Add(sortedOrders[5, i]);
                    listBoxRating3.Items.Add(sortedOrders[7, i]); // Заменить на 6 !!!



                }


            }

            else
            {
                listBoxCost.Items.Clear();
                listBoxTask.Items.Clear();
                listBoxCategory.Items.Clear();
                listBoxCustomer.Items.Clear();
                listBoxRating1.Items.Clear();
                listBoxRating2.Items.Clear();
                listBoxRating3.Items.Clear();

                for (int i = 0; i < ordersEntityNumber; i++)
                {
                    listBoxCost.Items.Add(orders[0, i]);
                    listBoxTask.Items.Add(orders[1, i]);
                    listBoxCategory.Items.Add(orders[2, i]);
                    listBoxCustomer.Items.Add(orders[3, i]);
                    listBoxRating1.Items.Add(orders[4, i]);
                    listBoxRating2.Items.Add(orders[5, i]);
                    listBoxRating3.Items.Add(orders[7, i]); // Заменить на 6 !!!



                }
            }
        }

        private void Category1_Selected(object sender, RoutedEventArgs e)
        {

        }

        public static void Swap(ref string aFirstArg, ref string aSecondArg)
        {
            //Временная (вспомогательная) переменная, хранит значение первого элемента
            string tmpParam = aFirstArg;

            //Первый аргумент получил значение второго
            aFirstArg = aSecondArg;

            //Второй аргумент, получил сохраненное ранее значение первого
            aSecondArg = tmpParam;
        }
    }
}