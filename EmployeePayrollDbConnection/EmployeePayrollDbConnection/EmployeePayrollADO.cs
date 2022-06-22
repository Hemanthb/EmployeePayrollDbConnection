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
    }
}
