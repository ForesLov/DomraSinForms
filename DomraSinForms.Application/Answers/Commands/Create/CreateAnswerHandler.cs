using DomraSinForms.Domen.Models;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Answers.Commands.Create
{
    public class CreateAnswerHandler: IRequestHandler<CreateAnswerCommand, FormAnswers>
    {
        private readonly ApplicationDbContext _context;
        public CreateAnswerHandler(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<FormAnswers> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
        {
            var form = await _context.Forms
                .Include(f => f.FormAnswers)
                .FirstOrDefaultAsync(f => f.Id == request.FormId, cancellationToken);
            if (form == null)
            {
                return null;
            }
            var answers = new FormAnswers 
            { Answers = request.Answers };
            form.FormAnswers.Add(answers);
            _context.Update(form);
            await _context.SaveChangesAsync(cancellationToken);
            return answers;
        }
    }
}
