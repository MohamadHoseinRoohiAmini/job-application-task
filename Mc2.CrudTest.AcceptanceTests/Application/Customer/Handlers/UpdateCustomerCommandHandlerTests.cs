using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Mc2.CrudTest.Application.Commands.Handlers;
using Mc2.CrudTest.Application.Commands.Requests;
using Mc2.CrudTest.Application.Contracts.Repositories;
using Mc2.CrudTest.Application.Contracts.Validators;
using Mc2.CrudTest.Application.Profiles;
using Mc2.CrudTest.Domain.Customer.Exceptions;
using Moq;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Application.Customer.Handlers
{
    public class UpdateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _repository;
        private readonly IMapper _mapper;
        private readonly Fixture fixture;
        private readonly CancellationToken cancellationToken;
        private readonly UpdateCustomerCommandHandler handler;

        public UpdateCustomerCommandHandlerTests()
        {
            _repository = new Mock<ICustomerRepository>();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            fixture = new Fixture();
            cancellationToken = CancellationToken.None;
            handler = new UpdateCustomerCommandHandler(_repository.Object, _mapper);
        }
        [Fact]
        public async Task Should_Throw_CustomerDataNotValidateForCreateException()
        {
            //Arrange
            var command = fixture.Create<UpdateCustomerCommand>();

            //Act
            var result = async () => await handler.Handle(command, cancellationToken);

            //Assert
            await result.Should().ThrowAsync<CustomerDataNotValidateForUpdateException>();
        }

        [Fact]
        public async Task Should_Throw_PhoneNumberException()
        {
            //Arrange
            var command = fixture.Build<UpdateCustomerCommand>()
                                 .With(w => w.Email, "mhroohiamini@gmail.com")
                                 .With(w => w.BankAccountNumber, "1234567890")
                                 .Create();

            //Act
            var result = async () => await handler.Handle(command, cancellationToken);

            //Assert
            await result.Should().ThrowAsync<PhoneNumberException>();
        }
        [Fact]
        public async Task Should_Throw_PhoneNumberNotValidException()
        {
            //Arrange
            var command = fixture.Build<UpdateCustomerCommand>()
                                 .With(w => w.Email, "mhroohiamini@gmail.com")
                                 .With(w => w.BankAccountNumber, "1234567890")
                                 .With(w => w.PhoneNumber, "+989011021716")
                                 .Create();

            //Act
            var result = async () => await handler.Handle(command, cancellationToken);

            //Assert
            await result.Should().ThrowAsync<PhoneNumberNotValidException>();
        }
        [Fact]
        public async Task Should_Update_Successfully()
        {
            //Arrange
            var command = fixture.Build<UpdateCustomerCommand>()
                                 .With(w => w.Email, "mhroohiamini@gmail.com")
                                 .With(w => w.BankAccountNumber, "1234567890")
                                 .With(w => w.PhoneNumber, "+1 (202)-555-1234")
                                 .Create();

            //Act
            var result = await handler.Handle(command, cancellationToken);

            //Assert
            _repository.Verify(v => v.Update(It.IsAny<Domain.Customer.Entities.Customer>()), Times.Once());
        }
    }
}
