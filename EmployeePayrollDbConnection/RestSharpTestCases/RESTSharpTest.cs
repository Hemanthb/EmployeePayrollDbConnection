using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace RestSharpTestCases
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
    }
    [TestClass]
    public class RESTSharpTest
    {
        RestClient client;

        [TestMethod]
        public void OnCallingGetMethod_ShouldReturnEmployeeList()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            RestRequest request = new RestRequest("/employees", Method.Get);
            //Act
            RestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(9, list.Count);
            foreach (Employee data in list)
            {
                Console.WriteLine("{0,-5}{1,-15}{2,-10}", data.Id, data.Name, data.Salary);

            }
        }
        [TestMethod]
        public void OnPostingEmployeeData_ShouldAddtoJsonServer()
        {
            client = new RestClient("http://localhost:4000");
            //Arrange
            RestRequest request = new RestRequest("/employees", Method.Post);
            var body = new Employee { Name = "Krishnan", Salary = "45000" };
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            //Act
            RestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Employee data = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Krishnan", data.Name);
            Assert.AreEqual("45000", data.Salary);
            Console.WriteLine(response.Content);
        }
    }
}