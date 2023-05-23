using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models.Answers;
using DomraSinForms.Domain.Models.Versions;

namespace DomraSinForms.Application.Answers.Queries.GetList;

public class FormAnswersDto : IMapWith<FormAnswers>
{
    public string Id { get; set; } = string.Empty;
    public string FormId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public List<Answer> Answers { get; set; } = new();
    public string UserNick { get; set; } = string.Empty;
    public FormVersion? FormVersion { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<FormAnswers, FormAnswersDto>()
            .ForMember(dto => dto.UserNick, opt => opt.MapFrom(fa => fa.User.NickName))
            .ForMember(dto => dto.FormVersion, opt => opt.MapFrom(fa => fa.FormVersion ?? null))
            .ReverseMap();
    }
}
