using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Api.Models;

namespace OnlineQuiz.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly QuizDbContext _db;
    public QuestionsController(QuizDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _db.Questions.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Question q)
    {
        _db.Questions.Add(q);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = q.Id }, q);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var q = await _db.Questions.FindAsync(id);
        if (q == null) return NotFound();
        return Ok(q);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var q = await _db.Questions.FindAsync(id);
        if (q == null) return NotFound();
        _db.Questions.Remove(q);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
