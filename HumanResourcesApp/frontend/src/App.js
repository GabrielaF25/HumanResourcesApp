import React, { useState } from 'react';
import { BrowserRouter as Router, Route, Routes, Outlet, Navigate } from 'react-router-dom';
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
import Login from './components/Login';
import DocumentList from './components/DocumentList';
import DocumentForm from './components/DocumentForm';
import DocumentDetails from './components/DocumentDetails';

// Layout-ul general
const Layout = ({ onLogout }) => (
    <div id="wrapper">
        <Sidebar onLogout={onLogout} />
        <div id="main">
            <div className="inner">
                <Header />
                <Banner />
                <div>
                    <Outlet />
                </div>
            </div>
        </div>
        <Footer />
    </div>
);

// Componentă pentru rute protejate
const ProtectedRoute = ({ children }) => {
    const token = localStorage.getItem('token'); // Verificăm token-ul din localStorage
    return token ? children : <Navigate to="/login" />;
};

const App = () => {
    const [isLoggedIn, setIsLoggedIn] = useState(!!localStorage.getItem('token'));

    const handleLogin = () => {
        setIsLoggedIn(true);
    };

    const handleLogout = () => {
        localStorage.removeItem('token');
        setIsLoggedIn(false);
        window.location.href = '/login'; // Redirecționare după logout
    };

    return (
        <Router>
            <Routes>              
                <Route path="/login" element={<Login onLogin={handleLogin} />} />           
                <Route
                    path="/"
                    element={
                        <ProtectedRoute>
                            <Layout onLogout={handleLogout} />
                        </ProtectedRoute>
                    }
                > 
                    <Route index element={<Home />} />
                    <Route path="employees" element={<EmployeeList />} />
                    <Route path="add-employee" element={<AddEmployeeForm />} />
                    <Route path="find-employee" element={<FindEmployee />} />
                    <Route path="/edit-employee/:id" element={<EditEmployee />} />
                    <Route path="/leave-details/:angajatId" element={<LeaveDetails />} />
                    <Route path="/edit-leave/:angajatId/:requestId" element={<EditLeaveRequest />} />
                    <Route path="/leave-overview" element={<LeaveOverview />} />
                    <Route path="/evaluation-overview" element={<EvaluationOverview />} />                  
                    <Route path="documents" element={<DocumentList />} />
                    <Route path="add-document" element={<DocumentForm />} />
                    <Route path="document-details/:id" element={<DocumentDetails />} />
                </Route>
            </Routes>
        </Router>
    );
};

export default App;
