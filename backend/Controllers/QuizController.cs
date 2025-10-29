using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Api.Models;

namespace OnlineQuiz.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly QuizDbContext _db;
    public QuizController(QuizDbContext db) => _db = db;

    [HttpGet("take")]
    public async Task<IActionResult> TakeQuiz(int limit = 10)
    {
        var qs = await _db.Questions.Take(limit).ToListAsync();
        return Ok(qs);
    }

    [HttpPost("submit")]
    public async Task<IActionResult> Submit([FromBody] List<AnswerDto> answers)
    {
        int score = 0;
        foreach (var a in answers)
        {
            var q = await _db.Questions.FindAsync(a.QuestionId);
            if (q != null && q.CorrectOption == a.SelectedOption) score += q.Marks;
        }
        var result = new QuizResult { UserName = answers.FirstOrDefault()?.UserName ?? "Anonymous", Score = score };
        _db.QuizResults.Add(result);
        await _db.SaveChangesAsync();
        return Ok(new { score });
    }
}

public record AnswerDto(int QuestionId, string SelectedOption, string UserName);
