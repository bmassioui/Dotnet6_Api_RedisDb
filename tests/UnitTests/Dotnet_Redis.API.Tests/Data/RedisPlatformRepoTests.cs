using System;
using Dotnet_Redis.API.Data;
using Dotnet_Redis.API.Models;
using Moq;
using StackExchange.Redis;
using Xunit;

namespace Dotnet_Redis.API.Tests.Data;

public class RedisPlatformRepoTests
{
    private readonly RedisPlatformRepo _redisPlatformRepo;
    private readonly Mock<IConnectionMultiplexer> _connectionMultiplexer;
    public RedisPlatformRepoTests()
    {
        _connectionMultiplexer = new Mock<IConnectionMultiplexer>();
        _redisPlatformRepo = new RedisPlatformRepo(_connectionMultiplexer.Object);

        // Setup 
        _connectionMultiplexer.Setup(_ => _.IsConnected).Returns(false);
    }

    /// <summary>
    /// Creat method should throw ArgumentOutOfRangeException when the Platform is NULL
    /// </summary>
    [Fact]
    public void Create_Should_Throw_ArgumentOutOfRangeException()
    {
        // Arrange
        Platform? platform = null;

        // Act
        Action action = () => _redisPlatformRepo.Create(platform);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

}
