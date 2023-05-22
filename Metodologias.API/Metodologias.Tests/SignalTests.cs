using Metodologias.Infrastracture.Entities;
using Metodologias.Infrastracture.Models.Sinals;
using NUnit.Framework;
using System;

namespace Metodologias.UnitTests
{
    [TestFixture]
    public class SignalTests
    {

        [SetUp]
        public async Task Setup()
        {
        }

        [Test]
        public void Signal_IdShouldNotBeNegative()
        {
            // Arrange
            var signal = new Signal();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => signal.Id = -1);
        }

        [Test]
        public void Signal_RefShouldNotBeNull()
        {
            // Arrange
            var signal = new Signal();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => signal.Ref = null);
        }

        [Test]
        public void Signal_NominalValueShouldNotBeZero()
        {
            // Arrange
            var signal = new Signal();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => signal.NominalValue = 0);
        }

        [Test]
        public void Signal_SetSignalShouldReturnErrorMessageWhenSignalNotRemoved()
        {
            // Arrange
            var signal = new Signal(10, "123456789", 50);
            var team = new Team();

            var setSignalDTO = new SetSignalDTO()
            {
                Quality = 1,
                Date = DateTime.Now,
                StreetRef = "Street 123"
            };


            // Act
            signal.SetSignal(team, setSignalDTO);
            var response = signal.SetSignal(team, setSignalDTO);

            // Assert
            Assert.IsFalse(response.Success);
            Assert.AreEqual("Este sinal ainda não foi removido da Street 123, se deseja inserir neste local por favor remova-o", response.Message);
        }

        [Test]
        public void Signal_WithdrawSignalShouldReturnErrorMessageWhenSignalNotPlaced()
        {
            // Arrange
            var signal = new Signal();
            var team = new Team();

            // Act
            var result = signal.WithdrawSignal(team, DateTime.Now, 1);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Este sinal ainda não está colocado em lado nenhum", result.Message);
        }
    }
}