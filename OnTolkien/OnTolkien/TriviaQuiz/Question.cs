namespace OnTolkien.TriviaQuiz;

public class Question
{
    private List<String> _answers = new List<String>();
    public string? Q { get; set; }

    public List<String> Answers
    {
        get
        {
            return _answers;
        }
    }
    public string? UserAnswer { get; set; }
    
    public bool IsRight { get; set; } // was the user's answer right?

    public void AddAnswer(string answer)
    {
        _answers.Add(answer);
    }
}