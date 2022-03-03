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
    public Task SaveWithoutExpirationTest()
    {
        var item = new PostMemoRequest { Description = "Prova", Name = "Prova" };
        var result = _controller.Save(item);
        Assert.IsInstanceOf<PostMemoRequest>(item);
        return Task.CompletedTask;
    }
}
