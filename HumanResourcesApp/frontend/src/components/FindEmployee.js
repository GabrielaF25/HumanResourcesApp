import React, { useState } from 'react';
import { getEmployeeById } from '../api';

const FindEmployee = () => {
    const [id, setId] = useState('');
    const [employee, setEmployee] = useState(null);
    const [error, setError] = useState('');

    const handleSearch = () => {
        getEmployeeById(id)
            .then((response) => {
                setEmployee(response.data);
                setError('');
            })
            .catch((error) => {
                console.error('Eroare la căutarea angajatului:', error);
                setError('Angajatul nu a fost găsit!');
                setEmployee(null);
            });
    };

    return (
        <div className="container mt-4">
            <h1>Caută Angajat după ID</h1>
            <div className="mb-3">
                <label className="form-label">Introduceți ID-ul:</label>
                <input
                    type="number"
                    className="form-control"
                    value={id}
                    onChange={(e) => setId(e.target.value)}
                />
            </div>
            <button className="btn btn-primary" onClick={handleSearch}>
                Caută
            </button>
            {error && <p className="text-danger mt-3">{error}</p>}
            {employee && (
                <div className="mt-4">
                    <h3>Detalii Angajat:</h3>
                    <p><strong>ID:</strong> {employee.id}</p>
                    <p><strong>Nume:</strong> {employee.nume}</p>
                    <p><strong>Prenume:</strong> {employee.prenume}</p>
                    <p><strong>Email:</strong> {employee.email}</p>
                    <p><strong>Pozitie:</strong> {employee.pozitie}</p>
                    <p><strong>Data Angajării:</strong> {new Date(employee.dataAngajarii).toLocaleDateString()}</p>
                </div>
            )}
        </div>
    );
};

export default FindEmployee;
