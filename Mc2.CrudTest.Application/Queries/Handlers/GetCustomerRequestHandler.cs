using AutoMapper;
using Mc2.CrudTest.Application.Contracts.Repositories;
using Mc2.CrudTest.Application.Queries.Requests;
using Mc2.CrudTest.Domain.Customer.Dtoes;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Queries.Handlers
{
    public class GetCustomerRequestHandler : IRequestHandler<GetCustomerRequest, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerRequestHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.Get(request.Id);
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
