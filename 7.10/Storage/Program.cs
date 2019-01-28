using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Storage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Storage> storages = new List<Storage>();
            storages.Add(new Flash("Для домашек", "LaCie XtremKey", 64000));
            storages.Add(new Flash("Фильмы", "ADATA DashDrive Elite UE700 ", 16000));
            storages.Add(new DVD("Чисто чистый диск", "Verbatim", TypeDVD.doubleSided));
            storages.Add(new DVD("Пару раз ронял", "Sony 50DMR47SP", TypeDVD.singleSided));
            storages.Add(new HDD("Top Secret", "Seagate", 250000, 250000, 250000, 250000));
            storages.Add(new HDD("Многооооо памяти", "WD Red", 2000000, 2000000));
            Task3(new HDD("Многооооо памяти", "WD Red", 2000000, 2000000));
        }
        static void Task1(List<Storage> storages)
        {
            //●	расчет общего количества памяти всех устройств;
            Console.WriteLine($"{storages.Sum(a => a.GetMemory())/1000}ГБ"); 
        }
        static void Task2(List<Storage> storages)
        {
            double memory, time = 0;
            //●	копирование информации на устройства;
            do
            {
                Console.Clear();
                Console.Write("Введите размер данных: ");
            } while (!double.TryParse(Console.ReadLine(), out memory));
            foreach (var item in storages)
            {
                time += item.Copy(ref memory);
                if(memory == 0)
                {
                    break;
                }
            }
            if(memory != 0)
            {
                Console.WriteLine($"Не хватило {memory}");
            }
            //●	расчет времени необходимого для копирования;
            Console.WriteLine($"Прошло {time}");
            foreach (var item in storages)
            {
                Console.WriteLine(item.GetInfo());
            }
        }
        static void Task3(Storage storage)
        {
            //●	расчет необходимого количества носителей информации представленных типов для переноса информации.
            double memory;
            do
            {
                Console.Clear();
                Console.Write("Введите размер данных: ");
            } while (!double.TryParse(Console.ReadLine(), out memory));
            int i=0;
            while (memory != 0)
            {
                i++;
                storage.Copy(ref memory);
                storage.Clear();
            }
            Console.WriteLine($"Вам понадобиться {i}");
        }
    }
}
