using APILibraryDaltonismo.Controllers;
using APILibraryDaltonismo.Model;
using APILibraryDaltonismo.Model.DTO;
using System.Net.Http.Json;
using System.Text.Json;

namespace APILibraryDaltonismo
{
    public class Program
    {
        static HttpClient client;
        static JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        public static void Main()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000");
            /*Console.WriteLine(CheckLoginTest(new Patient()
            {
                DNI = Console.ReadLine() ?? String.Empty,
                Password = Console.ReadLine() ?? String.Empty
            }));
            Console.WriteLine(GetSessionsTest());
            Console.WriteLine(GetSessionTest());
            */
            AddSessionTest(new Session()
            {
                ColorBlindType = "none",
                DateGame = DateTime.Now,
                player = new Patient()
                {
                    DNI = "11111112G"
                }
            });
            AddPatientTest(new Patient()
            {
                DNI= Console.ReadLine() ?? String.Empty,
                Password= Console.ReadLine() ?? String.Empty,
                BirthDate = DateTime.Now,
                City = "SOMEWHERE",
                Country = "NOWHERE",
                Name = "DALTONICPerson"
            });
        }
        public static string CheckLoginTest(Patient checkPatient)
        {
            PatientController patController = new PatientController(client);
            ResponseDTO<Patient> patient = patController.CheckLogin(checkPatient);
            return JsonSerializer.Serialize(patient,serializerOptions);
        }
        public static string GetSessionsTest()
        {
            SessionController sessionController = new SessionController(client);
            Session[] sesions = sessionController.Get().ToArray();
            return JsonSerializer.Serialize(sesions, serializerOptions);
        }
        public static string GetSessionTest()
        {
            SessionController sessionController = new SessionController(client);
            Session sesion = sessionController.Get("1");
            return JsonSerializer.Serialize(sesion, serializerOptions);
        }
        public static void AddSessionTest(Session session)
        {
            SessionController sessionController = new SessionController(client);
            
            sessionController.Create(session);
        }
        public static void AddPatientTest(Patient patient)
        {
            PatientController patientController = new PatientController(client);
            patientController.Create(patient);
        }
    }
}