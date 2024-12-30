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

                </Route>
            </Routes>
        </Router>
    );
};

export default App;
