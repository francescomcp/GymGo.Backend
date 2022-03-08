using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProgettoPromemoria.Controllers;
using ProgettoPromemoria.Core.Services;
using ProgettoPromemoria.Gateway.Models.Memo;
using System.Threading.Tasks;

namespace ProgettoPromemoria.Tests;

public class MemoControllerTests
{
    public MemoController _controller;

    [SetUp]
    public void init()
    {
        var service = new Mock<IMemoService>();
        _controller = new MemoController(service.Object);
    }

    [Test]
    public Task HealthCheckTest()
    {
        var check = _controller.HealthCheck();
        Assert.IsNotNull(check);
        return Task.CompletedTask;
    }

    [Test]
    public async Task SaveWithoutExpirationTest()
    {
        var item = new PostMemoRequest { Description = "Prova", Name = "Prova" };
        var result = await _controller.Save(item) as OkObjectResult;
        Assert.IsNotNull(result);
    }

    [Test]
    public async Task GetAllTest()
    {
        var result = await _controller.GetAll();
        Assert.IsNotNull(result);
    }

    [Test]
    public async Task GetByIdTest()
    {
        var result = await _controller.GetById("62189db5dfb5cfb27a965f3c");
        Assert.IsNotNull(result);
    }
}
