import React, { useEffect, useState } from 'react'
import { SignalListDTO } from '../Models/Signals/SignalListDTO';
import { SignalService } from '../Services/SignalService';
import Toast from '../Models/helpers/Toast';
import TableComponent from '../Components/TableComponent';
import { useNavigate } from 'react-router-dom';
import Layout from '../Components/Layout/Layout';
import { Row } from 'reactstrap';
import "../Styles/App.css"

function SignalsIndex() {

  const columns = ["id", "ref", "value", "streetRef", "putDate", "finalDate"]
  const [data, setData] = useState<SignalListDTO[]>([]);
  const service = new SignalService();
  const history = useNavigate();

  const GetData = async () => {

    var response = await service.GetAll();
    if(response.success === false || response.obj == null)
    {
      Toast.Show("error", response.message);
      return;
    }

    setData(response.obj);
  }

  useEffect(()=> {
    GetData();
  }, [])

  const NavigateToGetById = (id: number) => {
    history("/signal/" + id)
  }

  return (
    <Layout>
    <div className="pageContainer">
        <div className="pageHeader">
            <span className="pageTitle">Sinais</span>
        </div>
        <div className="pageBody">
        <div className="pageComponent" style={{ width: "90%" }}>
          <TableComponent columns={columns} data={data} leftButton='Editar' rightButton='Eliminar' OnClickRight={() => {}} OnClickLeft={NavigateToGetById} OnClickHeader={() => {}} showButtons={true}></TableComponent>
        </div>
        </div>
    </div>

    </Layout>
  )
}

export default SignalsIndex
