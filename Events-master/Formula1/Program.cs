using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1
{
    class Program
    {
        static void Main(string[] args)
        {
            Race race = new Race(
                new Car(CarType.bus, "Astra"),
                new Car(CarType.passenger, "Волга"),
                new Car(CarType.sport, "Porsche"),
                new Car(CarType.truck, "КАМАЗ"),
                new Car(CarType.passenger, "Приора")
                );
            race.Start();
        }
        

        
    }
}
