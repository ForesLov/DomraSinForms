using DomraSinForms.Domain.Models;

namespace DomraSinForms.Application.Forms.Queries.GetList;
public static class FormOrderExtension
{
    public static IOrderedQueryable<Form> Order(this IQueryable<Form> source, FormOrderApproach orderBy)
    {
        switch (orderBy)
        {
            case FormOrderApproach.Creation:
                return source.OrderBy(f => f.CreationDate);
            case FormOrderApproach.CreationDescending:
                return source.OrderByDescending(f => f.CreationDate);
            case FormOrderApproach.LastUpdate:
                return source.OrderBy(f => f.LastUpdateDate);
            case FormOrderApproach.LastUpdateDescending:
                return source.OrderByDescending(f => f.LastUpdateDate);
            case FormOrderApproach.Title:
                return source.OrderBy(f => f.Title);
            case FormOrderApproach.TitleDescending:
                return source.OrderByDescending(f => f.Title);
            default:
                return source.OrderBy(f => f.Id);
        }
    }
}


