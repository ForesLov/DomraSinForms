using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Application.Features.Answers.Models;
using MediatR;

namespace DomraSinForms.Application.Features.Answers.Commands.Fill;
public record FillCommand(FormAnswersDto FormAnswers, string UserId) : IRequest<bool>;
