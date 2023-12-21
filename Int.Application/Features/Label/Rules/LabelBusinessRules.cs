using Int.Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Int.Domain.Entities;
using Int.Application.Features.Constants;

namespace Int.Application.Features.Rules;

public class LabelBusinessRules : BaseBusinessRules
{
    private readonly ILabelRepository _productRepository;

    public LabelBusinessRules(ILabelRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task LabelCodeCannotBeDuplicatedWhenInserted(string code)
    {
        Label? result = await _productRepository.GetAsync(predicate: b => b.Code.ToLower() == code.ToLower());

        if (result != null)
        {
            throw new BusinessException(LabelMessages.LabelCodeExists);
        }
    }
}
