using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Mc2.CrudTest.Application.Contracts.Repositories;
using Mc2.CrudTest.Application.Profiles;
using Mc2.CrudTest.Application.Queries.Handlers;
using Mc2.CrudTest.Application.Queries.Requests;
using Moq;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Application.Customer.Queries
{
    /*
     * Hello, good day. Thank you for your interest in my application. 
     * I am sending you a small and simple test sample that shows how I write tests for my codes and what tools I use. 
     * I am currently working on a project at the company where I am employed, and we are in the piloting phase.
     * I have a tight deadline for this project, so I apologize for the delay in submitting this test.
     * This test is not comprehensive and has some limitations, but I hope it gives you an idea of my skills and abilities.
     */
    public class GetCustomerRequestHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _repository;
        private readonly Fixture fixture;
        public GetCustomerRequestHandlerTest()
        {
            _repository = new Mock<ICustomerRepository>();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            fixture = new Fixture();
        }

        [Fact]
        public async Task GetCustomer()
        {
            //Arrange
            var handler = new GetCustomerRequestHandler(_repository.Object, _mapper);
            var command = fixture.Create<GetCustomerRequest>();
            var customer = fixture.Build<Domain.Customer.Entities.Customer>().With(w => w.Id == command.Id).Create();
            _repository.Setup(s => s.Get(command.Id)).Returns(Task.FromResult(customer));
            //Act
            var result = await handler.Handle(command, default);

            result.Should().NotBeNull();
            result.FirstName.Should().Be(customer.FirstName);
            result.LastName.Should().Be(customer.LastName);
            // And etc
        }        
    }
}
