using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.В файле записана непустая последовательность целых чисел, являющихся числами Фибоначчи. Приписать еще столько же чисел этой последовательности.
            string buffer;
            using (FileStream stream = new FileStream("file.txt", FileMode.OpenOrCreate))
            {
                byte[] vs = new byte[stream.Length];
                stream.Read(vs, 0, vs.Length);
                buffer = Encoding.UTF8.GetString(vs);
            }
            var array = buffer.TrimEnd(' ').Split(' ').ToArray();
            List<int> myInts = Array.ConvertAll(array, int.Parse).ToList();
            int size = myInts.Count;
            for (int i = 0; i < size; i++)
            {
                myInts.Add(myInts.ElementAt(myInts.Count - 2) + myInts.Last());
            }
            using (FileStream stream = new FileStream("file.txt", FileMode.OpenOrCreate))
            {
                for (int i = 0; i < myInts.Count; i++)
                {
                    byte[] vs = Encoding.UTF8.GetBytes(myInts[i] + " ");
                    stream.Write(vs, 0, vs.Length);
                }
            }

            //2.Сложить два целых числа А и В.
            string buffer2;
            using (FileStream stream = new FileStream("INPUT.txt", FileMode.OpenOrCreate))
            {
                byte[] vs = new byte[stream.Length];
                stream.Read(vs, 0, vs.Length);
                buffer2 = Encoding.UTF8.GetString(vs);
            }
            var array2 = buffer2.TrimEnd(' ').Split(' ').ToArray();
            List<int> myInts2 = Array.ConvertAll(array2, int.Parse).ToList();
            using (FileStream stream = new FileStream("OTPUT.txt", FileMode.OpenOrCreate))
            {
                byte[] vs2 = Encoding.UTF8.GetBytes((myInts2[0] + myInts2[1]).ToString());
                stream.Write(vs2, 0, vs2.Length);
            }
        }
    }
}
