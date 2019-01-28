namespace ReceiptApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ReceiptAppContext : DbContext
    {
        // Контекст настроен для использования строки подключения "ReceiptAppContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "ReceiptApp.ReceiptAppContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ReceiptAppContext" 
        // в файле конфигурации приложения.
        public ReceiptAppContext()
            : base("name=ReceiptAppContext")
        {
        }

        public DbSet<Component> Components { get; set; }
        public DbSet<Meal> Meals { get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}