using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Core.Persistence.Paging;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.Commands;
public class CreateCartItemCommand : IRequest<List<CreatedCartItemResponse>>, ITransactionalRequest
{
    #region [ Model ]
    public List<CartItem> CartItems { get; set; }

    public Guid? CartId { get; set; }
    public Guid UserId { get; set; }

    #endregion

    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, List<CreatedCartItemResponse>>
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

        public async Task<List<CreatedCartItemResponse>> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {
            List<CartItem> cartItems = _mapper.Map<List<CartItem>>(request.CartItems);
            Paginate<CartItem> currentCartItems = new Paginate<CartItem>();
            Paginate<Cart> currentCarts = new Paginate<Cart>();
            CartItem cartItem;
            Cart cart;


            #region [ Cart ]

            if (!request.CartId.HasValue)
            {
                cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    UserId = request.UserId
                };

                await _cartRepository.AddAsync(cart);
                currentCarts = await _cartRepository.GetListAsync(predicate: x => x.UserId == request.UserId
                                                                              && x.Id != cart.Id,
                                                                cancellationToken: cancellationToken);
                await _cartRepository.DeleteAsync(currentCarts.Items.ToList());
            }
            else
            {
                cart = await _cartRepository.GetAsync(x => x.Id == request.CartId);

                if (cart == null)
                {
                    cart = new Cart
                    {
                        Id = Guid.NewGuid(),
                        UserId = request.UserId
                    };

                    await _cartRepository.AddAsync(cart);
                }
            }

            #endregion

            #region [ Cart Item ]

            if (!request.CartId.HasValue)
            {
                List<CartItem> myCartItems = new List<CartItem>();
                foreach (CartItem item in cartItems)
                {
                    var myCartİtem = myCartItems.Where(x => x.ProductId == item.ProductId).FirstOrDefault();
                    if (myCartİtem != null)
                    {
                        myCartItems.Remove(myCartİtem);
                        myCartİtem.Quantity += item.Quantity;
                        myCartItems.Add(myCartİtem);
                    }
                    else
                    {
                        item.CartId = cart.Id;
                        item.Id = Guid.NewGuid();
                        myCartItems.Add(item);
                    }
                }
                await _cartItemRepository.AddRangeAsync(myCartItems);
            }
            else
            {
                currentCartItems = await _cartItemRepository.GetListAsync(x => x.CartId == cart.Id);

                if (currentCartItems != null && currentCartItems.Count != 0)
                {
                    List<CartItem> deletedCartItems = _mapper.Map<List<CartItem>>(currentCartItems.Items);
                    await _cartItemRepository.DeleteAsync(deletedCartItems);
                }
                List<CartItem> myCartItems = new List<CartItem>();
                foreach (CartItem item in cartItems)
                {
                    var myCartİtem = myCartItems.Where(x => x.ProductId == item.ProductId).FirstOrDefault();
                    if (myCartİtem != null)
                    {
                        myCartItems.Remove(myCartİtem);
                        myCartİtem.Quantity += item.Quantity;
                        myCartItems.Add(myCartİtem);
                    }
                    else
                    {
                        item.CartId = cart.Id;
                        item.Id = Guid.NewGuid();
                        myCartItems.Add(item);
                    }
                }
                await _cartItemRepository.AddRangeAsync(myCartItems);
            }

            #endregion

            List<CreatedCartItemResponse> createdCartItemResponse = _mapper.Map<List<CreatedCartItemResponse>>(cartItems);
            return createdCartItemResponse;
        }
    }
}
