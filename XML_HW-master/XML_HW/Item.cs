using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XML_HW
{
    [Serializable]
    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [System.Xml.Serialization.XmlElementAttribute("title")]
        public string  Title { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("link")]
        public string Link { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("description")]
        public string Description { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("pubDate")]
        public string PubDate { get; set; }
    }
}
