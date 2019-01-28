using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestautantWaiter
{
    public class Logic
    {
        public RestaurantContext context;
        public Logic(RestaurantContext ctx)
        {
            context = ctx;
        }


        public void CreateDish(User user)
        {
            Console.WriteLine("Введите название блюда: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите цену: ");
            string price = Console.ReadLine();
            int price2 = int.Parse(price);

            Item item = new Item();
            item.Name = name;
            item.Price = price2;

            context.Items.Add(item);
            context.SaveChanges();
            Console.Clear();
            Console.WriteLine("Блюдо успешно добавлено");
        }

        public void CreateComment()
        {
            Console.WriteLine("Введите ID блюда: ");
            int DishId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите текст комментария: ");
            string commentText = Console.ReadLine();

            

            List<Item> newsList = context.Items.ToList();
            Item article = new Item();

            for (int i = 0; i < newsList.Count; i++)
            {
                if (newsList[i].Id == DishId)
                {
                    article = newsList[i];
                    article.Comments = commentText;
                }
            }
            
            //context.Comments.Add(commentText);
            context.SaveChanges();
            Console.Clear();
            Console.WriteLine("Комментарий успешно добавлен!");
        }

        public void ShowNews()
        {
            List<Item> newsList = context.Items.ToList();

            for (int i = 0; i < newsList.Count; i++)
            {
                Console.WriteLine("ID: " + newsList[i].Id);
                Console.WriteLine("Блюдо: " + newsList[i].Name);
                Console.WriteLine("Цена: " + newsList[i].Price);
                Console.WriteLine("Комментарии: " + newsList[i].Comments);
                Console.WriteLine();
                Console.WriteLine("--------------------------------");
                Console.WriteLine();
            }
        }

    }
}
