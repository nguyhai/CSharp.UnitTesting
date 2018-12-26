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
    class CustomerControllerTest
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>()); // This means it is exactly of NotFound object

            //Assert.That(result, Is.InstanceOf<NotFound>()); // Result is NotFound or one of its derivatives. 
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOK()
        {

        }

    }
}
