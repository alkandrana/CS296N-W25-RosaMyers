using Microsoft.AspNetCore.Mvc;
using OnTolkien.Controllers;
using OnTolkien.Data;
using OnTolkien.Models;
using Xunit.Abstractions;
namespace OnTolkienTests;

public class StoryControllerTests
{
    IStoryRepository _repo = new FakeStoryRepository();
    HomeController _controller;
    Story _story = new Story();
    ITestOutputHelper _output;

    public StoryControllerTests(ITestOutputHelper output)
    {
        _output = output;
        _controller = new HomeController(_repo);
    }

    [Fact]
    public void Message_PostTest_Success()
    {
        // arrange
        // Done in the constructor

        // act
        _story.Contributor = new AppUser();
        var result = _controller.Story(_story);

        // assert
        // Check to see if I got a RedirectToActionResult
        Assert.True(result.GetType() == typeof(RedirectToActionResult));
    }

    [Fact]
    public void Review_PostTest_Failure()
    {
        // arrange
        // Done in the constructor

        // act
        var result = _controller.Story(_story);

        // assert
        // Check to see if I got a RedirectToActionResult
        Assert.True(result.GetType() == typeof(ViewResult));
    }
}