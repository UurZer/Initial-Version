using Int.Application.Services.Repositories;
using AutoMapper;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.Queries;

public class GetByIdLabelQuery : IRequest<GetByIdLabelResponse>
{
    public Guid Id { get; set; }

    public class GetByIdLabelQueryHandler : IRequestHandler<GetByIdLabelQuery, GetByIdLabelResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILabelRepository _productRepository;

        public GetByIdLabelQueryHandler(IMapper mapper, ILabelRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<GetByIdLabelResponse> Handle(GetByIdLabelQuery request, CancellationToken cancellationToken)
        {
            Label? product = await _productRepository.GetAsync(predicate: b => b.Id == request.Id, withDeleted: true, cancellationToken: cancellationToken);

            GetByIdLabelResponse response = _mapper.Map<GetByIdLabelResponse>(product);

            return response;
        }
    }
}
