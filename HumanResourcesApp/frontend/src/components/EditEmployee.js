import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getEmployeeById, updateEmployee } from '../api';

const EditEmployee = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [employee, setEmployee] = useState(null); 
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchEmployee = async () => {
            try {
                const data = await getEmployeeById(id);
                console.log('Fetched employee:', data); // DEBUG
                setEmployee(data);
            } catch (error) {
                console.error('Error fetching employee:', error);
                setError('Nu s-au putut încărca datele angajatului.');
            } finally {
                setIsLoading(false);
            }
        };

        fetchEmployee();
    }, [id]);


    const handleChange = (e) => {
        const { name, value } = e.target;
        setEmployee((prev) => ({
            ...prev,
            [name]: value,
        }));
    };

const handleSubmit = async (e) => {
    e.preventDefault();
    try {
        await updateEmployee(id, employee);
        alert('Angajat actualizat cu succes!');
        navigate('/employees'); // Navigăm înapoi la lista angajaților
    } catch (err) {
        console.error('Eroare la actualizarea angajatului:', err);
        setError('Actualizarea angajatului a eșuat.');
    }
};
if (isLoading) {
    return <p>Se încarcă datele angajatului...</p>;
}

// Dacă există o eroare
if (error) {
    return <p>{error}</p>;
}

// Dacă `employee` nu este încărcat
if (!employee) {
    return <p>Angajatul nu a fost găsit.</p>;
}


    return (
        <div style={{ padding: '20px' }}>
            <h2>Editare Angajat</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Nume:</label>
                    <input
                        type="text"
                        name="nume"
                        value={employee.nume || ''} 
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Prenume:</label>
                    <input
                        type="text"
                        name="prenume"
                        value={employee.prenume || ''} 
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Email:</label>
                    <input
                        type="email"
                        name="email"
                        value={employee.email||''}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Poziție:</label>
                    <input
                        type="text"
                        name="pozitie"
                        value={employee.pozitie||''}
                        onChange={handleChange}
                        required
                    />
                </div>
                {/* Adaugă alte câmpuri după nevoie */}
                <button type="submit">Salvează</button>
            </form>
        </div>
    );
};

export default EditEmployee;
