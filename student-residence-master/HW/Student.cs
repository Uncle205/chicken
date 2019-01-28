using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{

    public enum Gender
    {
        мужчина,
        женщина
    }
    public enum FormOfEducation
    {
        fullTime = 15000,
        Distance = 20000,
    }
    public class Student
    {
        public Student(string fullName, string group, int gpa, Gender gender, FormOfEducation formOfEducation, params int[] familySalary)
        {
            FullName = fullName;
            Group = group;
            GPA = gpa;
            Gender = gender;
            FormOfEducation = formOfEducation;
            this.familySalary = familySalary.ToList();
        }
        public String FullName { get; set; }
        public String Group { get; set; }
        public int GPA { get; set; }
        public List<int> familySalary;
        public Gender Gender { get; set; }
        public FormOfEducation FormOfEducation { get; set; }
    }
}
