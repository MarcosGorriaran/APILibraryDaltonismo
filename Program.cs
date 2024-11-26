using System.Net.Http.Json;

namespace APILibraryDaltonismo
{
    public class Program
    {
        public static void Main()
        {
            
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