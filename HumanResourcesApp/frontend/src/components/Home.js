import React from 'react';
import { useNavigate } from 'react-router-dom';

const HomePage = () => {
    const navigate = useNavigate();

    return (
        <div className="container mt-4 text-center">
            <h1>Bine ai venit la Human Resources App</h1>
            <p>Alege o acțiune:</p>
            <div className="d-flex justify-content-center gap-3 mt-4">
                <button className="btn btn-primary" onClick={() => navigate('/employees')}>
                    Lista Angajaților
                </button>
                <button className="btn btn-secondary" onClick={() => navigate('/add-employee')}>
                    Adaugă Angajat
                </button>
                <button className="btn btn-info" onClick={() => navigate('/find-employee')}>
                    Caută Angajat după ID
                </button>
            </div>
        </div>
    );
};

export default HomePage;
