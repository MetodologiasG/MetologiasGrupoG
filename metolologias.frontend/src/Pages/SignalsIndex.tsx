import React, { useEffect, useState } from 'react'
import { SignalListDTO } from '../Models/Signals/SignalListDTO';
import { SignalService } from '../Services/SignalService';
import Toast from '../Models/helpers/Toast';
import { Box, Button, Container, Paper, TableContainer, Typography} from '@mui/material';
import { makeStyles } from '@mui/styles';
import TableComponent from '../Components/TableComponent';
import { Link, Navigate, useNavigate } from 'react-router-dom';

const Styles: any = makeStyles((theme? : any) => ({
  root: { flexGrow: 1 },
  menuButton: { marginRight: 10 },
  title: { flexGrow: 1 },
  container: { marginTop: 10 },
  paper: { padding: 10 },
}));

function SignalsIndex() {

  const columns = ["id", "ref", "value", "streetRef", "putDate", "finalDate"]
  const classes = Styles();
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

  return (
    <div className={classes.root}>
        <Container className={classes.container} maxWidth='lg'>
           

          <Paper className={classes.paper}>
            <Box display='flex'>
              <Box flexGrow={1}>
                <Typography component="h2" variant="h6" color='primary' gutterBottom style={{ color: "#fb8500" }}>
                  
                </Typography>
              </Box>
              <Box>
                <Link to="/create" style={{ textDecoration: "none" }}>
                  <Button variant='contained' color="primary" style={{ backgroundColor: "#fb8500" }} onClick={() => history('/create')}>
                    Create Sinal
                  </Button>
                </Link>
              </Box>
            </Box>
            <TableContainer component={Paper}>
              <TableComponent columns={columns} data={data} OnDelete={() => {}} OnEdit={() => {}} OnClickHeader={() => {}}></TableComponent>
            </TableContainer>


          </Paper>
        </Container>

      </div>
  )
}

export default SignalsIndex

function useStyles() {
  throw new Error('Function not implemented.');
}
