using CoffeeDataProviderAPI.Data;
using CoffeeDataProviderAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeDataProviderAPI.Controllers;

[ApiController]
[Route("api/external-coffee-types")]
public class CoffeeTypesController : ControllerBase
{
    private readonly CoffeeDataService _data;

    public CoffeeTypesController(CoffeeDataService data)
    {
        _data = data;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CoffeeType>> Get()
    {
        return Ok(_data.GetAll());
    }
}
