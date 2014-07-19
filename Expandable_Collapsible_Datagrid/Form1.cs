using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Expandable_Collapsible_Datagrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Parent table
            DataTable dtStudent = new DataTable();
            dtStudent.Columns.Add("Student_ID", typeof(int));
            dtStudent.Columns.Add("Student_Name", typeof(string));
            dtStudent.Columns.Add("Student_RollNo", typeof(string));

            //Child Table
            DataTable dtStudentMarks = new DataTable();
            dtStudentMarks.Columns.Add("Student_ID", typeof(int));
            dtStudentMarks.Columns.Add("Subject_ID", typeof(int));
            dtStudentMarks.Columns.Add("Subject_Name", typeof(string));
            dtStudentMarks.Columns.Add("Marks", typeof(int));

            //adding rows
            dtStudent.Rows.Add(111, "Halle Berry", "0123456789");
            dtStudent.Rows.Add(222, "Nicole Kidman", "9876012345");
            dtStudent.Rows.Add(333, "Viola Davis", "001122334455");
            dtStudent.Rows.Add(444, "Ryan Goesling", "9988776655");

            //adding rows
            dtStudentMarks.Rows.Add(111, "01", "History", 98);
            dtStudentMarks.Rows.Add(111, "02", "Physics", 75);
            dtStudentMarks.Rows.Add(111, "03", "Maths", 69);
            dtStudentMarks.Rows.Add(111, "01", "C#", 97);

            dtStudentMarks.Rows.Add(222, "01", "English", 98);
            dtStudentMarks.Rows.Add(222, "02", "Economy", 75);
            dtStudentMarks.Rows.Add(222, "03", "C#", 69);
            dtStudentMarks.Rows.Add(222, "01", "History", 97);


            // add both tables to the dataset
            DataSet dsDataSet = new DataSet();
            dsDataSet.Tables.Add(dtStudent);
            dsDataSet.Tables.Add(dtStudentMarks);

            // define relationship between master and child
            DataRelation Data_tablerelation = new DataRelation("Details Mark", dsDataSet.Tables[0].Columns[0], dsDataSet.Tables[1].Columns[0], true);
            dsDataSet.Relations.Add(Data_tablerelation);
            dataGrid1.DataSource = dsDataSet.Tables[0];
        }
    }
}
