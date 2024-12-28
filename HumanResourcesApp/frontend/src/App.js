import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Home from './components/Home';
import EmployeeList from './components/EmployeeList';
import AddEmployeeForm from './components/AddEmployeeForm';
import FindEmployee from './components/FindEmployee';

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/employees" element={<EmployeeList />} />
                <Route path="/add-employee" element={<AddEmployeeForm />} />
                <Route path="/find-employee" element={<FindEmployee />} />
            </Routes>
        </Router>
    );
};

export default App;
