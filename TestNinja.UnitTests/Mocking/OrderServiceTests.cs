using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            // Arrange
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);

            var order = new Order();
            // Act
            service.PlaceOrder(order); // Pass the object here

            // Assert
            // Verify verifies if a method is called with the right arguments or not
            storage.Verify(s => s.Store(order)); // Verify that the same object that is passed. " s=> means, Storage goes to...."


        }

    }
}
