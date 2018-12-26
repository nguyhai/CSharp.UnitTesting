using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange - Prepare objects that we want to test
            var reservation = new Reservation();

            // Act - Call the method that we want to test
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert - Verify that the result is corerct. We can use the assert class to help us with this. 
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void CanBeCancelledBy_MadeByIsUser_ReturnsTrue()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user};

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.IsTrue(result);

        }
        [TestMethod] // Decorate with TestMethod attribute
        public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnsFalse()
        {
            var reservation = new Reservation { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
        }


    }
}
