using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models.Forms.Questions;
using MediatR;

namespace DomraSinForms.Application.Features.Answers.Commands.SetRightAnswer;
public record SetRightAnswerCommand(string QuestionId, string UserId, QuestionRightAnswer RightAnswer) : IRequest<bool>;
