using Int.Application.Services.Repositories;
using AutoMapper;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.Commands;

public class UpdateCartItemCommand : IRequest<UpdatedCartItemResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateLabelCommandHandler : IRequestHandler<UpdateCartItemCommand, UpdatedCartItemResponse>
    {
        private readonly ILabelRepository _labelRepository;
        private readonly IMapper _mapper;

        public UpdateLabelCommandHandler(ILabelRepository labelRepository, IMapper mapper)
        {
            _labelRepository = labelRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedCartItemResponse> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            Label? label = await _labelRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            label = _mapper.Map(request, label);

            await _labelRepository.UpdateAsync(label);

            UpdatedCartItemResponse response = _mapper.Map<UpdatedCartItemResponse>(label);

            return response;
        }
    }
}
