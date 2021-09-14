using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab8.Models;

namespace Lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            panelErrorMessages.Visible = false;
            panelErrorMessageCheckbox.Visible = false;
            if (!Page.IsPostBack)
            {
                dropdownStudents.DataSource = Session["students"];
                dropdownStudents.DataBind();
                dropdownStudents.Items.Insert(0, new ListItem("--Select--", string.Empty)); //todo test
                checkboxlistCourses.DataSource = Helper.GetAvailableCourses();
                checkboxlistCourses.DataBind();
            }
        }

        protected void buttonSubmit_Click(object sender, EventArgs e)
        {
            string selectedStudentString = dropdownStudents.SelectedItem.Value;
            string selectedStudentId = selectedStudentString.Split(new[] { " " }, StringSplitOptions.None)[0];
            List<Student> listStudents = (List<Student>)Session["students"];
            Student selectedStudent = null;
            foreach (Student student in listStudents)
            {
                if (student.Id == Int32.Parse(selectedStudentId))
                {
                    selectedStudent = student;
                    break;
                }
            }
            List<Course> listSelectedCourses = new List<Course>();
            foreach (ListItem course in checkboxlistCourses.Items)
            {
                if (course.Selected)
                {
                    string courseId = course.Value.Split(new[] { " " }, StringSplitOptions.None)[0];
                    listSelectedCourses.Add(Helper.GetCourseByCode(courseId));
                }
            }
            if (listSelectedCourses.Count == 0)
            {
                panelErrorMessageCheckbox.Visible = true;
            }
            try
            {
                selectedStudent.RegisterCourses(listSelectedCourses);
            }
            catch (Exception errorMessage)
            {
                panelErrorMessages.Visible = true;
                labelErrorMessageRegister.Visible = true;
                labelErrorMessageRegister.Text = errorMessage.Message;
            }
            Session["students"] = listStudents;
            labelNumberOfRegisteredCourses.Text = Convert.ToString(selectedStudent.RegisteredCourses.Count);
            labelWeeklyHoursOfRegisteredCourses.Text = Convert.ToString(selectedStudent.TotalWeeklyHours());

        }
        protected void dropdownStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkboxlistCourses.ClearSelection();
            string selectedStudentString = dropdownStudents.SelectedItem.Value;
            string selectedStudentId = selectedStudentString.Split(new[] { " " }, StringSplitOptions.None)[0];
            List<Student> listStudents = (List<Student>)Session["students"];
            Student selectedStudent = null;
            foreach (Student student in listStudents)
            {
                try
                {
                    if (student.Id == Int32.Parse(selectedStudentId))
                    {
                        selectedStudent = student;
                        break;
                    }
                }
                catch (System.FormatException)
                {
                    validatorDropdownStudent.Visible = true;
                    break;
                }
                //if (student.Id == Int32.Parse(selectedStudentId))
                //{
                //    selectedStudent = student;
                //    break;
                //}
            }
            //foreach (Course course in selectedStudent.RegisteredCourses)
            //{
            //    foreach (ListItem itemCourse in checkboxlistCourses.Items)
            //    {
            //        if (course.Code == itemCourse.Value.Split(new[] { " " }, StringSplitOptions.None)[0])
            //        {
            //            itemCourse.Selected = true;
            //        }
            //    }
            //}
            try
            {
                //foreach (Course course in selectedStudent.RegisteredCourses)
                //{
                //    foreach (ListItem itemCourse in checkboxlistCourses.Items)
                //    {
                //        if (course.Code == itemCourse.Value.Split(new[] { " " }, StringSplitOptions.None)[0])
                //        {
                //            itemCourse.Selected = true;
                //        }
                //    }
                //}
                try
                {
                    foreach (Course course in selectedStudent.RegisteredCourses)
                    {
                        foreach (ListItem itemCourse in checkboxlistCourses.Items)
                        {
                            if (course.Code == itemCourse.Value.Split(new[] { " " }, StringSplitOptions.None)[0])
                            {
                                itemCourse.Selected = true;
                            }
                        }
                    }
                }
                catch (System.NullReferenceException)
                {
                    validatorDropdownStudent.Visible = true;
                }
            }
            catch (Exception)
            {
                validatorDropdownStudent.Visible = true;
            }
            labelNumberOfRegisteredCourses.Text = Convert.ToString(selectedStudent.RegisteredCourses.Count);
            labelWeeklyHoursOfRegisteredCourses.Text = Convert.ToString(selectedStudent.TotalWeeklyHours());
        }
    }
}