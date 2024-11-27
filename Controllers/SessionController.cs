
using APILibraryDaltonismo.Controllers.DAO;
using APILibraryDaltonismo.Model;
using APILibraryDaltonismo.Model.DTO;
using System.Net.Http.Json;
using System.Text.Json;

namespace APILibraryDaltonismo.Controllers
{
    public class SessionController : Controller, ICreate<Session>, IRead<Session>
    {
        const string AddScoreRequestPath = "AddScore";


        public SessionController(HttpClient httpData) : base(httpData) {}
        public void Create(Session info)
        {
            AddScoreRequest(info);
        }

        public void Create(IEnumerable<Session> infoList)
        {
            foreach(Session info in infoList)
            {
                AddScoreRequest(info);
            }
        }

        public Session Get<IDValueType>(IDValueType id)
        {
            throw new NotImplementedException();
        }

        public Session Get()
        {
            return GetScoreRequest().GetAwaiter().GetResult();
        }
        public void AddScoreSession(Session session)
        {
            
        }

        private async Task<Session> GetScoreRequest()
        {
            HttpResponseMessage response = await client.GetAsync(
                "GetScores");
            ResponseDTO<Session> deserializeRequest = new ResponseDTO<Session>();
            string requestResponse;
            if (response.IsSuccessStatusCode)
            {
                requestResponse = await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
            
            return JsonSerializer.Deserialize<ResponseDTO<Session>>(requestResponse).Data;
        }
        private async Task<Uri> AddScoreRequest(Session scoreData)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(AddScoreRequestPath, scoreData);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
    }
}
