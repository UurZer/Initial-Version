using Int.Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Int.Domain.Entities;

namespace Int.Application.Features.Commands;

public class UpdateCartItemCommand : IRequest<UpdatedCartItemResponse>
{
    public CartItem CartItem { get; set; }

    public class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, UpdatedCartItemResponse>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public UpdateCartItemCommandHandler(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedCartItemResponse> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            CartItem? cartItem= await _cartItemRepository.GetAsync(predicate: b => b.Id == request.CartItem.Id, cancellationToken: cancellationToken);

            await _cartItemRepository.UpdateAsync(cartItem);

            UpdatedCartItemResponse response = _mapper.Map<UpdatedCartItemResponse>(cartItem);

            return response;
        }
    }
}
