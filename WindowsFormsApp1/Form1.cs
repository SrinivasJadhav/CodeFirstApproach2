using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using(var db = new CodeFirstModel())
            {
                var emp = new Employee { EmpName = "Srini 4",Department = "Tech"};
                db.Employees.Add(emp);
                db.SaveChanges();
            }
        }

        private void BtnGet_Click(object sender, EventArgs e)
        {
            using(var db = new CodeFirstModel())
            {       
                var emp = (from objEmp in db.Employees
                           select objEmp).ToList<Employee>();

                foreach(Employee getEmp in emp)
                {
                    MessageBox.Show(getEmp.EmpName);
                }
            }
        }
    }
}
