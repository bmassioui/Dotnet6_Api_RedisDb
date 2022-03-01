using Microsoft.AspNetCore.Mvc;
using Dotnet_Redis.API.Data;
using Dotnet_Redis.API.Models;
namespace Dotnet_Redis.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo _repository;

    public PlatformsController(IPlatformRepo repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Get Platforms
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IEnumerable<Platform>> GetPlatforms()
    {
        return Ok(_repository.Get());
    }

    /// <summary>
    /// Get by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}", Name = "GetById")]
    public ActionResult<IEnumerable<Platform>> GetById(string id)
    {

        var platform = _repository.GetById(id);

        if (platform != null)
        {
            return Ok(platform);
        }

        return NotFound();
    }

    /// <summary>
    /// Create a Platform
    /// </summary>
    /// <param name="platform"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<Platform> Post(Platform platform)
    {
        _repository.Create(platform);

        return CreatedAtRoute(nameof(GetById), new { Id = platform.Id }, platform);
    }
}
