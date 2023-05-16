import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import { SignalDetailDTO } from '../Models/Signals/SignalDetail';
import { SignalService } from '../Services/SignalService';
import styled from "styled-components";
import Toast from '../Models/helpers/Toast';
import InputComponent from '../Components/InputComponent';
import TableContainer from '@mui/material/TableContainer';
import TableComponent from '../Components/TableComponent';
import { TemporalInformationlistDTO } from '../Models/TemporalInformation/TemporalInformationListDTO';
import { Button, ButtonGroup, Table, TableBody, TableCell, TableHead, TableRow } from '@mui/material';

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
    <Container>
    <Paper>
        <Info>
            <Data>
                <Id>
                    {signal.Id}
                </Id>
                <Ref>
                    <InputComponent lg={1}
                    type='text'
                    label='Referencia ' 
                    value={signal.ref} 
                    readOnly={false} 
                    showLoadingSkeleton={isLoading}
                    onChange={(t : string) => {setSignal({...signal, ref: t})}}
                    />
      
                </Ref>
                <ValorNominal>
                <InputComponent lg={1}
                    type='number'
                    label='Valor Nominal ' 
                    value={signal.value} 
                    readOnly={false} 
                    showLoadingSkeleton={isLoading}
                    onChange={(t : number) => {setSignal({...signal, value: t})}}
                    />
                </ValorNominal>

                <TableContainer>
                <Table aria-label="Books List">
                <TableHead>
                    <TableRow>
                        {columns.map((column, index) => {
                            return (
                                <TableCell key={index} align="right" aria-label={column} style={{ cursor: 'pointer' }}>
                                    {column}
                                </TableCell>
                            )

                        })}
                    </TableRow>
                </TableHead>
                <TableBody>
                    {
                        temporal !== undefined ?? 
                        temporal.map((item) => (
                            <TableRow key={item.id}>
                                
                                  
                                            <TableCell align="right">
                                                {item.id}
                                            </TableCell>
                                            <TableCell align="right">
                                            {item.quality}
                                            </TableCell>
                                            <TableCell align="right">
                                            {item.firstDateString}
                                            </TableCell>
                                                <TableCell align="right">
                                                {item.removedDateString}
                                            </TableCell>
                                            <TableCell align="right">
                                                {item.streetRef}
                                            </TableCell>
     
                                
                                <TableCell align="center">
                                    <ButtonGroup aria-label="buttons" style={{ color: "#fb8500" }}>
                                        <Button onClick={() => {  }} style={{ color: "#fb8500" }}>
                                            Edit
                                        </Button>
                                        <Button onClick={() => {  }} style={{ color: "#fb8500" }}>
                                            Delete
                                        </Button>
                                    </ButtonGroup>
                                </TableCell>
                            </TableRow>
                        ))
                    }
                </TableBody>
            </Table>
                </TableContainer>
            </Data>
            <Footer>
                <Buy>
                    {(signal.setSignal === true) ?
                        <BuyButton>
                            Colocar
                        </BuyButton>
                        :
                        <BuyButton>
                            Retirar
                        </BuyButton>
                    }
                </Buy>
            </Footer>

        </Info>
    </Paper>

</Container>
  )
}

export default SignalDetail

const Container = styled.div`
    width: 100vw;
    display: flex;
    min-height: 85vh;
    align-items: center;
    justify-content: center;
 
  
`
const Paper = styled.div`
    width: 90%;
    display: flex;
    min-height: 80vh;
    border-radius: 10px;
`

const Info = styled.div`
    width: 100%;
    padding: 20px;
    border: 1px solid black;
    text-align: left;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    border-radius: 10px;
`

const Stock0 = styled.label`
    color: red;
    background-color: red;
`

const Data = styled.div`

`

const Footer = styled.div`
    margin: 20px;
`

const Id = styled.div`
color: gray;
`

const Name = styled.h1`
color: gray;

`

const Ref = styled.div`
   
`

const Desc = styled.label`

`

const Price = styled.div`
    font-weight: 700;
    margin-top: 20px;
`

const ValorNominal = styled.div`

`

const Buy = styled.div`
    
    display: flex;
    justify-content: end;
`

const BuyButton = styled.button`
    color: white;
    background-color: #fb8500;
    border:1px solid gray;
    border-radius: 10px;
    padding: 10px;
    display:flex;
    align-items: center;
    cursor: pointer;
    
    
   
`