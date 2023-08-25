using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Mc2.CrudTest.Application.Contracts.Repositories;
using Mc2.CrudTest.Application.Profiles;
using Mc2.CrudTest.Application.Queries.Handlers;
using Mc2.CrudTest.Application.Queries.Requests;
using Mc2.CrudTest.Domain.Customer.Exceptions;
using Moq;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Application.Customer.Queries
{
    public class GetCustomerRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _repository;
        private readonly Fixture fixture;
        private readonly GetCustomerRequestHandler handler;
        public GetCustomerRequestHandlerTest()
        {
            _repository = new Mock<ICustomerRepository>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            fixture = new Fixture();
            handler = new GetCustomerRequestHandler(_repository.Object, _mapper);
        }

        [Fact]
        public async Task GetCustomer()
        {
            //Arrange
            var customer = fixture.Create<Domain.Customer.Entities.Customer>();
            var command = new GetCustomerRequest
            {
                Id = customer.Id
            };
            _repository.Setup(s => s.Get(command.Id)).Returns(Task.FromResult(customer));

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            result.Should().NotBeNull();
            result.FirstName.Should().Be(customer.FirstName);
            result.LastName.Should().Be(customer.LastName);
            result.Email.Should().Be(customer.Email);
            result.PhoneNumber.Should().Be(customer.PhoneNumber);
            result.BankAccountNumber.Should().Be(customer.BankAccountNumber);
            result.DateOfBirth.Should().Be(customer.DateOfBirth);
        }

        [Fact]
        public async Task Should_Throw_CustomerNotFoundException()
        {
            //Arrange
            var customer = fixture.Create<Domain.Customer.Entities.Customer>();
            var command = fixture.Create<GetCustomerRequest>();

            //Act
            var result = async () => await handler.Handle(command, default);

            //Assert
            result.Should().ThrowAsync<CustomerNotFoundException>().WithMessage($"Id : {command.Id}");
        }
    }
}
