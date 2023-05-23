import { TemporalInformationlistDTO } from "../TemporalInformation/TemporalInformationListDTO";

export interface SignalDetailDTO {
    Id: number;
    ref: string;
    value: number;
    setSignal: boolean;
    temporalInformationLists : TemporalInformationlistDTO[]
} 