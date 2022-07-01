using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace Rest_Sharp_TestCases
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
    [TestClass]
    public class RestSharpTest
    {
        RestClient restClient;
        [TestInitialize]
        public void setup()
        {
            restClient = new RestClient("http://localhost:4000");
        }
        
        [TestMethod]
        public void OnCallingGetMethod_ReturnEmployeeList()
        {
            //Arrange
            RestRequest request = new RestRequest("/employees", Method.Get);
            //Act
            RestResponse response = restClient.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(8, list.Count);
            foreach (Employee data in list)
            {
                Console.WriteLine("{0,-5}{1,-15}{2,-10}", data.Id, data.Name, data.Salary);
            }

        }
    }
}