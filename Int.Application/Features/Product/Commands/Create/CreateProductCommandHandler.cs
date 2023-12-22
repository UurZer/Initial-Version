using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Int.Application.Features.Rules;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.Commands;
public class CreateProductCommand : IRequest<CreatedProductResponse>, ITransactionalRequest
{
    #region [ Model ]

    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal UnitPrice { get; set; }

    public string? ImageUrl { get; set; }

    public string? LabelId { get; set; }

    public string LabelCode { get; set; }

    #endregion

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILabelRepository _labelRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _productBusinessRules;

        public CreateProductCommandHandler(IProductRepository productRepository, ILabelRepository labelRepository, IMapper mapper, ProductBusinessRules productBusinessRules)
        {
            _productRepository = productRepository;
            _labelRepository = labelRepository;
            _productBusinessRules = productBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedProductResponse>? Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Guid labelId;

            await _productBusinessRules.ProductCodeCannotBeDuplicatedWhenInserted(request.Code, request.LabelCode);

            Product product = _mapper.Map<Product>(request);
            product.Id = Guid.NewGuid();


            if (string.IsNullOrEmpty(product.Code))
                product.Code = Guid.NewGuid().ToString();

            if (!string.IsNullOrEmpty(product.LabelCode))
            {
                labelId = _labelRepository.GetAsync(x => x.Code == product.LabelCode).Result.Id;
                product.LabelId = labelId;
            }

            await _productRepository.AddAsync(product);

            CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(product);
            return createdProductResponse;
        }
    }
}
