using Microsoft.EntityFrameworkCore;
using OnlineQuiz.Api.Models;

namespace OnlineQuiz.Api;
public class QuizDbContext : DbContext
{
    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<QuizResult> QuizResults => Set<QuizResult>();
}
