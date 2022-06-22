using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollDbConnection
{
    public class EmployeePayrollModel
    {
        public class EmployeePayroll_Model
        {
            public int empId { get; set; }
            public string empName { get; set; }
            public double salary { get; set; }
            public DateTime startDate { get; set; }
            public string gender { get; set; }
            public decimal mobile { get; set; }
            public string address { get; set; }
            public string department { get; set; }
            public double basicPay { get; set; }
            public double deductions { get; set; }
            public double taxablePay { get; set; }
            public double netPay { get; set; }
        }
    }
}
