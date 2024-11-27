using APILibraryDaltonismo.Model;
using APILibraryDaltonismo.Model.DTO;
using System.Net.Http.Json;
using System.Text.Json;

namespace APILibraryDaltonismo.Controllers
{
    public class PatientController : Controller
    {
        const string CheckLoginPath = "CheckLogin";
        public PatientController(HttpClient httpData) : base(httpData) { }
        public ResponseDTO<Patient> CheckLogin(Patient checkPatientInfo)
        {
            return CheckLoginRequest(checkPatientInfo).GetAwaiter().GetResult();
        }

        private async Task<ResponseDTO<Patient>> CheckLoginRequest(Patient patient)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(CheckLoginPath, patient);
            response.EnsureSuccessStatusCode();
            string responseDTO;
            responseDTO =  await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ResponseDTO<Patient>>(responseDTO);
        }
    }
}
