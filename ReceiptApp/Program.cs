using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //                                                                              Поставьте точку останова на 40 строчке
            var context = new ReceiptAppContext();
            List<Meal> meals = new List<Meal>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Записать данные в БД");
                Console.WriteLine("2. Выгрузить данные с помощью Ленивой Зарузки");
                Console.WriteLine("3. Вывести все рецепты");
                Console.WriteLine("4. Выйти");
                Console.WriteLine("Выберите нужный пункт: ");

                int menu;
                Int32.TryParse(Console.ReadLine(), out menu);

                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        WriteDataToDb();
                        Console.WriteLine("Данные записаны!");
                        Console.ReadLine();
                        break;
                    case 2:
                        meals = context.Meals.ToList();
                        Console.Clear();
                        Console.WriteLine("Данные выгружены! Перейдите в код и наведите курсор на meals на 37 строчке.");
                        Console.ReadLine();
                        break;
                    case 3:
                        meals = context.Meals.ToList();
                        for (int i = 0; i < meals.Count; i++)
                        {
                            Console.WriteLine($"{i+1} {meals[i].Name}");
                        }
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
            
        }

        static void ReadAllMeals()
        {

        }

        static void WriteDataToDb()
        {
            using (var context = new ReceiptAppContext())
            {
                Component componentSpaghetti = new Component
                {
                    Name = "Спагетти",
                    Quantity = 1
                };

                Component componentChicken = new Component
                {
                    Name = "Курица",
                    Quantity = 5
                };

                Component componentSauce = new Component
                {
                    Name = "Cливочный соус",
                    Quantity = 1
                };

                Meal foodPasta = new Meal
                {
                    Name = "Паста с курицей"
                };

                foodPasta.Components.Add(componentSpaghetti);
                foodPasta.Components.Add(componentChicken);
                foodPasta.Components.Add(componentSauce);

                context.Components.Add(componentSpaghetti);
                context.Components.Add(componentChicken);
                context.Components.Add(componentSauce);

                context.Meals.Add(foodPasta);

                context.SaveChanges();
            }
        }
    }
}
