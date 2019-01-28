using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Storage
{
    public class HDD : Storage
    {
        private double SpeedUSB2 { get; set; }
        public readonly int countPartitions;
        private double[] partitionSize;
        private double[] partitionMaxSize;

        public HDD(string name, string model, params double[] size)
        {
            SpeedUSB2 = 480;
            Name = name;
            Model = model;
            partitionMaxSize = size;
            countPartitions = size.Length;
            partitionSize = new double[size.Length];
        }

        public override double Copy(ref double data)
        {
            double time = 0;
            for (int i = 0; i < countPartitions; i++)
            {
                if (partitionMaxSize[i] - partitionSize[i] >= data)
                {
                    time += (data / SpeedUSB2);
                    partitionSize[i] = data;
                    data = 0;
                    return time;
                }
                else
                {
                    time += (partitionMaxSize[i] - partitionSize[i]) / SpeedUSB2;
                    data = (data - partitionMaxSize[i] - partitionSize[i]);
                    partitionSize[i] = partitionMaxSize[i];
                }
            }
            return data;
        }

        public override double GetFreeMemory()
        {
            double size = 0;
            for (int i = 0; i < countPartitions; i++)
            {
                size += partitionMaxSize[i] - partitionSize[i];
            }
            return size;
        }

        public override string GetInfo()
        {
            StringBuilder stringBuilder = new StringBuilder($"{Model}({Name})\n");
            for (int i = 0; i < countPartitions; i++)
            {
                stringBuilder.AppendFormat($"{i}. {partitionSize[i]}/{partitionMaxSize[i]}\n");
            }
            return stringBuilder.ToString();
        }

        public override double GetMemory()
        {
            return partitionMaxSize.Sum();
        }

        public override void Clear()
        {
            for (int i = 0; i < countPartitions; i++)
            {
                partitionSize[i] = 0;
            }
        }
    }
}
