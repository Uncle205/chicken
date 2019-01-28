using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace hw_1
{
    class Book
    {
        public int Id { get; set; }
        public string Tytle { get; set; }
        public string AuthorName1 { get; set; }
        public string AuthorName2 { get; set; }
        public string Theme { get; set; }
        public decimal Price { get; set; }
        public DateTime DatePublish { get; set; }
        public int Pages { get; set; }
        public Book()
        {

        }
        public Book(int Id, string Tytle,  string AuthorName1, string AuthorName2, string Theme, decimal Price,  DateTime DatePublish, int Pages)
        {
            this.Id = Id;
            this.Tytle = Tytle;
            this.AuthorName1 = AuthorName1;
            this.AuthorName2 = AuthorName2;
            this.Theme = Theme;
            this.Price = Price;
            this.DatePublish = DatePublish;
            this.Pages = Pages;

    }
        public void ShowBookData()
        {
            Console.WriteLine(Id.ToString() +  " "  + Tytle+  " "  +  AuthorName1+  " "  +AuthorName2+  " "  +Theme+  " "  + Price.ToString()+  " "  +DatePublish.ToString(), Pages.ToString());
           // Console.WriteLine(  Id.ToString(), Tytle, AuthorName1, AuthorName2, Theme,  Price.ToString(),  DatePublish.ToString(), Pages.ToString());

        }

    }
    class Program
    {
        static string connectionString = @"data source = DESKTOP-7AA1VK6\SQLEXPRESS; Initial Catalog=b0; Integrated Security=true;";
        static SqlConnection sqlConnection = null;
        static SqlCommand sqlCommand = null;
        static SqlDataReader reader = null;
        static void Main(string[] args)
        {
            //Напишите код с использованием технологии ADO.NET, который создает в базе данных таблицу gruppa.

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            sqlCommand = new SqlCommand
            ("create table cdds (id_reader int primary key identity, name_reader varchar(50) not null)", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlCommand = new SqlCommand("insert into Readers values('Ream Qio')", sqlConnection);
            sqlCommand.ExecuteNonQuery();
            SelectFromReaders();
            Console.ReadKey();
            reader.Close();


            //            Для нашей БД надо написать консольное приложение, которое должно вычислить сумму цен всех книг и сумму
            //страниц всех книг в таблице Books.Но, сначала надо узнать количество книг в этой таблице, для чего предлагается
            //выполнить такой запрос: Select count(id)from Books;

            sqlCommand = new SqlCommand("Select count(id_book) from Books", sqlConnection);
            int countBooks = Convert.ToInt32(sqlCommand.ExecuteScalar());
            Console.WriteLine($"количество книг {countBooks}");
            //
            sqlCommand = new SqlCommand("Select sum(price) from Books", sqlConnection);
            countBooks = Convert.ToInt32(sqlCommand.ExecuteScalar());
            Console.WriteLine($"сумма книг, {countBooks}");

            //
            sqlCommand = new SqlCommand("Select sum(pages) from Books", sqlConnection);
            countBooks = Convert.ToInt32(sqlCommand.ExecuteScalar());
            Console.WriteLine($"сумма страниц книг {countBooks}");

            //            Подумайте, каким из методов класса DbCommand(ExecuteNonQuery(), ExecuteScalar() или ExecuteReader())
            //удобнее всего выполнить этот запрос.Сохраните значение, возвращенное этим запросом в какой-либо int num
            //переменной.Затем выполните запрос Select *from Books;

            //            Для разнообразия, не повторяйте код, написанный нами в этом уроке, и результаты этого запроса извлекайте
            //в цикле for, используя переменную num, инициализированную первым запросом, как ограничитель цикла.На
            //каждой итерации этого цикла for, извлекайте значенияиз полей Price и Pages, как int значения(посмотрите,
            //какие методы для этого есть у класса DbDataReader) и суммируйте их.Значения остальных полей извлекайте
            //согласно их типу в БД.Еще раз внимательно посмотрите, какие методы в классе DbDataReader, позволяют получить
            //прочитанное из таблицы значение и преобразовать его к типу string, или int, или double.Выводите в консоль
            //значения всех полей на каждой итерации.После окончания цикла выведите суммарные значения цен для всех книг
            //и количества страниц для всех книг.
            List<Book> listBook = new List<Book>();
            listBook = SelectFromBooksFor();
            foreach (Book item in listBook)
            {
                item.ShowBookData();
            }
            Console.ReadKey();

            //Цель задания:
            //¦ повторить рассмотренные в уроке действия;
            //¦ научиться извлекать из полей таблицы данные раз -
            //ных типов;
            //¦ использовать не только ExecuteQuery() метод класса
            //DbCommand.

        }
        private static void SelectFromReaders()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlCommand = new SqlCommand("select * from readers;", sqlConnection);

            int line = 0;
            try
            {
                sqlConnection.Open();
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    if (line == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader.GetName(i) + "\t");
                        }
                        Console.WriteLine();
                        line++;
                    }
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static List<Book> SelectFromBooksFor()
        {
            List<Book> list1 = new List<Book>();
            //чтение всего массива
            sqlCommand = new SqlCommand("Select count(id_book) from Books", sqlConnection);
            int cBooks = Convert.ToInt32(sqlCommand.ExecuteScalar()); //количество книг 
            //проверка подключения - подключение
            if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open(); 
            sqlCommand = new SqlCommand("select b.id_book, b.namebook, t.nametheme, a.firstname, a.lastname, b.price, b.dateofpublish, b.pages from Books b, Authors a, themes t where b.id_author = a.id_author and b.Id_theme = t.id_theme", sqlConnection);
            if (reader != null) reader.Close();
            reader = sqlCommand.ExecuteReader();
            decimal allMoney = 0;
            int quantPages = 0;
            for (int i = 0; i < cBooks; i++)
            {
                Book answer = new Book();
                reader.Read();
                for (int j = 0; j < reader.FieldCount; j++)
                {
                    answer.Id = reader.GetInt32(0);
                    answer.Tytle = reader.GetString(1);
                    answer.Theme= reader.GetString(2);
                    answer.AuthorName1 = reader.GetString(3);
                    answer.AuthorName2 = reader.GetString(4);
                    answer.Price = reader.GetDecimal(5);
                    answer.DatePublish = reader.GetDateTime(6);
                    answer.Pages = reader.GetInt32(7);
                }
                list1.Add(answer);
            }
            return list1;
        }
    }
}
