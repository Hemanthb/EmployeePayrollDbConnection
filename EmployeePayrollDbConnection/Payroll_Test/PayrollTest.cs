namespace Payroll_Test
{
    [TestClass]
    public class PayrollTest
    {
        EmployeePayrollDbConnection.EmployeePayrollADO payroll = new EmployeePayrollDbConnection.EmployeePayrollADO();
        [TestMethod]
        public void GivenMultipleEmployeeDetails_AddEmpDetailsWithAndWithoutThread_ShouldReturnTatalExecutionTime()
        {
            List<EmployeePayrollDbConnection.EmployeePayrollModel> empList = new List<EmployeePayrollDbConnection.EmployeePayrollModel>();
            empList.Add(new EmployeePayrollDbConnection.EmployeePayrollModel(empId: 1, empName: "Sreyas", startDate: new DateTime(2022, 06, 01), gender: "M", empPhNo: "9877065432", empAddress: "Calicut", empDept: "Developer", basicPay: 20000, deductions: 200, incomeTax: 500, netPay: 19500));
            empList.Add(new EmployeePayrollDbConnection.EmployeePayrollModel(empId: 2, empName: "Aparna", startDate: new DateTime(2022, 05, 01), gender: "F", empPhNo: "9877065132", empAddress: "kannur", empDept: "Developer", basicPay: 25000, deductions: 300, incomeTax: 700, netPay: 24000)); 
        
            DateTime startTime = DateTime.Now;
            payroll.AddMultipleEmployees(empList);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Time Taken: " + (endTime - startTime));

            DateTime startTimeWithThreading = DateTime.Now;
            payroll.AddMultipleEmployeesUsingThread(empList);
            DateTime endTimeWithThreading = DateTime.Now;
            Console.WriteLine("Time Taken with Threading: " + (endTimeWithThreading - startTimeWithThreading));
        }
    }
}