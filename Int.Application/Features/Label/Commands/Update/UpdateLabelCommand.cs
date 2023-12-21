using Int.Application.Services.Repositories;
using AutoMapper;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.Commands;

public class UpdateLabelCommand : IRequest<UpdatedLabelResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateLabelCommandHandler : IRequestHandler<UpdateLabelCommand, UpdatedLabelResponse>
    {
        private readonly ILabelRepository _labelRepository;
        private readonly IMapper _mapper;

        public UpdateLabelCommandHandler(ILabelRepository labelRepository, IMapper mapper)
        {
            _labelRepository = labelRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedLabelResponse> Handle(UpdateLabelCommand request, CancellationToken cancellationToken)
        {
            Label? label = await _labelRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            label = _mapper.Map(request, label);

            await _labelRepository.UpdateAsync(label);

            UpdatedLabelResponse response = _mapper.Map<UpdatedLabelResponse>(label);

            return response;
        }
    }
}
