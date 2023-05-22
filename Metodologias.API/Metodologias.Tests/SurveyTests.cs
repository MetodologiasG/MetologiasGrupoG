using Metodologias.Infrastracture.Entities;
using System;

namespace Metodologias.Tests
{

    [TestFixture]
    public class SurveyTests
    {

        [SetUp]
        public async Task Setup()
        {
        }

        [Test]
        public void Survey_DateShouldHaveValidFormat()
        {
            // Arrange
            var survey = new Survey();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => survey.Date = DateTime.MaxValue);
        }
    }

}