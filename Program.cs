using APILibraryDaltonismo.Controllers;
using APILibraryDaltonismo.Model;
using APILibraryDaltonismo.Model.DTO;
using System.Net.Http.Json;
using System.Text.Json;

namespace APILibraryDaltonismo
{
    public class Program
    {
        public static void Main()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            PatientController patController = new PatientController(client);
            SessionController sessionController = new SessionController(client);
            ResponseDTO<Patient> patient = patController.CheckLogin(new Patient()
            {
                DNI = Console.ReadLine() ?? String.Empty,
                Password = Console.ReadLine() ?? String.Empty
            });
            Console.WriteLine(JsonSerializer.Serialize(patient));
            Console.WriteLine(Request().GetAwaiter().GetResult());
        }
        public static async Task<string> Request()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            HttpResponseMessage response = await client.GetAsync(
                "GetScores");
            string requestResponse = "";
            if (response.IsSuccessStatusCode)
            {
                requestResponse = await response.Content.ReadAsStringAsync();
            }
            return requestResponse;
        }
    }
}