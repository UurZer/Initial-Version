using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Core.Persistence.Paging;
using Int.Application.Features.Rules;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.Commands;
public class CreateCartItemCommand : IRequest<CreatedCartItemResponse>, ITransactionalRequest
{
    #region [ Model ]
    public List<CartItem> CartItems { get; set; }

    public Guid? CartId { get; set; }
    public Guid UserId { get; set; }

    #endregion

    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, CreatedCartItemResponse>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CreateCartItemCommandHandler(ICartItemRepository cartItemRepository, ICartRepository cartRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCartItemResponse> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {
            Paginate<CartItem> currentCartItems = new Paginate<CartItem>();
            CartItem cartItem = _mapper.Map<CartItem>(request);
            Cart cart;

            #region [ Cart ]

            if (!request.CartId.HasValue)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = request.UserId
                };
            }
            else
            {
                cart = _cartRepository.Get(x => x.Id == request.CartId);

                if(cart == null)
                {
                    cart = new Cart
                    {
                        Id = Guid.NewGuid(),
                        UserId = request.UserId
                    };
                }
            }

            await _cartRepository.AddAsync(cart);

            #endregion

            #region [ Cart Item ]

            if (!request.CartId.HasValue)
            {
                cartItem.CartId = cart.Id;
            }
            else
            {
                currentCartItems = _cartItemRepository.GetList(x => x.CartId == request.CartId);

                if(currentCartItems != null && currentCartItems.Count != 0) 
                {
                    List<CartItem> deletedCartItems = _mapper.Map<List<CartItem>>(currentCartItems.Items);
                    await _cartItemRepository.DeleteAsync(deletedCartItems);
                }
            }

            await _cartItemRepository.AddAsync(cartItem);

            #endregion


            CreatedCartItemResponse createdCartItemResponse = _mapper.Map<CreatedCartItemResponse>(cartItem);
            return createdCartItemResponse;
        }
    }
}
