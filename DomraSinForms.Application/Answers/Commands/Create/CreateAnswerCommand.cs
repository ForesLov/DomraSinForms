using DomraSinForms.Domen.Models;
using DomraSinForms.Domen.Models.Answers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Answers.Commands.Create;

public class CreateAnswerCommand: IRequest<FormAnswers>
{
    public List<AnswerBlock> Answers;
    public string FormId;
    public string UserId;
}
