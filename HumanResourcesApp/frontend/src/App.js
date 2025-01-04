import React from 'react';
import { BrowserRouter as Router, Route, Routes, Outlet } from 'react-router-dom'; // Asigură-te că importi `Outlet`
import Header from './components/Header';
import Banner from './components/Banner';
import Sidebar from './components/Sidebar';
import Footer from './components/Footer';
import Home from './components/Home';
import EmployeeList from './components/EmployeeList';
import AddEmployeeForm from './components/AddEmployeeForm';
import FindEmployee from './components/FindEmployee';
import EditEmployee from './components/EditEmployee';
import LeaveDetails from './components/LeaveDetails';
import EditLeaveRequest from './components/EditLeaveRequest';
import LeaveOverview from './components/LeaveOverview';
import EvaluationOverview from './components/EvaluationOverview';
// Layout-ul general
const Layout = () => (
    <div id="wrapper">
        <Sidebar />
        <div id="main">
            <div className="inner">
                <Header />
                <Banner />
                <div>
                    {/* Aici vor fi redat conținutul specific fiecărei rute */}
                    <Outlet />
                </div>
            </div>
        </div>
        <Footer />
    </div>
);

const App = () => {
    return (
        <Router>
            <Routes>

                {/* Layout general */}
                <Route path="/" element={<Layout />}>
                    {/* Rute în cadrul layout-ului */}
                    <Route index element={<Home />} /> {/* Ruta principală */}
                    <Route path="employees" element={<EmployeeList />} />
                    <Route path="add-employee" element={<AddEmployeeForm />} />
                    <Route path="find-employee" element={<FindEmployee />} />
                    <Route path="/edit-employee/:id" element={<EditEmployee />} />
                    <Route path="/leave-details/:angajatId" element={<LeaveDetails />} />
                    <Route path="/edit-leave/:angajatId/:requestId" element={<EditLeaveRequest />} />
                    <Route path="/leave-overview" element={<LeaveOverview />} />
                    <Route path="/evaluation-overview" element={<EvaluationOverview />} />


                </Route>
            </Routes>
        </Router>
    );
};

export default App;
