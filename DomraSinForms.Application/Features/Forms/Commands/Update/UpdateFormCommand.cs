using AutoMapper;
using DomraSinForms.Application.Interfaces;
using DomraSinForms.Application.Mapper;
using DomraSinForms.Domain.Models;

namespace DomraSinForms.Application.Features.Forms.Commands.Update
{
    public class UpdateFormCommand : IUpdateRequest<Form?>, IMapWith<Form>
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Form, UpdateFormCommand>()
                .ReverseMap();
        }
    }
}