﻿using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Questions.Commands.UpdateOptionsQuestion;
internal class UpdateOptionsCommandHandler : IRequestHandler<UpdateOptionsQuestionCommand, OptionsQuestion>
{
    private readonly ApplicationDbContext _context;

    public UpdateOptionsCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<OptionsQuestion> Handle(UpdateOptionsQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _context.OptionsQuestions
            .Include(q => q.Options)
            .FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);

        if (question is null)
            return null;

        question.QuestionText = request.QuestionText;
        question.IsRequired = request.IsRequired;
        question.AllowMultipleChoice = request.AllowMultipleChoice;
        question.Options = request.Options;
        question.Index = request.Index;

        _context.Update(question);
        await _context.SaveChangesAsync(cancellationToken);

        return question;
    }
}