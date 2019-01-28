using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Type console = typeof(Console);
            MethodInfo[] methods = console.GetMethods();
            Console.WriteLine("*** Список методов класса Console ***\n");
            foreach (MethodInfo m in methods)
            {
                Console.Write("-->" + m.ReturnType.Name + "\t" + m.Name + "(");
                ParameterInfo[] p = m.GetParameters();
                for (int i = 0; i < p.Length; i++)
                {
                    Console.Write(p[i].ParameterType.Name + " " + p[i].Name);
                    if (i + 1 < p.Length) Console.Write(", ");
                }
                Console.Write(")\n");
            }

            Console.ReadLine();
        }
    }
}
