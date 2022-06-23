EmployeePayrollDbConnection.EmployeePayrollADO payrollADO = new EmployeePayrollDbConnection.EmployeePayrollADO();
EmployeePayrollDbConnection.EmployeePayrollModel model = new EmployeePayrollDbConnection.EmployeePayrollModel();
Console.WriteLine("Enter your choice for CRUD OPERATION ->");
Console.WriteLine("\t1 - To Establish Db Connection\n\t2 - To add Data to Database\n");
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

}
