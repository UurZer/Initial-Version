using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Int.Application.Features.Rules;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.Commands;
public class CreateLabelCommand : IRequest<CreatedLabelResponse>, ITransactionalRequest
{
    #region [ Model ]

    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string LabelUType { get; set; }

    public int Level { get; set; }

    public Guid? ParentLabelId { get; set; }

    public string? ParentLabelCode { get; set; }

    public string? ImageUrl { get; set; }

    #endregion

    public class CreateLabelCommandHandler : IRequestHandler<CreateLabelCommand, CreatedLabelResponse>
    {
        private readonly ILabelRepository _labelRepository;
        private readonly IMapper _mapper;
        private readonly LabelBusinessRules _labelBusinessRules;

        public CreateLabelCommandHandler(ILabelRepository labelRepository, IMapper mapper, LabelBusinessRules labelBusinessRules)
        {
            _labelRepository = labelRepository;
            _mapper = mapper;
            _labelBusinessRules = labelBusinessRules;
        }

        public async Task<CreatedLabelResponse>? Handle(CreateLabelCommand request, CancellationToken cancellationToken)
        {
            await _labelBusinessRules.LabelCodeCannotBeDuplicatedWhenInserted(request.Code);

            Label label = _mapper.Map<Label>(request);
            Guid parentLabelId;

            label.Id = Guid.NewGuid();

            if(string.IsNullOrEmpty(label.Code))
                label.Code = Guid.NewGuid().ToString();

            if (!string.IsNullOrEmpty(label.ParentLabelCode))
            {
                parentLabelId = _labelRepository.GetAsync(x => x.Code == label.ParentLabelCode).Result.Id;
                label.ParentLabelId = parentLabelId;
            }

            await _labelRepository.AddAsync(label);

            CreatedLabelResponse createdLabelResponse = _mapper.Map<CreatedLabelResponse>(label);
            return createdLabelResponse;
        }
    }
}
