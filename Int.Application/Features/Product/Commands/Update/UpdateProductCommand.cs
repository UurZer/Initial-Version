using Int.Application.Services.Repositories;
using AutoMapper;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.Commands;

public class UpdateProductCommand : IRequest<UpdatedProductResponse>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string LabelCode { get; set; }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            product = _mapper.Map(request, product);

            await _productRepository.UpdateAsync(product);

            UpdatedProductResponse response = _mapper.Map<UpdatedProductResponse>(product);

            return response;
        }
    }
}
