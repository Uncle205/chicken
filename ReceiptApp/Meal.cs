using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptApp
{
    public class Meal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Component> Components { get; set; }

        public Meal()
        {
            Components = new List<Component>();
        }
    }
}
