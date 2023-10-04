using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DomraSinForms.Application.Features.Users.Queries.GetUserActionsSummary;
public class GetUserActionsSummaryQuery : IRequest<UsersActionsSummary?>
{
    public string UserId { get; set; }
}
