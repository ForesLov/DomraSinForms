﻿using DomraSinForms.Domen.Models;
using DomraSinForms.Domen.Models.Answers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Persistence;
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Form> Forms { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<FormAnswers> FormAnswers { get; set; }
    public DbSet<AnswerBlock> AnswerBlocks { get; set; }
}

