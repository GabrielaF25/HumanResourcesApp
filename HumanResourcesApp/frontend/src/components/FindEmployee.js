import React, { useState } from 'react';
import { getEmployeeById } from '../api'; // Funcția pentru apel API
import { Link } from 'react-router-dom'; // Pentru a crea linkul către pagina de editare
import LeaveDetails from './LeaveDetails';

const FindEmployee = () => {
    const [employeeId, setEmployeeId] = useState('');
    const [employee, setEmployee] = useState(null);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState('');

    const handleSearch = async () => {
        setIsLoading(true);
        setError('');
        setEmployee(null);
        try {
            const foundEmployee = await getEmployeeById(employeeId);
            console.log('Employee found:', foundEmployee); // DEBUG
            setEmployee(foundEmployee);
        } catch (err) {
            console.error('Error:', err); // DEBUG
            setError('Angajatul nu a fost găsit sau a apărut o eroare.');
        } finally {
            setIsLoading(false);
        }
    };


    return (
        <div style={{ padding: '20px' }}>
            <h1>Caută Angajat</h1>
            <div style={{ marginBottom: '20px' }}>
                <input
                    type="text"
                    placeholder="Introduceți ID-ul angajatului"
                    value={employeeId}
                    onChange={(e) => setEmployeeId(e.target.value)}
                    style={{ padding: '10px', marginRight: '10px' }}
                />
                <button onClick={handleSearch} style={{ padding: '10px 20px' }}>
                    Caută
                </button>
            </div>
            {isLoading && <p>Se încarcă...</p>}
            {error && <p style={{ color: 'red' }}>{error}</p>}
            {employee && (
                <div>
                    <h2>Detalii Angajat</h2>
                    <p><strong>ID:</strong> {employee.id}</p>
                    <p><strong>Nume:</strong> {employee.nume}</p>
                    <p><strong>Prenume:</strong> {employee.prenume}</p>
                    <p><strong>Email:</strong> {employee.email}</p>
                     {/* Alte detalii despre angajat */}
                    <Link
                        to={`/edit-employee/${employee.id}`}
                        style={{
                            display: 'inline-block',
                            marginTop: '20px',
                            padding: '10px 20px',
                            backgroundColor: '#007bff',
                            color: 'white',
                            textDecoration: 'none',
                            borderRadius: '5px',
                        }}
                    >
                        Modifică Angajat
                    </Link>
                    <Link to={`/leave-details/${employee.id}`}
                        style={{
                            display: 'inline-block',
                            marginTop: '20px',
                            padding: '10px 20px',
                            backgroundColor: '#007bff',
                            color: 'white',
                            textDecoration: 'none',
                            borderRadius: '5px',
                        }}>
                        Vezi Concedii
                    </Link>
                </div>
            )}
        </div>
    );
};

export default FindEmployee;
