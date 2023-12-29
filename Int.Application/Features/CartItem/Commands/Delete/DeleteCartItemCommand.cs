using Int.Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Int.Domain.Entities;

namespace Int.Application.Features.Commands;

public class DeleteCartItemCommand : IRequest<DeletedCartItemResponse>
{
    public Guid Id { get; set; }

    public class DeleteLabelCommandHandler : IRequestHandler<DeleteCartItemCommand, DeletedCartItemResponse>
    {
        private readonly ILabelRepository _labelRepository;
        private readonly IMapper _mapper;

        public DeleteLabelCommandHandler(ILabelRepository labelRepository, IMapper mapper)
        {
            _labelRepository = labelRepository;
            _mapper = mapper;
        }
        public async Task<DeletedCartItemResponse> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            Label? label = await _labelRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            await _labelRepository.DeleteAsync(label);

            DeletedCartItemResponse response = _mapper.Map<DeletedCartItemResponse>(label);

            return response;
        }
    }
}
