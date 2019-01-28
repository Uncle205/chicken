using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWModul4
{
//1.	Разработать один из классов, в соответствии с полученным вариантом.
    partial class Airplane
    {
        //2.	Реализовать не менее пяти закрытых полей(различных типов), представляющих основные характеристики рассматриваемого класса.
        private static int IdNow { get; set; }
        private static int Count { get; set; }
        public int Id { get; set; }
        public string ModelName { get; set; }
        public bool IsFlies { get; set; }
        public string Company { get; set; }
        private bool[] placeIsFree; //Какие места в самолете свободный
        public bool this[int index] 
        {
            get { return placeIsFree[index]; }
            set { placeIsFree[index] = value; }
        }
        public string Country { get; set; } //В какой стране сейчас
        //3.	Создать не менее трех методов управления классом и методы доступа к его закрытым полям.
        public bool FlyTo(string to, DateTime when)
        {
            if(IsFlies == false) //Если самолет щас не в полете отправить 
            {
                if (DateTime.Now > when) return false;
                IsFlies = true;
                while (!(DateTime.Now == when))
                {
                }
                Country = to;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TakePlace(int numPlace)
        {
           if(placeIsFree[numPlace] == false) return false;
            placeIsFree[numPlace] = false;
            return true;
        }
        public bool TakePlace(params int[] numPlaces)
        {
            for (int i = 0; i < numPlaces.Length; i++)
            { 
            if (placeIsFree[numPlaces[i]] == false) return false;
            }
            for (int i = 0; i < numPlaces.Length; i++)
            {
                placeIsFree[numPlaces[i]] = false;
            }
            return true;
        }
        static Airplane()
        {
            IdNow = 0;
            Count = 0;
        }
        public Airplane()
        {
            this.Company = " "; 
            this.Country = " ";
            this.Id = IdNow;
            this.IsFlies = false;
            this.ModelName = " ";
            this.placeIsFree = new bool[100];
            IdNow++;
            Count++;
        }
        public Airplane(string Company, string Country, string ModelName, int numberOfPlace)
        {
            this.Company = Company;
            this.Country = Country;
            this.Id = IdNow;
            this.IsFlies = false;
            this.ModelName = ModelName;
            this.placeIsFree = new bool[numberOfPlace];
            IdNow++;
            Count++;
        }
        public Airplane(ref Airplane airplane)
        {
            this.Company = airplane.Company;
            this.Country = airplane.Country;
            this.Id = IdNow;
            this.IsFlies = false;
            this.ModelName = airplane.ModelName;
            this.placeIsFree = new bool[airplane.placeIsFree.Length];
            IdNow++;
            Count++;
        }
    }
}
