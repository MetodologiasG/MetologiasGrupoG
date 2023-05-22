using Metodologias.Infrastracture.Entities;
using System;

namespace Metodologias.Tests
{

    [TestFixture]
    public class TechnicianTests
    {


        [Test]
        public void Technician_PhoneNumberShouldHaveValidFormat()
        {
            // Arrange
            var technician = new Technician();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => technician.PhoneNumber = "123");
        }
    }

}