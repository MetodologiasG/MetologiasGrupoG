import React, { useState } from 'react'
import { SignalService } from '../Services/SignalService';
import { SignalCreateDTO } from '../Models/Signals/SignalCreateDTO';
import styled from "styled-components";
import Toast from '../Models/helpers/Toast';
import { ToastContainer } from 'react-toastify';

function SignalsCreate() {
  const signalService = new SignalService();
  const [signal, setSignal] = useState<SignalCreateDTO>({} as SignalCreateDTO);
  const [loading, setLoading] = useState<boolean>(false);
  const [LoadingAuthors, setLoadingAuthors] = useState<boolean>(true);

  
  const createBook = async () => {
    const bookData: SignalCreateDTO = {
        ...signal
    }
    setLoading(true);
    var response = await signalService.Create(bookData);
    setLoading(false);

    if (response.sucess !== true) {
        Toast.Show("error", response.message);
        return;
    }
    Toast.Show("success", "livro criado com sucesso");
}

  return (
    <div>
  <ToastContainer />
  <Container>
      <Title>
          <h1>Criar sinal</h1>
      </Title>
      <Inputs>
          <Input type="text" onChange={(element) => setSignal({ ...signal, ref: element.target.value })} placeholder="Referencia">
          </Input>
          <Input type="number" onChange={(element) => setSignal({ ...signal, value: Number(element.target.value)})} placeholder="Valor nominmal">
          </Input>
          <Input type="text" onChange={(element) => setSignal({ ...signal, streetRef: element.target.value })} placeholder="referencia da estrada">
          </Input>
          <Input type="date" onChange={(element) => setSignal({ ...signal, putDate: new Date(element.target.value) })} placeholder="Data">
          </Input>
      </Inputs>
      <Button onClick={() => { createBook() }}>
          Criar
      </Button>

  </Container>
  </div>

  )
}

export default SignalsCreate


const Container = styled.div`
height: 100%;
widht:100%;
`
const Title = styled.div`
color: #fb8500;
font-size: 20px;
`
const Inputs = styled.div`
display: flex;
flex-direction: column;
align-items: center;
`
const Input = styled.input`
padding: 10px;
border-radius: 10px;
border: solid 1px grey;
width: 20rem;
margin: 15px;
`
const Select = styled.select`
padding: 5px;
width: 21.5rem;
border-radius: 10px;
font-size: 14px;
margin: 15px;
height: 2.2rem;

`

const Button = styled.button`

padding: 10px;
width: 10rem;
border-radius: 10px;
border: 1px solid grey;
height: 3rem;
background-color:#fb8500; 
color: white;
font-size: 14px;
font-weight: 700;
letter-spacing: 1px;
transition: 0.3s;
:hover{
    background-color: #faa307;
    cursor: pointer;
}

`