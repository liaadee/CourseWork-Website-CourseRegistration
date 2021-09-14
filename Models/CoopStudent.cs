using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }

        public CoopStudent(string name) : base(name) { } //!Constructor

        public override void RegisterCourses(List<Course> selectedCourses) //Prep5)Method
        {
            int totalWeeklyHours = 0;
            foreach (Course item in selectedCourses)
            {
                totalWeeklyHours += item.WeeklyHours;
            }
            if (totalWeeklyHours < MaxWeeklyHours && selectedCourses.Count < MaxNumOfCourses)
            {
                base.RegisterCourses(selectedCourses);
            }
            else
            {
                if (totalWeeklyHours > MaxWeeklyHours)
                {
                    throw new Exception("Total weekly hours of your selected courses exceed the maximum weekly hours allowance for Coop Students: 4");
                }
                if (selectedCourses.Count > MaxNumOfCourses)
                {
                    throw new Exception("Total number of your selected courses exceed the maximum course allowance for Coop Students: 2");
                }
            }
        }
        public override string ToString() //Prep6)
        {
            return Id + " - " + Name + " (Coop)";
        }
    }
}