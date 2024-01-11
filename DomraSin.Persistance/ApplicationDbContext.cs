﻿using DomraSin.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DomraSin.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormAnswers> FormAnswers { get; set; }
        public DbSet<FormItem> FormItems { get; set; }
        public DbSet<ScoreType> ScoreTypes{ get; set; }
        public DbSet<PictureItem> PictureItems { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Form>()
                .HasMany(fa => fa.FormAnswers)
                .HasOne(fa => fa.Form)
                .HasForeignKey(fa => fa.FormId)                
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Form>()
                .HasMany(fa => fa.Question)
                .WithOne()
                .HasForeignKey(fa => fa.FormId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
