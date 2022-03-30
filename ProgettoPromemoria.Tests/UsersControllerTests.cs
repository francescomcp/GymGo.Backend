namespace ProgettoPromemoria.Tests;

using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using ProgettoPromemoria.Core.Controllers;
using ProgettoPromemoria.Core.Services;

public class UsersControllerTests
{
    public UserController _controller;

    [SetUp]
    public void init()
    {
        var service = new Mock<IUserService>();
        _controller = new UserController(service.Object);
    }

    [Test]
    public void GetByIdTest()
    {
        var result = _controller.GetById("0");
        Assert.AreEqual(result, Results.NotFound());
    }
}
