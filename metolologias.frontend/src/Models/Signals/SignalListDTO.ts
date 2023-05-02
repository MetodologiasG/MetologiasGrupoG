export interface SignalListDTO{
    id: number;
    ref :string;
    value :string;
    streetRef : string;
    putDate : Date;
    finalDate: Date | null;
}