using Int.Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Int.Domain.Entities;

namespace Int.Application.Features.Commands;

public class DeleteCartItemCommand : IRequest<DeletedCartItemResponse>
{
    public Guid Id { get; set; }

    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, DeletedCartItemResponse>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public DeleteCartItemCommandHandler(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }
        public async Task<DeletedCartItemResponse> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            CartItem? cartItem= await _cartItemRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            await _cartItemRepository.DeleteAsync(cartItem);

            DeletedCartItemResponse response = _mapper.Map<DeletedCartItemResponse>(cartItem);

            return response;
        }
    }
}
