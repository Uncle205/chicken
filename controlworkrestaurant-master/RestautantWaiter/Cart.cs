using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestautantWaiter
{
    public class Cart
    {
        public int Id { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public Cart()
        {
            Items = new List<Item>();
        }
    }
}
