import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getEmployeeById } from '../api';

const EmployeeDetails = () => {
    const { id } = useParams();
    const [employee, setEmployee] = useState(null);

    useEffect(() => {
        getEmployeeById(id)
            .then((response) => setEmployee(response.data))
            .catch((error) => console.error('Eroare la obținerea angajatului:', error));
    }, [id]);

    return (
        <div className="container">
            {employee ? (
                <>
                    <h1>{employee.nume} {employee.prenume}</h1>
                    <p><strong>Email:</strong> {employee.email}</p>
                    <p><strong>Pozitie:</strong> {employee.pozitie}</p>
                    <p><strong>Data Angajării:</strong> {new Date(employee.dataAngajarii).toLocaleDateString()}</p>
                </>
            ) : (
                <p>Se încarcă...</p>
            )}
        </div>
    );
};

export default EmployeeDetails;
