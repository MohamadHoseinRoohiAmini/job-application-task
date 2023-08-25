using AutoFixture;
using AutoMapper;
using com.google.i18n.phonenumbers;
using FluentAssertions;
using libphonenumber;
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
    public class CreateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _repository;
        private readonly IMapper _mapper;
        private readonly Mock<com.google.i18n.phonenumbers.PhoneNumberUtil> mockPhoneNumberUtil;
        private readonly Fixture fixture;
        private readonly CancellationToken cancellationToken;
        private readonly CreateCustomerCommandHandler handler;

        public CreateCustomerCommandHandlerTests()
        {
            _repository = new Mock<ICustomerRepository>();
            mockPhoneNumberUtil = new Mock<com.google.i18n.phonenumbers.PhoneNumberUtil>();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            fixture = new Fixture();
            cancellationToken = CancellationToken.None;
            handler = new CreateCustomerCommandHandler(_repository.Object, _mapper, mockPhoneNumberUtil.Object);
        }
        [Fact]
        public async Task Should_Throw_CustomerDataNotValidateForCreateException()
        {
            //Arrange
            var command = fixture.Create<CreateCustomerCommand>();
            
            //Act
            var result = async () => await handler.Handle(command, cancellationToken);

            //Assert
            await result.Should().ThrowAsync<CustomerDataNotValidateForCreateException>();
        }

        [Fact]
        public async Task Should_Throw_PhoneNumberNotValidException()
        {
            //Arrange
            var command = fixture.Build<CreateCustomerCommand>()
                                 .With(w => w.Email, "mhroohiamini@gmail.com")
                                 .With(w => w.BankAccountNumber, "1234567890")
                                 .Create();

            var mockPhoneNumberUtil = new Mock<com.google.i18n.phonenumbers.PhoneNumberUtil>();
            mockPhoneNumberUtil.Setup(m => m.parse(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new PhoneNumber
                {
                    CountryCode = 1,
                    NationalNumber = 1234567890
                });
            mockPhoneNumberUtil.Verify(m => m.parse("+1-234-567-890", "US"), Times.Once);
            var handler = new CreateCustomerCommandHandler(_repository.Object, _mapper, mockPhoneNumberUtil.Object);
            //Act
            var result = async () => await handler.Handle(command, cancellationToken);

            //Assert
            await result.Should().ThrowAsync<PhoneNumberNotValidException>();
        }
    }
}
