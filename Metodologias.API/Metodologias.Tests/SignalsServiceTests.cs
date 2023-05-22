using AutoMapper;
using Metodologias.API.Mapping;
using Metodologias.BLL.Services;
using Metodologias.DAL;
using Metodologias.DAL.Repositories;
using Metodologias.Infrastracture.Entities;
using Metodologias.Infrastracture.Interfaces.Repositories;
using Metodologias.Infrastracture.Interfaces.Services;
using Metodologias.Infrastracture.Models.Helpers;
using Metodologias.Infrastracture.Models.Sinals;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metodologias.Tests
{
    [TestFixture]
    public class SignalsServiceTests
    {
        private DbContextOptions<ApplicationDBContext> dbContextOptions;
        private SignalsService _signalService;
        private IMapper _mapper;

        [SetUp]
        public async Task Setup()
        {
            var dbName = $"MetodolofiasDb_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(dbName)
                .Options;

            CreateMapper();
            await CreateService();
        }

        [Test]
        public async Task Create_WhenSignalDoesNotExist_ReturnsSuccessResponse()
        {
            // Arrange
            var createSignalDto = new CreateSignalDTO() { Value = 50, Ref = "34235435", PutDate = DateTime.Now };
            var response = new MessagingHelper { Success = true };

            // Act
            var result = await _signalService.Create(createSignalDto);

            // Assert
            Assert.AreEqual(response.Success, result.Success);
        }

        [Test]
        public async Task Create_WhenSignalExists_ReturnsErrorResponse()
        {
            // Arrange
            var createSignalDto = new CreateSignalDTO() { Value = 50, Ref = "14567", PutDate = DateTime.Now };
            var response = new MessagingHelper { Success = false, Message = "Este sinal já existe" };

            // Act
            var result = await _signalService.Create(createSignalDto);

            // Assert
            Assert.AreEqual(response.Success, result.Success);
            Assert.AreEqual(response.Message, result.Message);
        }

        [Test]
        public async Task UpdateSignal_WhenSignalExists_ReturnsSuccessResponse()
        {
            // Arrange
            //var updateSignalDto = new UpdateSignalDTO();
            //var response = new MessagingHelper { Success = true };

            // Act
            //var result = await _signalService.UpdateSignal(updateSignalDto);

            // Assert
            //Assert.AreEqual(response.Success, result.Success);
        }

        [Test]
        public async Task UpdateSignal_WhenSignalDoesNotExist_ReturnsErrorResponse()
        {
            // Arrange
            //var updateSignalDto = new UpdateSignalDTO();
            //var response = new MessagingHelper { Success = false, Message = "Este sinal não existe" };
            //_sinalRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Signal)null);

            //// Act
            //var result = await _signalsService.UpdateSignal(updateSignalDto);

            //// Assert
            //Assert.AreEqual(response.Success, result.Success);
            //Assert.AreEqual(response.Message, result.Message);
        }

        [Test]
        public async Task GetAllSignals_Success_Test()
        {
            var signals = await _signalService.GetAll();
            int count = signals.obj.Count();

            Assert.AreEqual(3, count);
        }

        private async Task<SinalsRepository> CreateRepository()
        {
            ApplicationDBContext context = new ApplicationDBContext(dbContextOptions);
            AddValues.SeedData(context);
            return new SinalsRepository(context);
        }

        private async Task<TeamRepository> CreateTeamRepository()
        {
            ApplicationDBContext context = new ApplicationDBContext(dbContextOptions);
            return new TeamRepository(context);
        }

        private async Task CreateService()
        {
            _signalService = new SignalsService(await CreateRepository(), _mapper, await CreateTeamRepository());
        }

        public void CreateMapper()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new AutoMapperProfiler());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
    }
}