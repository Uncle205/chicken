using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Storage
{
    public class Flash : Storage
    {
        private double SpeedUSB3 { get; set; }
        private double MaxSize { get; set; }
        private double Size { get; set; }

        public Flash(string name, string model, double size)
        {
            SpeedUSB3 = 5000;
            Name = name;
            Model = model;
            MaxSize = size;
        }

        public override double Copy(ref double data)
        {
            double time;
            if (MaxSize - Size >= data)
            {
                time = data / SpeedUSB3;
                Size = MaxSize - Size - data;
                data = 0;
                return time;
            }
            else
            {
                time = (MaxSize - Size) / SpeedUSB3; 
                data = (data - MaxSize - Size);
                Size = MaxSize;
                return time;
            }
        }

        public override double GetFreeMemory()
        {
            return MaxSize - Size;
        }

        public override string GetInfo()
        {
            return string.Format($"{Model}({Name}):{Size}/{MaxSize}");
        }

        public override double GetMemory()
        {
            return MaxSize;
        }

        public override void Clear()
        {
            Size = 0;
        }
    }
}
