import React, { useEffect, useState } from 'react';
import { getEmployees, deleteEmployee } from '../api';
import '../css/EmployeeList.css';
import { useNavigate } from 'react-router-dom';

const EmployeeList = () => {
    const [employees, setEmployees] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        getEmployees()
            .then((response) => setEmployees(response.data))
            .catch((error) => console.error('Eroare la obținerea angajaților:', error));
    }, []);

    return (
        <div className="container mt-4">
            <div className="d-flex justify-content-between align-items-center mb-4">
                <h1>Lista Angajaților</h1>
                <button
                    className="btn btn-primary"
                    onClick={() => navigate('/add-employee')}
                >
                    Adaugă Angajat
                </button>
            </div>
            <table className="table table-striped table-hover">
                <thead className="table-dark">
                    <tr>
                        <th>ID</th>
                        <th>Nume</th>
                        <th>Prenume</th>
                        <th>Email</th>
                        <th>Pozitie</th>
                        <th>Data Angajării</th>
                        <th>Acțiuni</th>
                    </tr>
                </thead>
                <tbody>
                    {employees.map((emp) => (
                        <tr key={emp.id}>
                            <td>{emp.id}</td>
                            <td>{emp.nume}</td>
                            <td>{emp.prenume}</td>
                            <td>{emp.email}</td>
                            <td>{emp.pozitie}</td>
                            <td>{new Date(emp.dataAngajarii).toLocaleDateString()}</td>
                            <td>
                                <button
                                    className="btn btn-danger"
                                    onClick={() => {
                                        deleteEmployee(emp.id)
                                            .then(() => {
                                                alert('Angajat șters cu succes!');
                                                setEmployees(employees.filter(e => e.id !== emp.id));
                                            })
                                            .catch((error) => console.error('Eroare la ștergere:', error));
                                    }}
                                >
                                    Șterge
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default EmployeeList;
