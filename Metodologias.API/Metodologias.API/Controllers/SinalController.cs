using Metodologias.Infrastracture.Interfaces.Services;
using Metodologias.Infrastracture.Models.Helpers;
using Metodologias.Infrastracture.Models.Sinals;
using Microsoft.AspNetCore.Mvc;

namespace MetodologiasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SinalController : ControllerBase
    {
        private readonly ISignalService _sinalService;
        public SinalController(ISignalService sinalService)
        {
            _sinalService = sinalService;
        }

        [HttpGet("GetAll")]
        public async Task<MessagingHelper<List<SignalListDTO>>> GetAllSinals()
        {
            return await _sinalService.GetAll();
        }

        [HttpPost("Create")]

        public async Task<MessagingHelper> Create(CreateSignalDTO createSinal)
        {
            return await _sinalService.Create(createSinal);
        }

        [HttpPost("SetSignal")]
        public async Task<MessagingHelper> SetSignal(SetSignalDTO setSignal)
        {
            return await _sinalService.SetSignal(setSignal);
        }

        [HttpPost("WithdrawSignal")]
        public async Task<MessagingHelper> WithdrawSignal(WithdrawSignalDTO withdrawSignal)
        {
            return await _sinalService.WithdrawSignal(withdrawSignal);
        }

        [HttpGet("{id}")]
        public async Task<MessagingHelper<SignalDetailDTO>> GetById(int id)
        {
            return await _sinalService.GetById(id);
        }
    }
}