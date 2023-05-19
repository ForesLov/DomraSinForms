using DomraSinForms.Domain.Identity;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Questions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Persistence;
public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Form> Forms { get; set; }
    public DbSet<QuestionBase> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<FormAnswers> FormAnswers { get; set; }
    public DbSet<Answer> AnswerBlocks { get; set; }
    public DbSet<TextQuestion> TextQuestions { get; set; }
    public DbSet<OptionsQuestion> OptionsQuestions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Form>()
            .HasMany<FormAnswers>(fa => fa.FormAnswers)
            .WithOne()
            .HasForeignKey(fa => fa.FormId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Entity<Form>()
            .HasMany<QuestionBase>(fa => fa.Questions)
            .WithOne()
            .HasForeignKey(qb => qb.FormId)
            .OnDelete(DeleteBehavior.Cascade);

        /*builder
            .Entity<QuestionBase>()
            .HasMany<Answer>(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId).IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);*/

        builder
            .Entity<Answer>()
            .HasOne(a => a.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Entity<FormAnswers>()
            .HasMany<Answer>(fa => fa.Answers)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Entity<OptionsQuestion>()
            .HasMany<QuestionOption>(q => q.Options)
            .WithOne(q => q.Question)
            .HasForeignKey(q => q.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(builder);
    }
}

