using FluentValidation;

namespace DomraSinForms.Application.Features.Forms.Queries.GetList
{
    public class GetFormListQueryValidator : AbstractValidator<GetFormListQuery>
    {
        public GetFormListQueryValidator()
        {
            RuleFor(q => q.Page).GreaterThanOrEqualTo(0);
            RuleFor(q => q.Count).GreaterThanOrEqualTo(0);
        }
    }
}
