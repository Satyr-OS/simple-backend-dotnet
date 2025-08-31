using Supabase;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace simple_backend_dotnet.models.Database
{
    [Table("simple-data")]
    public class SimpleData : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("created")]
        public DateTime Created { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public float Price { get; set; }

        [Column("link")]
        public string? Link { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("currency")]
        public string Currency { get; set; }
    }
}