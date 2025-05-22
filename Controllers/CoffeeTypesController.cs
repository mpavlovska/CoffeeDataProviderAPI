using CoffeeDataProviderAPI.Models;
using CoffeeDataProviderAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeDataProviderAPI.Controllers;

[ApiController]
[Route("api/external-coffee-types")]
public class CoffeeTypesController : ControllerBase
{
    private readonly CoffeeDataService _coffeeDataService;

    public CoffeeTypesController(CoffeeDataService coffeeDataService)
    {
        _coffeeDataService = coffeeDataService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CoffeeType>> Get()
    {
        return Ok(_coffeeDataService.GetAll());
    }
}
