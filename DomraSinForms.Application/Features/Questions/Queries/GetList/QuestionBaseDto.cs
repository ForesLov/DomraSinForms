using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models.Questions;

namespace DomraSinForms.Application.Features.Questions.Queries.GetList;

public class QuestionBaseDto : IMapWith<QuestionBase>
{
    public string Id { get; set; } = string.Empty;
    public string QuestionText { get; set; } = string.Empty;
    public int Index { get; set; }
    public string Type { get; set; } = string.Empty;
    public bool IsRequired { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<QuestionBase, QuestionBaseDto>()
            .ForMember(dto => dto.Type, opt => opt.MapFrom(q => q.GetType().ToString()));
    }
}