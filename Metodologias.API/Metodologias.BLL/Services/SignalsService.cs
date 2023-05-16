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
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        public SignalsService(ISinalRepository sinalRepository, IMapper mapper, ITeamRepository teamRepository)
        {
            _sinalRepository = sinalRepository;
            _mapper = mapper;
            _teamRepository = teamRepository;
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

        public async Task<MessagingHelper> SetSignal(SetSignalDTO setSignal)
        {
            MessagingHelper response = new MessagingHelper();
            try
            {
                var signal = await _sinalRepository.GetById(setSignal.SignalId);
                if (signal == null)
                {
                    response.Message = "Este sinal não existe";
                    return response;
                }

                var team = await _teamRepository.GetById(setSignal.TeamId);
                if (setSignal == null)
                {
                    response.Message = "Esta equipa não existe";
                }

                response = signal.SetSignal(team, setSignal);
                if (response.Success == false)
                {
                    return response;
                }

                await _sinalRepository.Update(signal);

                response.Success = true;
                response.Message = "Sinal colocado com sucesso";
            }
            catch (Exception ex)
            {
                response.Message = ex.GetBaseException().Message;
            }
            return response;
        }

        public async Task<MessagingHelper> WithdrawSignal(WithdrawSignalDTO withdrawSignal)
        {
            MessagingHelper response = new MessagingHelper();
            try
            {
                var signal = await _sinalRepository.GetById(withdrawSignal.Id);
                if (signal == null)
                {
                    response.Message = "Este sinal não existe";
                    return response;
                }

                var team = await _teamRepository.GetById(withdrawSignal.TeamId);
                if (team == null)
                {
                    response.Message = "Esta equipa não existe";
                    return response;
                }

                var responseSignalWithdraw = signal.WithdrawSignal(team, withdrawSignal.Date, withdrawSignal.Quality);
                if (responseSignalWithdraw.Success == false)
                {
                    response.Message = responseSignalWithdraw.Message;
                    return response;
                }

                await _sinalRepository.Update(signal);
                response.Success = true;
                response.Message = "Sinal colocado com sucesso";
            }
            catch (Exception ex)
            {
                response.Message = ex.GetBaseException().Message;
            }
            return response;
        }
    }
}
