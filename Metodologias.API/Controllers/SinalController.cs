using Metodologias.Infrastracture.Interfaces.Services;
using Metodologias.Infrastracture.Models.Helpers;
using Metodologias.Infrastracture.Models.Sinals;
using Microsoft.AspNetCore.Mvc;

namespace MetodologiasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SinalController : ControllerBase
    {
        private readonly ISinalService _sinalService;
        public SinalController(ISinalService sinalService)
        {
            _sinalService = sinalService;
        }

        [HttpGet("GetAll")]
        public async Task<MessagingHelper<List<SinalListDTO>>> GetAllSinals()
        {
            return await _sinalService.GetAll();
        }
    }
}