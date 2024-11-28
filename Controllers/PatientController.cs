using APILibraryDaltonismo.Controllers.DAO;
using APILibraryDaltonismo.Model;
using APILibraryDaltonismo.Model.DTO;
using System.Net.Http.Json;
using System.Text.Json;

namespace APILibraryDaltonismo.Controllers
{
    public class PatientController : Controller, ICreate<Patient>
    {
        const string CheckLoginPath = "CheckLogin";
        const string AddPatientPath = "AddPatient";
        
        public PatientController(HttpClient httpData) : base(httpData) { }
        public ResponseDTO<Patient> CheckLogin(Patient checkPatientInfo)
        {
            return CheckLoginRequest(checkPatientInfo).GetAwaiter().GetResult();
        }

        public void Create(Patient info)
        {
            AddPatientRequest(info);
        }

        public void Create(IEnumerable<Patient> infoList)
        {
            foreach(Patient patient in infoList)
            {
                Create(patient);
            }
        }

        private async Task<ResponseDTO<Patient>> CheckLoginRequest(Patient patient)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(CheckLoginPath, patient);
            response.EnsureSuccessStatusCode();
            string responseDTO;
            responseDTO =  await response.Content.ReadAsStringAsync();
            ResponseDTO<Patient> result = JsonSerializer.Deserialize<ResponseDTO<Patient>>(responseDTO, serializerOptions);

            return result;
        }
        private async Task<Uri> AddPatientRequest(Patient patient)
        {
                HttpResponseMessage response = await client.PostAsJsonAsync(AddPatientPath, patient).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return response.Headers.Location;
        }
    }
}
