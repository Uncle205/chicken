using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XML_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlStr = File.ReadAllText("habr.xml");
            var str = XElement.Parse(XElement.Parse(xmlStr).FirstNode.ToString());

            var result = str.Elements("item").ToList();
            List<Item> LI = new List<Item>();
            foreach (var node in result)
            {
                node.Elements("category").Remove();
                node.Elements("guid").Remove();
                node.LastNode.Remove() ;
            }
            for (int i = 0; i < result.Count; i++)
            {
                StringReader stringReader = new StringReader(result[i].ToString());
                XmlSerializer serializer = new XmlSerializer(typeof(Item));
                LI.Add(serializer.Deserialize(stringReader) as Item);
            }
            //Console.WriteLine(result);
        }
    }
}
