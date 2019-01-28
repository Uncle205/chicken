using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Class)]
    public class Book : Attribute
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string name, int cost, string author, int year)
        {
            Name = name;
            Cost = cost;
            Author = author;
            Year = year;
        }
    }
    
}
