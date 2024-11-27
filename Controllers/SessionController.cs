
using APILibraryDaltonismo.Controllers.DAO;
using APILibraryDaltonismo.Model;
using APILibraryDaltonismo.Model.DTO;
using System.Text.Json;

namespace APILibraryDaltonismo.Controllers
{
    public class SessionController : ICreate<Session>, IRead<Session>
    {
        HttpClient client;
        public void Create(Session info)
        {
            throw new NotImplementedException();
        }

        public void Create(IEnumerator<Session> infoList)
        {
            throw new NotImplementedException();
        }

        public Session Get<IDValueType>(IDValueType id)
        {
            throw new NotImplementedException();
        }

        public Session Get()
        {
            return GetScoreRequest().GetAwaiter().GetResult();
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
    }
}
