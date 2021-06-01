using AutoFixture;
using Moq;
using PizzaBurgerHouse.Application.Queries.OrderQueries;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PizzaBurgerHouse.Application.Tests.Queries.OrderQueries
{
    public class GetDeliveryOrderByIdTests
    {
        [Fact]
        public async void It_Should_Get_Delivery_Order_By_Id()
        {
            // Arrange
            var mockOrders = new Mock<IOrderRepository>();
            var expected = new Fixture().Create<Task<Order>>();
            mockOrders.Setup(x => x.GetDeliveryOrderByIdAsync(It.IsAny<int>())).Returns(expected);
            //Act
            var sut = new GetDeliveryOrderByIdHandler(mockOrders.Object);
            GetDeliveryOrderById byIdQuery = new GetDeliveryOrderById(It.IsAny<int>());
            var actual =  await sut.Handle(byIdQuery, new CancellationToken());
            // Assert
            mockOrders.VerifyAll();
            Assert.NotNull(actual);
        }
    }
}
