using AutoFixture;
using Moq;
using PizzaBurgerHouse.Application.Commands.OrderCommand;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PizzaBurgerHouse.Application.Tests.Commands.OrderCommand
{
    public  class CreateOrderTests      
    {
        [Fact]
        public async void ItShould_Create_Order()
        {
            //Arrange
            var mockRopo = new Mock<IOrderRepository>();
            var expected = new Fixture().Create<Task<OrderConfirmation>>();
            mockRopo.Setup(x => x.CreateOrderAsync(It.IsAny<Order>())).Returns(expected);
            //act
            Order order = new Order();
            CreateOrder createOrder = new CreateOrder(order);
            var sut = new CreateOrderCommandHandler(mockRopo.Object);
            var actual = await sut.Handle(createOrder, new CancellationToken());
            //Assert
            mockRopo.VerifyAll();
            Assert.NotNull(actual);
        }
    }
}
