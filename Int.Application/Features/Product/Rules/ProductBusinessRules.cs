using Int.Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Int.Domain.Entities;
using Int.Application.Features.Constants;

namespace Int.Application.Features.Rules;

public class ProductBusinessRules : BaseBusinessRules
{
    private readonly IProductRepository _productRepository;

    public ProductBusinessRules(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task ProductCodeCannotBeDuplicatedWhenInserted(string code)
    {
        Product? result = await _productRepository.GetAsync(predicate: b => b.Code.ToLower() == code.ToLower());

        if (result != null)
        {
            throw new BusinessException(ProductsMessages.ProductCodeExists);
        }
    }
}
