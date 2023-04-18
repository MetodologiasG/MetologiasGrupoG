using AutoMapper;
using Metodologias.Infrastracture.Interfaces.Repositories;
using Metodologias.Infrastracture.Interfaces.Services;
using Metodologias.Infrastracture.Models.Helpers;
using Metodologias.Infrastracture.Models.Sinals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias.BLL.Services
{
    public class SinalsService : ISinalService
    {
        private readonly ISinalRepository _sinalRepository;
        private readonly IMapper _mapper;
        public SinalsService(ISinalRepository sinalRepository, IMapper mapper)
        {
            _sinalRepository = sinalRepository;
            _mapper = mapper;
        }

        public async Task<MessagingHelper<List<SinalListDTO>>> GetAll()
        {
            MessagingHelper<List<SinalListDTO>> response = new MessagingHelper<List<SinalListDTO>>();
            try
            {
                var sinals = await _sinalRepository.GetAll();
                if (sinals == null)
                {
                    response.Success = false;
                    response.Message = "Ocorreu um erro ao listar os sinais";
                    return response;
                }

                response.obj = sinals.Select(s => _mapper.Map<SinalListDTO>(s)).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Ocorreu um erro inesperado ao listar os sinais : {ex.Message}";
            }
            return response;
        }
    }
}
