using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class Employee
    {
        public Employee()
        {

        }
        [Key]
        public int EmpID { get; set; }

        [StringLength(20)]
        public string EmpName { get; set; }


        [StringLength(20)]
        public string Department{ get; set; }

        public double Salary { get; set; }

        [StringLength(20)]
        public string Test { get; set; }

    }
}
