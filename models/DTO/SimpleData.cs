namespace simple_backend_dotnet.models.DTO
{
    public class SimpleData
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public string Currency { get; set; }
    }
}