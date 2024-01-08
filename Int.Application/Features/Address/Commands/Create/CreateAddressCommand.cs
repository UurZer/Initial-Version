using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Core.Persistence.Context;
using Int.Application.Services.Repositories;
using Int.Domain.Entities;
using MediatR;

namespace Int.Application.Features.Commands;
public class CreateAddressCommand : IRequest<CreatedAddressResponse>, ITransactionalRequest
{
    #region [ Model ]
    public Guid? UserId { get; set; }

    public string Building { get; set; }

    public string City { get; set; }

    public string Destination { get; set; }

    public bool IsDefault { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string PostalCode { get; set; }

    public string State { get; set; }

    public string Street { get; set; }

    #endregion

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreatedAddressResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<CreatedAddressResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            request.UserId = CoreContext.Current.User.Id;

            Address address = _mapper.Map<Address>(request);
            await _addressRepository.AddAsync(address);

            CreatedAddressResponse createdAddressResponse = _mapper.Map<CreatedAddressResponse>(address);
            return createdAddressResponse;
        }
    }
}
