

namespace APILibraryDaltonismo.Controllers
{
    public abstract class Controller
    {
        protected HttpClient client { get; private set;}

        public Controller(HttpClient client)
        {
            this.client = client;
        }
    }
}
