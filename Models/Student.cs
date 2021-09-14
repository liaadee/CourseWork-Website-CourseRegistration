using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }
        public List<Course> RegisteredCourses { get; } //Prep4)

        public Student(string aName) //!Constructor 
        {
            Name = aName;
            Random randomNum = new Random();
            Id = randomNum.Next(100000, 1000000);
            RegisteredCourses = new List<Course>(); //Prep4)
        }
        public virtual void RegisterCourses(List<Course> selectedCourses) //Prep4)Method
        {
            RegisteredCourses.Clear();
            foreach (Course item in selectedCourses)
            {
                RegisteredCourses.Add(item);
            }
        }
        public int TotalWeeklyHours() //Prep4)Method
        {
            int totalWeeklyHours = 0;
            foreach (Course item in RegisteredCourses)
            {
                totalWeeklyHours += item.WeeklyHours;
            }
            return totalWeeklyHours;
        }
    }
}