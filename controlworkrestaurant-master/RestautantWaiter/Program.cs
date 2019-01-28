using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestautantWaiter
{
    class Program
    {
        static void Main(string[] args)
        {

            RestaurantContext context = new RestaurantContext();

            Logic logic = new Logic(context);

            string b;
            Console.WriteLine("Enter table name:\n1.Log in(only for stuff)\n2.Dishes\n3.Comments");
            b = Console.ReadLine();
            int a = int.Parse(b);
            switch (a)
            {
                case 1:
                    Console.WriteLine("Введите имя: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите логин: ");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль: ");
                    string password = Console.ReadLine();

                    List<User> userList = context.Users.ToList();

                    for (int i = 0; i < userList.Count; i++)
                    {
                        if (userList[i].Password == password && userList[i].Login == login)
                        {
                            Console.WriteLine("Вход выполнен!");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Неправильные данные! Попробуйте позже!");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }
                    User user = new User
                    {
                        FullName = name,
                        Login = login,
                        Password = password
                    };
                    break;
                case 2:
                    List<Item> itemsList = context.Items.ToList();

                    foreach(var item in itemsList)
                    {
                        Console.WriteLine(item.Id);
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Price);
                        Console.WriteLine();
                        Console.WriteLine("-------------------");
                        Console.WriteLine();
                    }
                    Console.ReadLine();
                    Console.WriteLine("Enter Dish ID which you want to order ");
                    string num = Console.ReadLine();
                    int rec = int.Parse(num);
                    int summ = 0 + itemsList[rec].Price;
                    Console.WriteLine("your price:" + summ);
                    break;
                case 3:
                    Console.Clear();
                    logic.CreateComment();
                    Console.ReadLine();


                    break;

            }
        }
    }


}

//var chicken1 = new Item
//{
//    Name = "chicken steak with mashrooms ",
//    Price = 2000
//};
//context.Items.Add(chicken1);
//            var chicken2 = new Item
//            {
//                Name = "chicken fillet with vegetables ",
//                Price = 2200
//            };
//context.Items.Add(chicken2);

//            var chicken3 = new Item
//            {
//                Name = "chicken SET",
//                Price = 14000
//            };
//context.Items.Add(chicken3);

//            var chicken4 = new Item
//            {
//                Name = "chicken gherkins ",
//                Price = 2800
//            }; context.Items.Add(chicken4);

//            var steak1 = new Item
//            {
//                Name = "T-bon",
//                Price = 3500
//            };
//context.Items.Add(steak1);

//            var steak2 = new Item
//            {
//                Name = "Ribeye ",
//                Price = 3500
//            };
//context.Items.Add(steak2);

//            var steak3 = new Item
//            {
//                Name = "medalions with vegetebles",
//                Price = 3000
//            };
//context.Items.Add(steak3);

//            var steak4 = new Item
//            {
//                Name = "rack of lamb ",
//                Price = 3000
//            };
//context.Items.Add(steak4);

//            var steak5 = new Item
//            {
//                Name = "beef with vegetables and teriyaki sauce",
//                Price = 2700
//            };
//context.Items.Add(steak5);

//            var steak6 = new Item
//            {
//                Name = "Huge Mix ",
//                Price = 22000
//            };
//context.Items.Add(steak6);

//            var steak7 = new Item
//            {
//                Name = "Steak BR",
//                Price = 4000
//            };
//context.Items.Add(steak7);

//            var steak8 = new Item
//            {
//                Name = "salmon steak ",
//                Price = 3200
//            };
//context.Items.Add(steak8);

//            var paste1 = new Item
//            {
//                Name = "Karbonara",
//                Price = 1600
//            };
//context.Items.Add(paste1);

//            var paste2 = new Item
//            {
//                Name = "Bolognese ",
//                Price = 1800
//            };
//context.Items.Add(paste2);

//            var paste3 = new Item
//            {
//                Name = "Fetuchini with chickrn and mushrooms",
//                Price = 1700
//            };
//context.Items.Add(paste3);
//            var paste4 = new Item
//            {
//                Name = "Paste with oceandishes ",
//                Price = 3000
//            };
//context.Items.Add(paste4);

//            var paste5 = new Item
//            {
//                Name = "beef with vegetables and teriyaki sauce",
//                Price = 2700
//            };
//context.Items.Add(paste5);
//            context.SaveChanges();
            
            