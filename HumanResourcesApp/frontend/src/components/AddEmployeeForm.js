import React, { useState } from 'react';
import { addEmployee } from '../api';

const AddEmployeeForm = () => {
    const [formData, setFormData] = useState({
        nume: '',
        prenume: '',
        email: '',
        pozitie: '',
        dataAngajarii: '',
    });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        addEmployee(formData)
            .then(() => {
                alert('Angajat adăugat cu succes!');
                setFormData({
                    nume: '',
                    prenume: '',
                    email: '',
                    pozitie: '',
                    dataAngajarii: '',
                });
            })
            .catch((error) => {
                console.error('Eroare la adăugare:', error);
            });
    };

    return (
        <div className="container">
            <h1>Adaugă Angajat</h1>
            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label className="form-label">Nume</label>
                    <input
                        type="text"
                        name="nume"
                        className="form-control"
                        value={formData.nume}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label className="form-label">Prenume</label>
                    <input
                        type="text"
                        name="prenume"
                        className="form-control"
                        value={formData.prenume}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label className="form-label">Email</label>
                    <input
                        type="email"
                        name="email"
                        className="form-control"
                        value={formData.email}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label className="form-label">Pozitie</label>
                    <input
                        type="text"
                        name="pozitie"
                        className="form-control"
                        value={formData.pozitie}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label className="form-label">Data Angajării</label>
                    <input
                        type="date"
                        name="dataAngajarii"
                        className="form-control"
                        value={formData.dataAngajarii}
                        onChange={handleChange}
                        required
                    />
                </div>
                <button type="submit" className="btn btn-primary">Adaugă</button>
            </form>
        </div>
    );
};

export default AddEmployeeForm;
