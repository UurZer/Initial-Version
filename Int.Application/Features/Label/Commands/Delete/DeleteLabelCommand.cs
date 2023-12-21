using Int.Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Int.Domain.Entities;

namespace Int.Application.Features.Commands;

public class DeleteLabelCommand : IRequest<DeletedLabelResponse>
{
    public Guid Id { get; set; }

    public class DeleteLabelCommandHandler : IRequestHandler<DeleteLabelCommand, DeletedLabelResponse>
    {
        private readonly ILabelRepository _labelRepository;
        private readonly IMapper _mapper;

        public DeleteLabelCommandHandler(ILabelRepository labelRepository, IMapper mapper)
        {
            _labelRepository = labelRepository;
            _mapper = mapper;
        }
        public async Task<DeletedLabelResponse> Handle(DeleteLabelCommand request, CancellationToken cancellationToken)
        {
            Label? label = await _labelRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            await _labelRepository.DeleteAsync(label);

            DeletedLabelResponse response = _mapper.Map<DeletedLabelResponse>(label);

            return response;
        }
    }
}
