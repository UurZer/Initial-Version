using Int.Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Int.Domain.Entities;

namespace Int.Application.Features.Commands;

public class DeleteProductCommand : IRequest<DeletedProductResponse>
{
    public Guid Id { get; set; }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, DeletedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<DeletedProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            await _productRepository.DeleteAsync(product);

            DeletedProductResponse response = _mapper.Map<DeletedProductResponse>(product);

            return response;
        }
    }
}
