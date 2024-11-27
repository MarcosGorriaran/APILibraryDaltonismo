namespace APILibraryDaltonismo.Controllers.DAO
{
    public interface IRead<Model>
    {
        public Model Get<IDValueType>(IDValueType id);
        public Model Get();
    }
}
