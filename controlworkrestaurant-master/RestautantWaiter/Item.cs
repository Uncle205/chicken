using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestautantWaiter
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public string Comments { get; set; }

        public Item()
        {
            Carts = new List<Cart>();
            

        }
       
    }
}
