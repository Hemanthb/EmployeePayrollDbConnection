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
        public DataSet GetConnection()
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
                    return data;
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

        public void AddData(EmployeePayrollModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void RetrieveData()
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
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
        }
    }
}
