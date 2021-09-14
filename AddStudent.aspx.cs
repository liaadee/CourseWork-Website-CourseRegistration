using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab8.Models;
/*******************************************************************/
/**                                                               **/
/**                                                               **/
/**    Student Name                :  Lia Deng                  **/
/**    EMail Address               :  deng0046@algonquinlive.com         **/
/**    Student Number              : 040958084         **/
/**    Course Number               :  CST8253                   **/
/**    Lab Section Number          : 011                              **/
/**    Professor Name              :  Wei Gong   **/
/**    Assignment Name/Number/Date :    Lab 8                          **/
/**    Optional Comments           :                              **/
/**                                                               **/
/**                                                               **/
/*******************************************************************/

namespace Lab8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null)
            {
                Session["students"] = new List<Student>(); 
            }
        }
        protected void button_Click(object sender, EventArgs e)
        {
            List<Student> listStudents = (List<Student>)Session["students"];
            if (textboxName.Text != "" && dropdownStudentType.SelectedValue != "")
            {
                switch (dropdownStudentType.SelectedValue)
                {
                    case "itemFullTime":
                        FulltimeStudent newFullTimeStudent = new FulltimeStudent(textboxName.Text);
                        listStudents.Add(newFullTimeStudent);
                        break;
                    case "itemPartTime":
                        ParttimeStudent newPartTimeStudent = new ParttimeStudent(textboxName.Text);
                        listStudents.Add(newPartTimeStudent);
                        break;
                    case "itemCoop":
                        CoopStudent newCoopStudent = new CoopStudent(textboxName.Text);
                        listStudents.Add(newCoopStudent);
                        break;
                }
                Session["students"] = listStudents;
            }
            if (listStudents.Count > 0)
            {
                DisplayConfirmedStudents();
            }
            textboxName.Text = ""; 
            dropdownStudentType.SelectedIndex = 0; 
        }

        //!Functions: 
        public void DisplayConfirmedStudents()
        {
            List<Student> listConfirmedStudents = (List<Student>)Session["students"];
            tableConfirmation.Rows.Remove(rowDefault);
            foreach (Student student in listConfirmedStudents)
            {
                TableRow rowConfirmedStudent = new TableRow();
                TableCell cellId = new TableCell();
                cellId.Text = student.Id.ToString();
                TableCell cellName = new TableCell();
                cellName.Text = student.Name; 
                rowConfirmedStudent.Cells.Add(cellId);
                rowConfirmedStudent.Cells.Add(cellName);
                tableConfirmation.Rows.Add(rowConfirmedStudent);
            }
        }
    }
}