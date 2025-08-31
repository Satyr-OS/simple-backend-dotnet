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
            res.Add(new models.DTO.SimpleData()
            {
                Id = item.Id,
                Created = item.Created,
                Name = item.Name,
                Price = item.Price,
                Links = await ImageUrls(item.Link, supabase),
                Description = item.Description,
                Currency = item.Currency
            });
        }

        return res;
    }

    private static async Task<List<string>> ImageUrls(string? link, Supabase.Client supabase)
    {
        List<string> urls = [];

        if (link is null) return urls;

        var files = await supabase.Storage.From(link).List() ?? [];

        foreach (var file in files)
        {
            if (file.Name is null) continue;

            string? url = supabase.Storage.From(link).GetPublicUrl(file.Name);

            if (url is null) continue;

            urls.Add(url);
        }

        return urls;
    }
}
