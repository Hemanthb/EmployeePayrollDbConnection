EmployeePayrollDbConnection.EmployeePayrollADO payrollADO = new EmployeePayrollDbConnection.EmployeePayrollADO();
EmployeePayrollDbConnection.EmployeePayrollModel model = new EmployeePayrollDbConnection.EmployeePayrollModel();
Console.WriteLine("Enter your choice for CRUD OPERATION ->");
Console.WriteLine("\t1 - To Establish Db Connection\n\t2 - To add Data to Database\n\t3 - Retrieve & Display Employee details\n" +
    "\t4 - Update Employee Database\n\t5 - To Delete a Data\n\t6 - To Add MultipleEmployees Using Thread&Synchronisation\n");
int choice = Convert.ToInt32(Console.ReadLine());
switch (choice)
{
    case 1:
        payrollADO.GetConnection();
        break;
    case 2:
        Console.WriteLine("Enter Employee Name");
        model.EmpName = Console.ReadLine();
        Console.WriteLine("Enter Employee Gender");
        model.Gender = Console.ReadLine(); ;
        Console.WriteLine("Enter Phone Number");
        model.EmpPhNo = Console.ReadLine();
        Console.WriteLine("Enter Employee Address");
        model.EmpAddress = Console.ReadLine(); ;
        Console.WriteLine("Enter Employee Department");
        model.EmpDept = Console.ReadLine();
        Console.WriteLine("Enter a Year,Month,Date");
        model.StartDate = Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Enter Basic Pay");
        model.BasicPay = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Dedutions");
        model.Deductions = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Taxable Pay");
        model.IncomeTax = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter Net Pay");
        model.NetPay = Convert.ToDouble(Console.ReadLine());
        payrollADO.AddData(model);
        break;
    case 3:
        payrollADO.RetrieveData();
        break;
    case 4:
        Console.WriteLine("Enter the name of person whose phone No has to be updated");
        string name = Console.ReadLine();
        Console.WriteLine("Enter New Phone Number:");
        string phNo = Console.ReadLine();
        payrollADO.UpdateDatabase(name, phNo);
        break;
    case 5:
        Console.WriteLine("Enter the name of person whose Data has to be Deleted");
        string empName = Console.ReadLine();
        payrollADO.DeleteData(empName);
        break;
    case 6:
        List<EmployeePayrollDbConnection.EmployeePayrollModel> empList = new List<EmployeePayrollDbConnection.EmployeePayrollModel>();
        empList.Add(new EmployeePayrollDbConnection.EmployeePayrollModel(empId: 1, empName: "Sreyas", startDate: new DateTime(2022, 06, 01), gender: "M", empPhNo: "9877065432", empAddress: "Calicut", empDept: "Developer", basicPay: 20000, deductions: 200, incomeTax: 500, netPay: 19500));
        empList.Add(new EmployeePayrollDbConnection.EmployeePayrollModel(empId: 2, empName: "Aparna", startDate: new DateTime(2022, 05, 01), gender: "F", empPhNo: "9877065132", empAddress: "kannur", empDept: "Developer", basicPay: 25000, deductions: 300, incomeTax: 700, netPay: 24000));
        payrollADO.AddMultipleEmployeesUsingThread(empList);
        break;
}
