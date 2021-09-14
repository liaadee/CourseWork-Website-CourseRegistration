using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }
        public ParttimeStudent(string name) : base(name) { }

        public override void RegisterCourses(List<Course> selectedCourses) //Prep5)Method
        {
            if (selectedCourses.Count < MaxNumOfCourses)
            {
                base.RegisterCourses(selectedCourses);
            }
            else
            {
                throw new Exception("Total number of your selected courses exceed the maximum course allowance for Part-Time Students: 3");
            }
        }
        public override string ToString() //Prep6)
        {
            return Id + " - " + Name + " (Part-Time)";
        }
    }
}