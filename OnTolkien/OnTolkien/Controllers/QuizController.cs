using Microsoft.AspNetCore.Mvc;
using OnTolkien.TriviaQuiz;

namespace OnTolkien.Controllers;

public class QuizController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult QuizPage()
    {
        Quiz model = new Quiz();
        return View(model);
    }

    [HttpPost]
    public IActionResult QuizPage(Quiz model, string[] answer)
    {
        for (int i = 0; i < model.Questions.Count; i++)
        {
            model.Questions[i].UserAnswer = answer[i];
            model.Questions[i].IsRight = model.CheckAnswer(model.Questions[i]);
        }
        return View(model);
    }
}