using AutoMapper;
using Mc2.CrudTest.Application.Commands.Requests;
using Mc2.CrudTest.Application.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Commands.Handlers
{
    public class CreateCustomerRequestCommandHandler : IRequestHandler<CreateCustomerRequestCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CreateCustomerRequestCommandHandler(ICustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateCustomerRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new 
        }
    }
}
