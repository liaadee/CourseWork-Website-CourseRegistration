using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public FulltimeStudent(string name) : base(name) { }

        public override void RegisterCourses(List<Course> selectedCourses) //Prep5)Method
        {
            int totalWeeklyHours = 0;
            foreach (Course item in selectedCourses)
            {
                totalWeeklyHours += item.WeeklyHours;
            }
            if (totalWeeklyHours < MaxWeeklyHours)
            {
                base.RegisterCourses(selectedCourses);
            } 
            else 
            {
                throw new Exception("Total weekly hours of your selected courses exceed the maximum weekly hours allowance for Full-Time Students: 16");
            }
        }
        public override string ToString() //Prep6)
        {
            return Id + " - " + Name + " (Full-Time)";
        }
    }
}