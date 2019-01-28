using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1
{
    public class Race
    {
        public List<Car> Cars { get; set; }
        public delegate string Go();
        private bool _isFinished;
        public Race(params Car[] cars)
        {
            Cars = cars.ToList();
            Cars = Cars.Select(c => { c.Go += Finished; return c; }).ToList();
        }
        public void Start()
        {
            _isFinished = false;
            Cars = Cars.Select(c => { c.Way = 100; return c; }).ToList();
            int i = 0;
            while (!_isFinished)
            {
                Cars[i%Cars.Count].Moving();
                i++;
            }
        }
        public void Finished(string message, bool isFinished)
        {
            Console.WriteLine(message);
            _isFinished = isFinished;
        }
    }
}
