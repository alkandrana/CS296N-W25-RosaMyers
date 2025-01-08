using OnTolkien.TriviaQuiz;
namespace OnTolkienTests;

public class QuizTests
{
    Quiz _quiz = new Quiz();
    
    public QuizTests()
    {
        _quiz.Questions[0].UserAnswer = "Bilbo Baggins";
        _quiz.Questions[1].UserAnswer = "The Elven-smiths of Eregion";
        _quiz.Questions[2].UserAnswer = "Frodo Baggins";
        _quiz.Questions[3].UserAnswer = "smaug";
    }

    [Fact]
    public void CheckAddAnswer()
    {
        Assert.Equal("Bilbo Baggins", _quiz.Questions[0].Answers[0]);
        Assert.Equal("The Elven-smiths of Eregion", _quiz.Questions[1].Answers[1]);
        Assert.Equal("Anduril", _quiz.Questions[2].Answers[0]);
    }
    [Fact]
    public void CheckCorrectAnswer()
    {
        // Arrange is done in the Constructor
        
        // Act
        bool isCorrect = _quiz.CheckAnswer(_quiz.Questions[0]);
        
        // Assert
        Assert.True(isCorrect);
    }

    [Fact]
    public void CheckWrongAnswer()
    {
        // Arrange is done in the constructor
        
        // Act
        bool isCorrect = _quiz.CheckAnswer(_quiz.Questions[2]);
        
        // Assert
        Assert.False(isCorrect);
    }

    [Fact]
    public void CheckCorrectAnswerInSecondIteration()
    {
        bool isCorrect = _quiz.CheckAnswer(_quiz.Questions[1]);
        Assert.True(isCorrect);
    }

    [Fact]
    public void CheckLowerCaseAnswer()
    {
        bool isCorrect = _quiz.CheckAnswer(_quiz.Questions[3]);
        Assert.True(isCorrect);
    }

    [Fact]
    public void CheckNumberOfQuestions()
    {
        //Arrange is done in the constructor
        
        // No act needed
        
        // Assert
        Assert.Equal(10, _quiz.Questions.Count);
    }
    
}