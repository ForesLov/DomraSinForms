using DomraSinForms.Domain.Identity;
using DomraSinForms.Domain.Interfaces.Repositories;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Forms.Questions;
using DomraSinForms.Domain.Models.Forms.Questions.Types;
using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Domain.Models.Versions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Persistence;
public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>, IDatabaseContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Form> Forms { get; set; }
    public DbSet<FormVersion> FormVersions { get; set; }
    public DbSet<QuestionBase> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<FormAnswers> FormAnswers { get; set; }
    public DbSet<Answer> AnswerBlocks { get; set; }
    public DbSet<TextQuestion> TextQuestions { get; set; }
    public DbSet<OptionsQuestion> OptionsQuestions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<QuestionRightAnswer> QuestionRightAnswers { get; set; }
    //public override DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Form>()
            .HasMany(fa => fa.FormAnswers)
            .WithOne(fa => fa.Form)
            .HasForeignKey(fa => fa.FormId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Entity<Form>()
            .HasMany(fa => fa.Questions)
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
            .HasMany(fa => fa.Answers)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
        /*builder
            .Entity<FormAnswers>()
            .HasOne(fa => fa.FormVersion)
            .WithMany()
            .HasForeignKey(fa => fa.FormVersionId)
            .OnDelete(DeleteBehavior.NoAction);*/

        builder
            .Entity<OptionsQuestion>()
            .HasMany(q => q.Options)
            .WithOne(q => q.Question)
            .HasForeignKey(q => q.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Entity<User>()
            .ToTable(nameof(Users));

        base.OnModelCreating(builder);
    }
}

