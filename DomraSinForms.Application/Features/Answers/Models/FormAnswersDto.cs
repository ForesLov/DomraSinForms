using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomraSinForms.Application.Features.Answers.Models;
public class FormAnswersDto
{
    public string FormId { get; set; }
    public IEnumerable<AnswerDto> Answers { get; set; }
}
