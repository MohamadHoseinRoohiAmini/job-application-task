using AutoFixture;
using FluentAssertions;
using Mc2.CrudTest.Application.Commands.Handlers;
using Mc2.CrudTest.Application.Commands.Requests;
using Mc2.CrudTest.Application.Contracts.Repositories;
using Mc2.CrudTest.Domain.Customer.Exceptions;
using Moq;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Application.Customer.Handlers
{
    public class DeleteCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _repository;
        private readonly Fixture fixture;
        private readonly DeleteCustomerCommandHandler handler;
        public DeleteCustomerCommandHandlerTests()
        {
            _repository = new Mock<ICustomerRepository>();

            fixture = new Fixture();
            handler = new DeleteCustomerCommandHandler(_repository.Object);
        }

        [Fact]
        public async Task Should_Throw_CustomerNotFoundException()
        {
            //Arrange
            var customer = fixture.Create<Domain.Customer.Entities.Customer>();
            var command = fixture.Create<DeleteCustomerCommand>();

            //Act
            var result = async () => await handler.Handle(command, default);

            //Assert
            result.Should().ThrowAsync<CustomerNotFoundException>().WithMessage($"Id : {command.Id}");
        }

        [Fact]
        public async Task Should_Work()
        {
            //Arrange
            var customer = fixture.Create<Domain.Customer.Entities.Customer>();
            var command = new DeleteCustomerCommand
            {
                Id = customer.Id
            };
            _repository.Setup(s => s.Get(command.Id)).Returns(Task.FromResult(customer));
            

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            _repository.Verify(v=>v.HardDelete(customer),Times.Once());
        }
    }
}
