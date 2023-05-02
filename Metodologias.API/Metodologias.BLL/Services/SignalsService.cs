using AutoMapper;
using Metodologias.Infrastracture.Entities;
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
    public class SignalsService : ISignalService
    {
        private readonly ISinalRepository _sinalRepository;
        private readonly IMapper _mapper;
        public SignalsService(ISinalRepository sinalRepository, IMapper mapper)
        {
            _sinalRepository = sinalRepository;
            _mapper = mapper;
        }

        public async Task<MessagingHelper<List<SignalListDTO>>> GetAll()
        {
            MessagingHelper<List<SignalListDTO>> response = new MessagingHelper<List<SignalListDTO>>();
            try
            {
                var sinals = await _sinalRepository.GetAll();
                if (sinals == null)
                {
                    response.Success = false;
                    response.Message = "Ocorreu um erro ao listar os sinais";
                    return response;
                }

                response.obj = sinals.Select(s => _mapper.Map<SignalListDTO>(s)).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Ocorreu um erro inesperado ao listar os sinais : {ex.Message}";
            }
            return response;
        }

        public async Task<MessagingHelper> Create(CreateSignalDTO creteSignal)
        {
            MessagingHelper response = new MessagingHelper();
            try
            {
                var signal = _mapper.Map<Signal>(creteSignal);
                await _sinalRepository.Create(signal);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }
    }
}
