using System;
using System.IO;
using FreshRating;

namespace ConsoleApp2
{
    class ProgramModern
    {
        static string[] entityNames1 = { "Жил", "Инфра", "Юг", "Север", "Теле", "Бизнес", "Электро", "Восток", "Запад", "Бел", "Мех", "Энерго", "А-", "Б-", "В-", "М-", "Норд", "Пресс", "Порт", "Вест", "Ост", "Газ", "Инж", "Пож", "Мор", "Сель", "ТД ", "Арм", "Информ", "Регион", "Байт", "НТЦ-", "ОМФ-", "Радио", "Альянс", "Гидро", "Тепло", "Металл", "БМ-" };
        static string[] entityNames2 = { "Строй", "Линк", "Контакт", "Скан", "Быт", "Групп", "Софт", "План", "Сервис", "Тех", "Снаб", "Техника", "Систем", "Система", "Ресурс", "Терра", "Экспресс", "Системс", "Автоматика", "Класс", "Канал", "Комплект", "Стандарт", "Премьер", "Град", "Проджектс", "Арсенал", "Маркет", "Форм", "Пром", "Контроль", "Инжиниринг" };
        static string[] physNames = new string[] { "Александр", "Максим", "Дмитрий", "Кирилл", "Никита", "Михаил", "Егор", "Матвей", "Андрей", "Илья", "Алексей", "Роман", "Сергей", "Владислав", "Ярослав", "Тимофей", "Денис", "Владимир", "Павел", "Глеб", "Константин", "Богдан", "Евгений", "Николай", "Степан", "Тимур", "Марк", "Семён", "Фёдор", "Георгий", "Антон", "Вадим", "Игорь", "Григорий", "Виктор", "Станислав", "Олег", "Пётр", "Юрий", "Виталий", "Василий", "Всеволод", "Марат" };
        static string[] physSurnames = new string[] { "Сергеев", "Иванов", "Константинов", "Петров", "Смирнов", "Кузнецов", "Попов", "Васильев", "Петров", "Соколов", "Михайлов", "Новиков", "Федоров", "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов", "Егоров", "Павлов", "Козлов", "Степанов", "Николаев", "Орлов", "Андреев", "Макаров", "Никитин", "Захаров", "Зайцев", "Соловьев", "Борисов", "Яковлев", "Григорьев", "Романов", "Воробьев", "Сергеев", "Кузьмин", "Фролов", "Александров" };
        static string[] physPatNames = new string[] { "Александрович", "Максимович", "Дмитриевич", "Кириллович", "Никитич", "Михайлович", "Егорович", "Матвеевич", "Андреевич", "Ильич", "Алексеевич", "Романович", "Сергеевич", "Владиславович", "Ярославович", "Тимофеевич", "Денисович", "Владимирович", "Павлович", "Глебович", "Константинович", "Богданович", "Евгеньевич", "Николаевич", "Степанович", "Тимурович", "Маркович", "Семёнович", "Фёдорович", "Георгиевич", "Антонович", "Вадимович", "Игоревич", "Григорьевич", "Викторович", "Станиславович", "Олегович", "Петрович", "Юрьевич", "Витальевич", "Васильевич", "Всеволодович", "Маратович" };
        static string[,] tasks = new string[,] { { "Выполнение работ по монтажу, пусконаладочным работам и подключению локальных вычислительных сетей для нужд ГАОУ ДПО МЦКО по адресу: город Москва, улица Павла Корчагина, дом 18", "Монтаж технологического оборудования (локальных вычислительных сетей) для нужд ГАОУ ДПО МЦКО", "Поставка коммутационного оборудования локальной вычислительной сети" }, { "Выполнение работ по капитальному ремонту подвала и систем водоотведения (магистрали)", "Выполнение работ по комплексному капитальному ремонту здания образовательной организации", "Выполнение работ по капитальному ремонту в ГБУ" }, { "Выполнение работ по постановке на Государственный кадастровый учет бесхозяйных объектов коммунальной инфраструктуры", "Выполнение кадастровых работ по подготовке технических планов с целью образования нескольких сооружений путем раздела единого сооружения", "Выполнение кадастровых работ по земельным участкам, занимаемым объектами метрополитена" } };
        static string[] taskCategories = new string[] { "Монтаж локальных сетей", "Капитальный ремонт строений", "Выполнение кадастровых работ" };

        static string contractorType;

        static string INN;

        static string KPP;

        static string OGRN;

        static string OGRNIP;

        static string contractorName;

        static int selectedEntity;

        static int entityNumber;

        static int whatWeGenerate;

        static int taskIndex;

        static int categoryIndex;

        static string taskName;

        static string categoryName;

        static int genIndex; // 1 - физические лица, 2 - ИП, 3 - физлица + ИП, 4 - юрлица, 5 - физлица и юрлица
                             // 6 - ИП и юрлица, 7 - физлица, ИП и юрлица

        //static void Main(string[] args)
        //{
            //Console.WriteLine("1 - генерируем заказы, 2 - генерируем поставщиков");

            //whatWeGenerate = int.Parse(Console.ReadLine());

            //Console.WriteLine("1 - физические лица, 2 - ИП, 3 - физлица + ИП, 4 - юрлица, 5 - физлица и юрлица, 6 - ИП и юрлица, 7 - физлица, ИП и юрлица");

            //genIndex = int.Parse(Console.ReadLine());

            //if (whatWeGenerate == 1)
            //{
            //    GenerateOrders();
            //}

            //if (whatWeGenerate == 2)
            //{
            //    GenerateSuppliers();
            //}
       // }

        static void GenerateOrders()
        {
            entityNumber = 100;

            Random rand = new Random(DateTime.Now.Millisecond);


            StreamWriter f = new StreamWriter("orders.txt", true);

            for (int n = 0; n < entityNumber; n++)
            {
                INN = "";
                KPP = "";
                OGRN = "";
                OGRNIP = "";

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




                //Console.WriteLine(contractorName + " " + contractorType + " ИНН: " + INN + " КПП: " + KPP + " ОГРН: " + OGRN + " ОГРНИП: " + OGRNIP + " Категория: " + categoryName + " Задача: " + taskName);


                f.WriteLine(contractorName);
                f.WriteLine(contractorType);
                f.WriteLine(INN);
                f.WriteLine(KPP);
                f.WriteLine(OGRN);
                f.WriteLine(OGRNIP);
                f.WriteLine(categoryName);
                f.WriteLine(taskName);


                //System.Threading.Thread.Sleep(rand.Next(10, 215));

                //Console.ReadLine();
            }
            f.Close();
            //Console.ReadLine();
        }

        static void GenerateSuppliers()
        {
            entityNumber = 1000;

            Random rand = new Random(DateTime.Now.Millisecond);

            StreamWriter f = new StreamWriter("contractors.txt", true);

            for (int n = 0; n < entityNumber; n++)
            {
                INN = "";
                KPP = "";
                OGRN = "";
                OGRNIP = "";


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

                        for (int i = 0; i < 10; i++)
                        {
                            OGRN = OGRN + (rand.Next(0, 13)).ToString();
                            //System.Threading.Thread.Sleep(rand.Next(10, 60));
                        }
                    }
                    //Console.WriteLine(contractorName);

                }


                //Console.WriteLine(contractorName + " " + contractorType + " ИНН: " + INN + " КПП: " + KPP + " ОГРН: " + OGRN + " ОГРНИП: " + OGRNIP);


                f.WriteLine(contractorName);
                f.WriteLine(contractorType);
                f.WriteLine(INN);
                f.WriteLine(KPP);
                f.WriteLine(OGRN);
                f.WriteLine(OGRNIP);


                //System.Threading.Thread.Sleep(rand.Next(10, 215));

                //Console.ReadLine();
            }
            f.Close();
            //Console.ReadLine();
        }
    }
}
