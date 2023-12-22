using Int.Application.Services.Repositories;
using AutoMapper;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.Queries;

public class GetByLevel : IRequest<LabelResponse>
{
    public string LabelUType { get; set; }

    public int Level { get; set; }

    public class GetByLevelQueryHandler : IRequestHandler<GetByLevel, LabelResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILabelRepository _productRepository;

        public GetByLevelQueryHandler(IMapper mapper, ILabelRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<LabelResponse> Handle(GetByLevel request, CancellationToken cancellationToken)
        {
            Label? product = await _productRepository.GetAsync((x => x.LabelUType == request.LabelUType && x.Level == request.Level), withDeleted: true, cancellationToken: cancellationToken);

            LabelResponse response = _mapper.Map<LabelResponse>(product);

            return response;
        }
    }
}
