using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib
{
    public class Tank
    {
        protected string TankName;
        protected int amo;
        protected int armor;
        protected int movement;
        public Tank(int amo, int armor, int movement, string TankName)
        {
            this.amo = amo;
            this.armor = armor;
            this.movement = movement;
            this.TankName = TankName;
               }
        public Tank()
        {
            Random rand = new Random();
            amo = rand.Next(0, 100);
        }
        public static Tank operator ^(Tank T34, Tank Pantera)
        {
            if(T34.amo>Pantera.amo && T34.armor > Pantera.armor&&T34.movement>Pantera.movement)
            {
                return T34;

            }
            else { return Pantera; }
        }
        public void Print()
        {
            Console.WriteLine("name - " + TankName);
            Console.WriteLine("amo = " + amo + " armor = " + armor + " movement = " + movement);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           
                Random rand = new Random();
            Tank[] VIN = new Tank[5];
            Tank[] T34 = new Tank[5];
                for (int i = 0; i < T34.Length; i++)
                {
                    VIN[i] = new Tank();
                }
                for (int i = 0; i < T34.Length; i++)
                {
                    T34[i] = new Tank(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100), "T34");
                }
            Tank[] pantera = new Tank[5];
                for (int i = 0; i < T34.Length; i++)
                {
                    pantera[i] = new Tank(rand.Next(0, 100), rand.Next(0, 100), rand.Next(0, 100), "pantera");
                }
                for (int i = 0; i < 5; i++)
                {
                    T34[i].Print();
                    pantera[i].Print(); ;
                    VIN[i] = T34[i] * Pantera[i];
                    Console.WriteLine();
                    Console.WriteLine($"В {i + 1} схватке победил");
                    VIN[i].Print();
                    Console.WriteLine();
                    Console.WriteLine();
                }




            
        }
    }
   
}
