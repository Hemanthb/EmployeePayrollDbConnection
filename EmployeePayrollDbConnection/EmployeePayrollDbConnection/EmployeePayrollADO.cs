using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollDbConnection
{
    public class EmployeePayrollADO
    {
        public static string connectionString = "Data Source = (localdb)\\MSSQLLOCALDB;Initial Catalog = EmployeePayrollDatabase;";
        SqlConnection connection = new SqlConnection(connectionString);
        public int threadCount = 0;

        //To establish Connection
        public void GetConnection()
        {
            try
            {
                DataSet data = new DataSet();
                using (this.connection)
                {
                    string sql = "SELECT * FROM Employee_Payroll";
                    this.connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, this.connection);
                    adapter.Fill(data);
                    this.connection.Close();
                    Console.WriteLine("Connection Established");
                    
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        //To Insert or add new data
        public void AddData(EmployeePayrollModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                lock (this)
                {
                    using (connection)
                    {
                        SqlCommand command = new SqlCommand("spEmployee_Payroll_AddData", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EmpName", model.EmpName);
                        command.Parameters.AddWithValue("@EmpPhNo", model.EmpPhNo);
                        command.Parameters.AddWithValue("@EmpAddress", model.EmpAddress);
                        command.Parameters.AddWithValue("@EmpDept", model.EmpDept);
                        command.Parameters.AddWithValue("@StartDate", model.StartDate);
                        command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                        command.Parameters.AddWithValue("@Deductions", model.Deductions);
                        command.Parameters.AddWithValue("@IncomeTax", model.IncomeTax);
                        command.Parameters.AddWithValue("@NetPay", model.NetPay);
                        command.Parameters.AddWithValue("@Gender", model.Gender);
                        connection.Open();
                        var result = command.ExecuteNonQuery();
                        if (result != 0)
                        {
                            Console.WriteLine("Added a new Data succesfully!!");
                            return;
                        }
                        Console.WriteLine("New Data not Added!!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //To retrieve and display data
        public void RetrieveData()
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Employee_Payroll", connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine(row["EmpId"] + ",  " + row["Empname"] + ",  " + row["EmpDept"]+", " + row["NetPay"]);
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //To update a table
        public void UpdateDatabase(string empName, string phNo)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("spEmployee_Payroll_UpdateData", Connection);
                    command.CommandType = CommandType.StoredProcedure;
                    Connection.Open();
                    command.Parameters.AddWithValue("@EmpName", empName);
                    command.Parameters.AddWithValue("@EmpPhNo", phNo);
                    var result = command.ExecuteNonQuery();
                    Connection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Row Updated Successfully");
                        return;
                    }
                    Console.WriteLine("Row Not Updated!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            
        }
        //To delete a row or data from a table
        public void DeleteData(string name)
        {
            try
            {
                using (SqlConnection Connection = new SqlConnection(connectionString))
                {
                    string sql = "DELETE FROM Employee_Payroll WHERE EmpName = '"+name+"'";
                    SqlCommand Command = new SqlCommand(sql, Connection);
                    Connection.Open();
                    var result = Command.ExecuteNonQuery();
                    Connection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Data is Deleted Successfully");
                        return;
                    }
                    Console.WriteLine("Data is not Deleted!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AddMultipleEmployees(List<EmployeePayrollModel> model)
        {
            model.ForEach(data =>
            {
                Console.WriteLine("Employees being Added");
                this.AddData(data);
                Console.WriteLine("Employees Added " + data.EmpName);
            });
        }
        public void AddMultipleEmployeesUsingThread(List<EmployeePayrollModel> model)
        {
            model.ForEach(data =>
            {
                
                Thread thread = new Thread(() =>
                {
                    
                    Console.WriteLine("Thread Start Time: " + DateTime.Now);
                    this.AddData(data);
                    Console.WriteLine("Employee Added: " + data.EmpName);
                    Console.WriteLine("Thread End Time: " + DateTime.Now);
                });
                thread.Start();
                Console.WriteLine("Thread -> " + thread.ManagedThreadId);
            });
        }
    }
}
