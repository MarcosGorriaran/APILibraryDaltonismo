
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
        const string GetScoresRequestPath = "GetScores";
        const string GetScoreRequestPath = "GetScore/";


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
            return GetScoreRequest(id).GetAwaiter().GetResult();
        }

        public IEnumerable<Session> Get()
        {
            return GetScoreRequest().GetAwaiter().GetResult();
        }
        private async Task<Session> GetScoreRequest<IDValueType>(IDValueType id)
        {
            HttpResponseMessage response = await client.GetAsync(GetScoreRequestPath+id.ToString());
            string requestResponse;
            if (response.IsSuccessStatusCode)
            {
                requestResponse = await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }

            ResponseDTO<Session> responseResult = JsonSerializer.Deserialize<ResponseDTO<Session>>(requestResponse, serializerOptions);

            if (!responseResult.IsSuccess)
            {
                throw new Exception(responseResult.Message);
            }
            return responseResult.Data;
        }
        private async Task<IEnumerable<Session>> GetScoreRequest()
        {
            HttpResponseMessage response = await client.GetAsync(GetScoresRequestPath);
            string requestResponse;
            if (response.IsSuccessStatusCode)
            {
                requestResponse = await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
            
            ResponseDTO<IEnumerable<Session>> responseResult = JsonSerializer.Deserialize<ResponseDTO<IEnumerable<Session>>>(requestResponse,serializerOptions);

            if (!responseResult.IsSuccess)
            {
                throw new Exception(responseResult.Message);
            }
            return responseResult.Data;
        }
        private async Task<Uri> AddScoreRequest(Session scoreData)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(AddScoreRequestPath, scoreData);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        
    }
}
