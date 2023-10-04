using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models;
using DomraSinForms.Domain.Models.Questions;
using DomraSinForms.Domain.Models.Versions;

namespace DomraSinForms.Application.Features.Forms.Queries.GetList;

public class FormDto : IMapWith<Form>
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CreatorId { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public List<QuestionBase> Questions { get; set; } = new();
    public FormVersion? Version { get; set; }
    public bool IsInArchive { get; set; }
    public int AnswersCount { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Form, FormDto>()
            .ForMember(dto => dto.AnswersCount, opt => opt.MapFrom(form => form.FormAnswers.Count))
            .ReverseMap();
    }
}
