using AutoMapper;
using Mc2.CrudTest.Application.Commands.Requests;
using Mc2.CrudTest.Application.Contracts.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Commands.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.Get(request.UpdateDto.Id);

            _mapper.Map(request.UpdateDto, customer);

            await _customerRepository.Update(customer);

            return Unit.Value;
        }
    }
}
