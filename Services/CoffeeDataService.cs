using CoffeeDataProviderAPI.Models;
using System.Text.Json;

namespace CoffeeDataProviderAPI.Services;

public class CoffeeDataService
{
    private readonly IWebHostEnvironment _env;
    private List<CoffeeType>? _coffeeTypes;

    public CoffeeDataService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public IEnumerable<CoffeeType> GetAll()
    {
        if (_coffeeTypes is not null) return _coffeeTypes;

        var path = Path.Combine(_env.ContentRootPath, "coffee-types.json");

        if (!File.Exists(path))
            return Enumerable.Empty<CoffeeType>();

        var json = File.ReadAllText(path);
        _coffeeTypes = JsonSerializer.Deserialize<List<CoffeeType>>(json);

        return _coffeeTypes ?? Enumerable.Empty<CoffeeType>();
    }
}
