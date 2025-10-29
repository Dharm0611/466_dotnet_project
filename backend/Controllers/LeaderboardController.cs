using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Api.Models;

namespace OnlineQuiz.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LeaderboardController : ControllerBase
{
    private readonly QuizDbContext _db;
    public LeaderboardController(QuizDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetTop([FromQuery]int top = 10)
    {
        var list = await _db.QuizResults.OrderByDescending(r => r.Score).ThenBy(r => r.TakenAt).Take(top).ToListAsync();
        return Ok(list);
    }
}
