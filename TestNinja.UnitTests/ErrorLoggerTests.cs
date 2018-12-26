using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_ShouldSetLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("a"); // Not putthing this in a variable, as the return for Log() is viud. We will call the method though.

            // Because we called logger.Log(), it will have used the parameter we entered and put it into the LastError property. 
            Assert.That(logger.LastError, Is.EqualTo("a")); 
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();

            //logger.Log(error);

            // We can call the log method down in the assert instead. 
            // Lambda Expression, left to right, x is just the name (on the left). On the right, we have the expression that is the result. 
            // We pass lambda expressions as arguments for sorting or searching often. 
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
            //Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>);
        }

        // Test a method that raises an event. 
        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            // Arrange
            var logger = new ErrorLogger();

            var id = Guid.Empty;

            // Need to subscribe to the event first. 
            // If this event is raised, this function (after the +=) is executed. ID will no longer be empty GUID, it will be the value that comes iwth the event. 
            logger.ErrorLogged += (sender, args) => { id = args; };

            // Act
            logger.Log("a");

            // Assert - assert that the ID is no longer equal to empty. This means that a new Guid event has been created. 
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));

        }



    }
}
