import axios from 'axios'
import React from 'react'
import { SignalListDTO } from '../Models/Signals/SignalListDTO'
import { MessagingHelper} from '../Models/helpers/MessagingHelper';
import { APIService } from './APIService';
import { SignalCreateDTO } from '../Models/Signals/SignalCreateDTO';
import { SignalDetailDTO } from '../Models/Signals/SignalDetail';

export class SignalService {

    async GetAll() : Promise<MessagingHelper<SignalListDTO[] | null>>{
        try{
            var response = await APIService.Axios().get(`${APIService.GetURL()}/Sinal/GetAll`, {
                headers:{
                    Accept: "application/json",
                    "Content-Type": "application/json",
                }
            })
    
            return response.data
        }catch(error)
        {
            return new MessagingHelper<null>(false, "Erro ao obter os sinais", null);
        } 
    }

    async Create(data : SignalCreateDTO) : Promise<MessagingHelper<null>> {
        try{
            var response = await APIService.Axios().post(`${APIService.GetURL()}/Sinal/Create`, {...data}, {
                headers:{
                    Accept: "application/json",
                    "Content-Type": "application/json",
                }
            });
            return response.data;
        }catch(error)
        {
            return new MessagingHelper<null>(false, "Erro ao criar o sinal", null);
        }
    }

    async GetSignalById(id: number) : Promise<MessagingHelper<SignalDetailDTO | null>>
    {
        try{
            var response = await APIService.Axios().get(`${APIService.GetURL()}/Sinal/${id}`, {
                headers:{
                    Accept: "application/json",
                    "Content-Type": "application/json",
                }
            });
            return response.data
        }catch(error)
        {
            return new MessagingHelper<null>(false, "Erro ao obter os detalhes do sinal", null);
        }
    }
}