using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    class Program
    {
        //2.	Для получения места в общежитии формируется список студентов, который включает Ф.И.О.студента, группу, средний балл, доход на члена семьи, пол (перечисление), форма обучения(перечисление). Общежитие в первую очередь предоставляется тем, у кого доход на члена семьи меньше двух минимальных зарплат, затем остальным в порядке уменьшения среднего балла.Вывести список очередности предоставления мест в общежитии.
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Олжас Ыдырыс", "SEP-172", 11, Gender.мужчина, FormOfEducation.fullTime, 32000, 57000));
            students.Add(new Student("Аглаида Исаева", "SEP-171", 12, Gender.женщина, FormOfEducation.fullTime, 81000, 46000));
            students.Add(new Student("Фадей Устинов", "SEP-173", 10, Gender.мужчина, FormOfEducation.fullTime, 146000));
            students.Add(new Student("Ангелина Воробьёва", "SEP-174", 9, Gender.женщина, FormOfEducation.fullTime, 17000, 70000, 217000));
            students.Add(new Student("Валентин Ларионов", "SEP-175", 8, Gender.мужчина, FormOfEducation.Distance, 120000, 97000, 179000, 226000));
            students.Add(new Student("Рената Ситникова", "SEP-176", 7, Gender.женщина, FormOfEducation.fullTime, 98000, 59000, 200000));
            students.Add(new Student("Захар Максимочкин", "SEP-177", 6, Gender.мужчина, FormOfEducation.fullTime, 193000, 103000));
            students.Add(new Student("Агата Андреева", "SEP-178", 5, Gender.женщина, FormOfEducation.Distance, 58000, 64000));
            students.Add(new Student("Виссарион Кошелев", "SEP-179", 10, Gender.мужчина, FormOfEducation.fullTime, 46000));

            int minSalary = 100000;

            var d = students.Where(a => ((a.familySalary.Where(b => b <= minSalary).ToList().Count >= 2) || (a.familySalary.Count == 1 && a.familySalary.First() <= minSalary)) && a.FormOfEducation == FormOfEducation.fullTime).OrderByDescending(a=>a.GPA);
            foreach (var item in d)
            {
                Console.WriteLine("ФИО: " + item.FullName);
                Console.WriteLine("Пол: " + item.Gender);
                Console.WriteLine("Группа: " + item.Group);
                Console.WriteLine("Средняя оценка: " + item.GPA);
                Console.WriteLine();
            }
        }
    }
}
