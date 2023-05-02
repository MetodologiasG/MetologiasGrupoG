import axios from 'axios'
import React from 'react'
import { SignalListDTO } from '../Models/Signals/SignalListDTO'
import { MessagingHelper} from '../Models/helpers/MessagingHelper';
import { APIService } from './APIService';

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
}