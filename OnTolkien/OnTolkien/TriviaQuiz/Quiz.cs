using System.Runtime.CompilerServices;

namespace OnTolkien.TriviaQuiz;

public class Quiz
{
    private List<Question> _questions = new List<Question>();

    public Quiz()
    {
        _questions.Add(new Question()
        {
            Q = "What is the name of Frodo's uncle, who possessed the One Ring before him?"
        });
        _questions[0].AddAnswer("Bilbo Baggins");
        _questions[0].AddAnswer("Bilbo");
        _questions.Add(new Question()
        {
            Q = "Which race of beings created the Rings of Power?"
        });
        _questions[1].AddAnswer("The Elves");
        _questions[1].AddAnswer("The Elven-smiths of Eregion");
        _questions.Add(new Question()
        {
            Q = "What is the name of Aragorn's sword?"
        });
        _questions[2].AddAnswer("Anduril");
        _questions.Add(new Question()
        {
            Q = "What is the name of the dragon in The Hobbit?"
        });
        _questions[3].AddAnswer("Smaug");
        _questions.Add(new Question()
        {
            Q = "The wizard known to the Elves as Mithrandir is more commonly known as?"
        });
        _questions[4].AddAnswer("Gandalf");
        _questions[4].AddAnswer("Gandalf the Grey");

        _questions.Add(new Question()
        {
            Q = "What is the name of the elvish realm ruled by Galadriel and Celeborn?"
        });
        _questions[5].AddAnswer("Lothlorien");

        _questions.Add(new Question()
        {
            Q = "Who is the creator of Arda (the world) in Tolkien's mythology?"
        });
        _questions[6].AddAnswer("Eru Iluvatar");
        _questions[6].AddAnswer("Iluvatar");

        _questions.Add(new Question()
        {
            Q = "What is the name of the writing system used by the Elves?"
        });
        _questions[7].AddAnswer("Tengwar");

        _questions.Add(new Question()
        {
            Q = "What is the name of the capital city of Gondor?"
        });
        _questions[8].AddAnswer("Minas Tirith");

        _questions.Add(new Question()
        {
            Q = "Who is the leader of the Balrogs, also known as the Lord of the Balrogs?"
        });
        _questions[9].AddAnswer("Gothmog");
    }

    public List<Question> Questions
    {
        get
        {
            return _questions;
        }
    }

    public bool CheckAnswer(Question answer)
    {
        bool result = false;
        foreach (string ans in answer.Answers)
        {
            // checking for null so that we don't get weird errors if the user doesn't enter any input
            if (answer.UserAnswer != null && ans.ToLower() == answer.UserAnswer.ToLower())
            {
                result = true;
            }
        }
        return result;
    }
}