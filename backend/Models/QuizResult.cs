namespace OnlineQuiz.Api.Models;
public class QuizResult
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public int Score { get; set; }
    public DateTime TakenAt { get; set; } = DateTime.UtcNow;
}
