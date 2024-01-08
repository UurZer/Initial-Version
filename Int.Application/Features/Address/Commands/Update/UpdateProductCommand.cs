using Int.Application.Services.Repositories;
using AutoMapper;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.Commands;

public class UpdateAddressCommand : IRequest<UpdatedAddressResponse>
{
    public Address Address { get; set; }

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdatedAddressResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedAddressResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            Address? address = await _addressRepository.GetAsync(predicate: b => b.Id == request.Address.Id, cancellationToken: cancellationToken);

            address = _mapper.Map(request, address);

            await _addressRepository.UpdateAsync(address);

            UpdatedAddressResponse response = _mapper.Map<UpdatedAddressResponse>(address);

            return response;
        }
    }
}
