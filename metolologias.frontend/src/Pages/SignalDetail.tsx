import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import { SignalDetailDTO } from '../Models/Signals/SignalDetail';
import { SignalService } from '../Services/SignalService';
import Toast from '../Models/helpers/Toast';
import InputComponent from '../Components/InputComponent';
import TableComponent from '../Components/TableComponent';
import { TemporalInformationlistDTO } from '../Models/TemporalInformation/TemporalInformationListDTO';
import { Col, Row } from 'reactstrap';
import ButtonComponent from '../Components/ButtonComponent';
import Layout from '../Components/Layout/Layout';
import "../Styles/App.css"


function SignalDetail() {
    const { id } = useParams<{ id: string }>();
    const columns = ["id", "quality", "firstDateString", "removedDateString", "streetRef"]
    const [signal, setSignal] = useState<SignalDetailDTO>({} as SignalDetailDTO);
    const [temporal, setTemporal] = useState<TemporalInformationlistDTO[]>([]); 
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const service = new SignalService();


    const GetSignal = async () => {
    
        setIsLoading(true);
        var response = await service.GetSignalById(Number(id));
        if(response.success === false || response.obj == null)
        {
            Toast.Show("error", response.message);
            setIsLoading(false);
            return;
        }
        
        setTemporal(response.obj.temporalInformationLists);
        setSignal(response.obj);
        setIsLoading(false);
    }

    useEffect(() => {
        GetSignal();
    }, [])



  return (
    <Layout>
        <div className="pageContainer">
                <div className="pageHeader">
                    <span className="pageTitle">Sinais {signal.Id}</span>
                </div>
                <div className="pageBody">
                    <Row>
                        <InputComponent  xl={2} lg={3} md={5} sm={12} xs={12}
                        style={{width: "100%"}}
                        class='ref'
                        type='text'
                        label='Referencia ' 
                        value={signal.ref} 
                        readOnly={false} 
                        showLoadingSkeleton={isLoading}
                        onChange={(t : string) => {setSignal({...signal, ref: t})}}
                        />
        

                        <InputComponent xl={6} lg={6} md={6} sm={12} xs={12}
                            style={{width: "100%"}}
                            class='valor'
                            type='number'
                            label='Valor Nominal ' 
                            value={signal.value} 
                            readOnly={false} 
                            showLoadingSkeleton={isLoading}
                            onChange={(t : number) => {setSignal({...signal, value: t})}}
                            />

                    </Row>
                    

                    <TableComponent columns={columns} 
                    data={temporal} 
                    leftButton='Editar' 
                    rightButton='Eliminar' 
                    OnClickRight={() => {}} 
                    OnClickLeft={() => {}} 
                    OnClickHeader={() => {}} 
                    showButtons={false} ></TableComponent>

                </div>
                <Row>
                        {(signal.setSignal === true) ?
                            <ButtonComponent onClick={() => {}} text='Colocar'/>
                            :
                            <ButtonComponent onClick={() => {}} text='Retirar'/>
                        }
                </Row>

            </div>
        </Layout>
  )
}

export default SignalDetail