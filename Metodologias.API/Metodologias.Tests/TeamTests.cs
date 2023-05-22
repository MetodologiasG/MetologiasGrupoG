using Metodologias.Infrastracture.Entities;
using System;

namespace Metodologias.Tests
{

    [TestFixture]
    public class TeamTests
    {


        [SetUp]
        public async Task Setup()
        {

        }

        [Test]
        public void Team_NameShouldNotBeNull()
        {
            // Arrange
            var team = new Team();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => team.Name = null);
        }
    }

}