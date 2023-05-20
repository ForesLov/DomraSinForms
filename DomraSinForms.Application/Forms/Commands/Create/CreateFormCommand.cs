using AutoMapper;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models;
using MediatR;

namespace DomraSinForms.Application.Forms.Commands.Create;
public class CreateFormCommand : IRequest<Form>, IMapWith<Form>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool AllowAnonymous { get; set; }
    public string CreatorId { get; set; } = string.Empty;
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateFormCommand, Form>()
            .ForMember(f => f.Title, opt => opt.MapFrom(c => c.Title))
            .ForMember(f => f.Description, opt => opt.MapFrom(c => c.Description))
            .ForMember(f => f.CreatorId, opt => opt.MapFrom(c => c.CreatorId));
    }
}
