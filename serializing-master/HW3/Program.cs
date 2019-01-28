using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace HW3
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1() { Model = "asas", Count = 1221, Id = 0 };
            Class1 class1v2 = new Class1() { Model = "asdnasbd", Count = 12312, Id = 1 };

            Class2 class2 = new Class2() { Name = "james", Year = 1999};
            Class2 class2v2 = new Class2() { Name = "bob", Year = 2002 };

            Class3 class3 = new Class3() { Age = 12, Name = "man", Surname = "manson"};
            Class3 class3v2 = new Class3() { Age = 21, Name = "troll", Surname = "troller" };
            
           
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Class1));
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, class1);
                xmlSerializer.Serialize(fs, class1v2);
                xmlSerializer = new XmlSerializer(typeof(Class2));
                xmlSerializer.Serialize(fs, class2);
                xmlSerializer.Serialize(fs, class2v2);
                xmlSerializer = new XmlSerializer(typeof(Class3));
                xmlSerializer.Serialize(fs, class3);
                xmlSerializer.Serialize(fs, class3v2);


             
            }
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter("json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, class1);
                serializer.Serialize(writer, class1v2);
                serializer.Serialize(writer, class2);
                serializer.Serialize(writer, class2v2);
                serializer.Serialize(writer, class3);
                serializer.Serialize(writer, class3v2);

            }

        } 
    }
}
