using Metodologias.Infrastracture.Entities;
using NUnit.Framework;
using System;

namespace Metodologias.Tests
{
    public class TemporalInformationTests
    {



        [SetUp]
        public async Task Setup()
        {
        }

        [Test]
        public void TemporalInformation_FirstDateShouldNotBeInFuture()
        {
            // Arrange
            var temporalInformation = new TemporalInformation();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => temporalInformation.FirstDate = DateTime.Now.AddDays(1));
        }

        [Test]
        public void TemporalInformation_RemoveDateShouldNotBeBeforeFirstDate()
        {
            // Arrange
            var temporalInformation = new TemporalInformation()
            {
                FirstDate = DateTime.Now.AddDays(-7)
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => temporalInformation.RemoveDate = DateTime.Now.AddDays(-10));
        }

    }
}