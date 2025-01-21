import React, { useState } from 'react';
import { addDocument } from '../api';

const DocumentForm = () => {
    const [formData, setFormData] = useState({
        nume: '',
        tipDocument: '',
        dataIncarcare: '',
        angajatId: '',  // Assuming the document is associated with an employee
    });

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        addDocument(formData)
            .then(() => {
                alert('Document adăugat cu succes!');
                setFormData({
                    nume: '',
                    tipDocument: '',
                    dataIncarcare: '',
                    angajatId: '',
                });
            })
            .catch((error) => {
                console.error('Eroare la adăugare:', error);
            });
    };

    return (
        <div className="container">
            <h1>Adaugă Document</h1>
            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label className="form-label">Nume Document</label>
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
                    <label className="form-label">Tip Document</label>
                    <input
                        type="text"
                        name="tipDocument"
                        className="form-control"
                        value={formData.tipDocument}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label className="form-label">Data Încărcării</label>
                    <input
                        type="date"
                        name="dataIncarcare"
                        className="form-control"
                        value={formData.dataIncarcare}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="mb-3">
                    <label className="form-label">ID Angajat</label>
                    <input
                        type="number"
                        name="angajatId"
                        className="form-control"
                        value={formData.angajatId}
                        onChange={handleChange}
                        required
                    />
                </div>
                <button type="submit" className="btn btn-primary">Adaugă Document</button>
            </form>
        </div>
    );
};

export default DocumentForm;
