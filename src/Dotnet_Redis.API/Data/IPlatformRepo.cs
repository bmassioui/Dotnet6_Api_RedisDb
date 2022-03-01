using Dotnet_Redis.API.Models;
namespace Dotnet_Redis.API.Data;

public interface IPlatformRepo
{
    /// <summary>
    /// Create new Plateform
    /// </summary>
    /// <param name="plat"></param>
    void Create(Platform plat);

    /// <summary>
    /// Get Platform by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Platform? GetById(string id);

    /// <summary>
    /// Get Plateforms
    /// </summary>
    /// <returns></returns>
    IEnumerable<Platform?>? Get();
}
