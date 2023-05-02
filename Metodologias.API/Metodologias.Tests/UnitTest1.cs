using AutoMapper;
using Metodologias.API.Mapping;
using Metodologias.BLL.Services;
using Metodologias.DAL;
using Metodologias.DAL.Repositories;
using Metodologias.Infrastracture.Interfaces.Services;
using Metodologias.Infrastracture.Models.Sinals;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Metodologias.Tests
{
    public class Tests
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
        public async Task GetAllSignals_Success_Test()
        {
            var signals = await _signalService.GetAll();
            int count = signals.obj.Count();

            Assert.AreEqual(3, count);
        }

        [Test]
        public async Task CreateSignal_Success_Test()
        {
            //act
            var signal = await _signalService.Create(new CreateSignalDTO() { Ref = "87328", Value = 30, StreetRef = "A4", PutDate = DateTime.Now });

            var signals = await _signalService.GetAll();
            int count = signals.obj.Count();

            //assert
            Assert.AreEqual(4, count);
        }

        private async Task<SinalsRepository> CreateRepository()
        {
            ApplicationDBContext context = new ApplicationDBContext(dbContextOptions);
            AddValues.SeedData(context);
            return new SinalsRepository(context);
        }

        private async Task CreateService()
        {
            _signalService = new SignalsService(await CreateRepository(), _mapper);
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