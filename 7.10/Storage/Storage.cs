using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Storage
{
    public abstract class Storage
    {
        protected String Name { get; set; }
        protected String Model { get; set; }

        public abstract double GetMemory();
        public abstract double Copy(ref double data);
        public abstract double GetFreeMemory();
        public abstract string GetInfo();
        public abstract void Clear();
    }
}
