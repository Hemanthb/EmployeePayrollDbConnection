using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollDbConnection
{
    public class EmployeePayrollModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public string EmpPhNo { get; set; }
        public string EmpAddress { get; set; }
        public string EmpDept { get; set; }
        public double BasicPay { get; set; }
        public double Deductions { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }
        
    }
}
