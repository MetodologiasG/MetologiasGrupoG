import { ToastContainer } from "react-toastify";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import SignalsIndex from "./Pages/SignalsIndex";
import SignalsCreate from "./Pages/SignalsCreate";
import SignalDetail from "./Pages/SignalDetail";
import "./Styles/App.css";

function App() {
    return (
        <div className="App">
            <ToastContainer bodyClassName="myToast"
                position="bottom-right"
                autoClose={5000}
                pauseOnFocusLoss={false}
                pauseOnHover={true}
                hideProgressBar={true} />
            <BrowserRouter>
              <Routes>
                    <Route path='/' element={<SignalsIndex/>} />
                    <Route path='/create' element={<SignalsCreate/>} />
                    <Route path='/signal/:id' element={<SignalDetail/>} />
              </Routes>
            </BrowserRouter>
        </div>
    );
}

export default App;
