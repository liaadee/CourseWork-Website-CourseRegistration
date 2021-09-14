using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Course
    {
        public string Code { get; } //read-only
        public string Title { get; } //read-only
        public int WeeklyHours { get; set; }

        public Course(string aCode, string aTitle)
        {
            Code = aCode;
            Title = aTitle;
        }
        public override string ToString() //Prep6)
        {
            return Code + " " + Title + " - " +  WeeklyHours + " hours per week";
        }
    }
}