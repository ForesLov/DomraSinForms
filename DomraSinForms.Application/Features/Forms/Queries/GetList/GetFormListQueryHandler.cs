using AutoMapper;
using DomraSinForms.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DomraSinForms.Application.Forms.Queries.GetList
{
    public class GetFormListQueryHandler : IRequestHandler<GetFormListQuery, FormListDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFormListQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FormListDto> Handle(GetFormListQuery request, CancellationToken cancellationToken)
        {
            var result = new FormListDto
            {
                Query = request,
            };

            var forms = _context.Forms
                .Where(f => f.CreatorId == request.UserId)
                .Where(f => f.Title.Contains(request.SearchText) | f.Description.Contains(request.SearchText))
                .Order(request.OrderBy);

            result.PageCount = (int)Math.Round(
                (double)forms.Count() / (double)request.Count, MidpointRounding.ToPositiveInfinity);

            result.Forms = await _mapper.ProjectTo<FormDto>(
                forms
                    .Skip(request.Page * request.Count)
                    .Take(request.Count))
                .ToArrayAsync();

            return result;
        }
    }
}
