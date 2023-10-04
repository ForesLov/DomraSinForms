using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Versions;

namespace DomraSinForms.Application.Features.Users.Queries.GetUserActionsSummary;
public class UsersActionsSummary
{
    public IEnumerable<Form> Forms { get; set; }
    public IEnumerable<FormAnswers> FormAnswers { get; set; }
    public IEnumerable<FormVersion> FormVersions { get; set; }
}
