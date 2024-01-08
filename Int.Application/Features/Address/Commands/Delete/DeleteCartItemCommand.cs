using Int.Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Int.Domain.Entities;

namespace Int.Application.Features.Commands;

public class DeleteAddressCommand : IRequest<DeletedAddressResponse>
{
    public Guid Id { get; set; }

    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, DeletedAddressResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<DeletedAddressResponse> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            Address? address= await _addressRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

            await _addressRepository.DeleteAsync(address);

            DeletedAddressResponse response = _mapper.Map<DeletedAddressResponse>(address);

            return response;
        }
    }
}
