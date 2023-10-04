using MediatR;

namespace DomraSinForms.Application.Features.Forms.Queries.GetList;

public class GetFormListQuery : IRequest<FormListDto>
{
    public int Page { get; set; } = 0;
    public int Count { get; set; } = 10;
    public string SearchText { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public FormOrderApproach OrderBy { get; set; } = FormOrderApproach.LastUpdateDescending;
}

public enum FormOrderApproach
{
    Creation = 1,
    CreationDescending,
    LastUpdate,
    LastUpdateDescending,
    Title,
    TitleDescending,
}