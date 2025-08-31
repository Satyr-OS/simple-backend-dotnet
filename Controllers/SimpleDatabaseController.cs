using Microsoft.AspNetCore.Mvc;

using simple_backend_dotnet.Helpers;

namespace simple_backend_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class SimpleDatabaseController : ControllerBase
{
    [HttpGet(Name = "GetAll")]
    public async Task<IEnumerable<models.DTO.SimpleData>> Get()
    {
        var supabase = await Database.Initialize();
        var result = await supabase.From<models.Database.SimpleData>().Get();

        var items = result.Models.ToList().OrderBy(i => i.Id);

        var res = new List<models.DTO.SimpleData>();
        foreach (var item in items)
        {
            List<Supabase.Storage.FileObject> files = [];
            List<string?> urls = [];

            if (item.Link is not null)
            {
                var tempfiles = await supabase.Storage.From(item.Link).List();
                if (tempfiles is not null)
                {
                    files = tempfiles;
                }

                foreach (var file in files)
                {
                    var url = supabase.Storage.From(item.Link).GetPublicUrl(file.Name ?? "");
                    urls.Add(url);
                }
            }

            res.Add(new models.DTO.SimpleData()
            {
                Id = item.Id,
                Created = item.Created,
                Name = item.Name,
                Price = item.Price,
                Links = urls,
                Description = item.Description,
                Currency = item.Currency
            });
        }

        return res;
    }
}
