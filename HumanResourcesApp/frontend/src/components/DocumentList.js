import React, { useEffect, useState } from 'react';
import { getDocuments, deleteDocument } from '../api';
import { useNavigate } from 'react-router-dom';

const DocumentList = () => {
    const [documents, setDocuments] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        getDocuments()
            .then((response) => setDocuments(response.data))
            .catch((error) => console.error('Eroare la obținerea documentelor:', error));
    }, []);

    return (
        <div className="container mt-4">
            <div className="d-flex justify-content-between align-items-center mb-4">
                <h1>Lista Documentelor</h1>
                <button
                    className="btn btn-primary"
                    onClick={() => navigate('/add-document')}
                >
                    Adaugă Document
                </button>
            </div>
            <table className="table table-striped table-hover">
                <thead className="table-dark">
                    <tr>
                        <th>ID</th>
                        <th>Nume</th>
                        <th>Tip Document</th>
                        <th>Data Încărcării</th>
                        <th>ID Angajat</th>
                        <th>Acțiuni</th>
                    </tr>
                </thead>
                <tbody>
                    {documents.map((doc) => (
                        <tr key={doc.id}>
                            <td>{doc.id}</td>
                            <td>{doc.nume}</td>
                            <td>{doc.tipDocument}</td>
                            <td>{new Date(doc.dataIncarcare).toLocaleDateString()}</td>
                            <td>{doc.angajatId}</td>
                            <td>
                                <button
                                    className="btn btn-danger"
                                    onClick={() => {
                                        deleteDocument(doc.id)
                                            .then(() => {
                                                alert('Document șters cu succes!');
                                                setDocuments(documents.filter(d => d.id !== doc.id));
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

export default DocumentList;
