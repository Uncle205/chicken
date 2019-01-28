using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Зима", 15000, "А.С.Пушкин", 1875);
            Book book1 = new Book("Весна", 16000, "Толстой", 1875);
            Book book2 = new Book("Лето", 17000, "Лермонтов", 1875);
            Book book3 = new Book("Осень", 18000, "Достоевский", 1875);
            Console.WriteLine("Объект создан");

            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
           
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("Book.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, book);
                formatter.Serialize(fs, book1);
                formatter.Serialize(fs, book2);
                formatter.Serialize(fs, book3);
                Console.WriteLine("Объект сериализован");
            }

            // десериализация из файла people.dat
            using (FileStream fs = new FileStream("Book.dat", FileMode.OpenOrCreate))
            {
                Book newBook = (Book)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine("Название: {0} --- Цена: {1} --- Автор: {2} --- Год издания: {3}", newBook.Name, newBook.Cost, newBook.Author, newBook.Year);
            }

            Console.ReadLine();


            var customAttributes = (MyCustomAttribute[])typeof(Book).GetCustomAttributes(typeof(MyCustomAttribute), true);
            if (customAttributes.Length > 0)
            {
                var myAttribute = customAttributes[0];
                string value = myAttribute.SomeProperty;
                // TODO: Do something with the value
            }


        }
    }
}
