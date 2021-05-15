using AutoFixture;
using Moq;
using PizzaBurgerHouse.Application.Queries.OrderQueries;
using PizzaBurgerHouse.Application.Repositories;
using PizzaBurgerHouse.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PizzaBurgerHouse.Application.Tests.Queries.OrderQueries
{
    public class GetAllDeliveryOrdersTests
    {

        [Fact]
        public async void ItShould_Get_All_Delivery_Orders()
        {

            // Arrange
           
            var expected = new Fixture().Create<Task<IEnumerable<Order>>>();
            var mockOrders = new Mock<IOrderRepository>();
            mockOrders.Setup(x => x.GetAllDeliveryOrdersAsync()).Returns(expected);

            //Act
            GetAllDeliveryOrders getAll = new GetAllDeliveryOrders();
            var sut = new GetAllDeliveryOrdersQueryHandler(mockOrders.Object);
            var actual =  await sut.Handle(getAll, new CancellationToken());

            // Assert
            mockOrders.VerifyAll();
            Assert.NotNull(actual);
        }
    }
}
