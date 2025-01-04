import React, { useState } from 'react';
import { getEvaluariByAngajatId, deleteEvaluare } from '../api';
import { Link } from 'react-router-dom';

const EvaluationOverview = () => {
    const [angajatId, setAngajatId] = useState('');
    const [evaluari, setEvaluari] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);

    const handleSearch = async () => {
        setIsLoading(true);
        setError(null);
        try {
            const data = await getEvaluariByAngajatId(angajatId);
            setEvaluari(data);
        } catch (err) {
            console.error('Eroare la încărcarea evaluărilor:', err);
            setError('Nu am putut încărca evaluările pentru acest angajat.');
        } finally {
            setIsLoading(false);
        }
    };

    const handleDelete = async (id) => {
        if (!window.confirm('Sunteți sigur că doriți să ștergeți această evaluare?')) return;

        try {
            await deleteEvaluare(id);
            setEvaluari((prev) => prev.filter((evaluare) => evaluare.id !== id));
            alert('Evaluare ștearsă cu succes!');
        } catch (err) {
            console.error('Eroare la ștergerea evaluării:', err);
            alert('Nu s-a putut șterge evaluarea.');
        }
    };

    return (
        <div style={{ padding: '20px' }}>
            <h1>Vizualizare Evaluări Angajat</h1>
            <div style={{ marginBottom: '20px' }}>
                <input
                    type="text"
                    placeholder="Introduceți ID-ul angajatului"
                    value={angajatId}
                    onChange={(e) => setAngajatId(e.target.value)}
                    style={{ padding: '10px', marginRight: '10px' }}
                />
                <button onClick={handleSearch} style={{ padding: '10px 20px' }}>
                    Caută
                </button>
            </div>
            {isLoading && <p>Se încarcă...</p>}
            {error && <p style={{ color: 'red' }}>{error}</p>}
            {evaluari.length > 0 && (
                <ul>
                    {evaluari.map((evaluare) => (
                        <li
                            key={evaluare.id}
                            style={{
                                marginBottom: '20px',
                                padding: '10px',
                                border: '1px solid #ccc',
                                borderRadius: '5px',
                            }}
                        >
                            <p><strong>Data:</strong> {evaluare.dataEvaluare}</p>
                            <p><strong>Scor:</strong> {evaluare.scor}</p>
                            <p><strong>Comentarii:</strong> {evaluare.comentarii}</p>
                            <div style={{ marginTop: '10px' }}>
                                <Link
                                    to={`/edit-evaluation/${evaluare.id}`}
                                    style={{
                                        padding: '10px',
                                        backgroundColor: '#007bff',
                                        color: 'white',
                                        textDecoration: 'none',
                                        borderRadius: '5px',
                                        marginRight: '10px',
                                    }}
                                >
                                    Modifică
                                </Link>
                                <button
                                    onClick={() => handleDelete(evaluare.id)}
                                    style={{
                                        padding: '10px',
                                        backgroundColor: 'red',
                                        color: 'white',
                                        border: 'none',
                                        borderRadius: '5px',
                                    }}
                                >
                                    Șterge
                                </button>
                            </div>
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
};

export default EvaluationOverview;
