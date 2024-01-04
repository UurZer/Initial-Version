using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Int.Application.Features.OrderTransactions.Upsert;
using Int.Application.Features.Queries;
using Int.Domain.Entities;

namespace Int.Application.Features.Profiles;

public class OrderTransactionMappingProfiles : Profile
{
    public OrderTransactionMappingProfiles()
    {
        CreateMap<OrderTransaction, OrderTransactionRequest>().ReverseMap();
        CreateMap<OrderTransaction, GetByIdOrderTransactionResponse>().ReverseMap();
        CreateMap<OrderTransaction, GetListOrderTransactionListItemDto>().ReverseMap();

        CreateMap<Paginate<OrderTransaction>, GetListResponse<GetByIdOrderTransactionResponse>>().ReverseMap();
        CreateMap< Paginate<OrderTransaction>, GetListResponse<GetListOrderTransactionListItemDto>>().ReverseMap();

        //CreateMap<OrderTransaction, UpdateOrderTransactionCommand>().ReverseMap();
        //CreateMap<OrderTransaction, UpdatedOrderTransactionResponse>().ReverseMap();

        //CreateMap<OrderTransaction, DeleteOrderTransactionCommand>().ReverseMap();
        //CreateMap<OrderTransaction, DeletedOrderTransactionResponse>().ReverseMap();

        //CreateMap<OrderTransaction, GetListOrderTransactionListItemDto>()
        //    .ForMember(x => x.OrderTransactionId, opt => opt.MapFrom(y => y.Id))
        //    .ReverseMap();

        //CreateMap<OrderTransaction, OrderTransactionResponse>().ReverseMap();

        //CreateMap<Paginate<OrderTransaction>, GetListResponse<GetListOrderTransactionListItemDto>>()
        //    .ReverseMap();
    }
}
