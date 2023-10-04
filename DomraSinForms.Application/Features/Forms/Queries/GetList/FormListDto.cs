namespace DomraSinForms.Application.Features.Forms.Queries.GetList;

#nullable disable

public class FormListDto
{
    public IEnumerable<FormDto> Forms { get; set; }
    public int PageCount { get; set; }
    public GetFormListQuery Query { get; set; }
}
