import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { getConcediuForAngajat, getZileRamase, getZileConsumate, getZileTotale, deleteLeaveRequest } from '../api';

const LeaveOverview = () => {
    const [angajatId, setAngajatId] = useState('');
    const [leaveDetails, setLeaveDetails] = useState(null);
    const [zileRamase, setZileRamase] = useState(0);
    const [zileConsumate, setZileConsumate] = useState(0);
    const [zileTotale, setZileTotale] = useState(0);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);

    const handleSearch = async () => {
        setIsLoading(true);
        setError(null);
        setLeaveDetails(null);

        try {
            // Fetch general leave details
            const concediu = await getConcediuForAngajat(angajatId);
            setLeaveDetails(concediu);

            // Fetch leave-related data
            const zileRamaseData = await getZileRamase(angajatId);
            setZileRamase(zileRamaseData);

            const zileConsumateData = await getZileConsumate(angajatId);
            setZileConsumate(zileConsumateData);

            const zileTotaleData = await getZileTotale(angajatId);
            setZileTotale(zileTotaleData);
        } catch (err) {
            console.error('Eroare la încărcarea detaliilor despre concedii:', err);
            setError('Nu am putut încărca detaliile despre concedii pentru acest angajat.');
        } finally {
            setIsLoading(false);
        }
    };

    const handleDelete = async (requestId) => {
        if (!window.confirm('Sunteți sigur că doriți să ștergeți această cerere de concediu?')) return;

        try {
            await deleteLeaveRequest(angajatId, requestId);
            alert('Cererea de concediu a fost ștearsă cu succes.');
            setLeaveDetails((prevDetails) => ({
                ...prevDetails,
                cereriConcediuDTO: prevDetails.cereriConcediuDTO.filter((request) => request.id !== requestId),
            }));
        } catch (err) {
            console.error('Eroare la ștergerea cererii de concediu:', err);
            alert('Nu s-a putut șterge cererea de concediu.');
        }
    };

    return (
        <div style={{ padding: '20px' }}>
            <h1>Vizualizare Concedii Angajat</h1>
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
            {isLoading && <p>Se încarcă datele...</p>}
            {error && <p style={{ color: 'red' }}>{error}</p>}
            {leaveDetails && (
                <div>
                    <h2>Detalii Concediu</h2>
                    <div>
                        <p><strong>Zile totale anuale:</strong> {zileTotale}</p>
                        <p><strong>Zile consumate:</strong> {zileConsumate}</p>
                        <p><strong>Zile rămase:</strong> {zileRamase}</p>
                    </div>
                    <h3>Cereri de Concediu</h3>
                    {leaveDetails.cereriConcediuDTO.length === 0 ? (
                        <p>Nu există cereri de concediu pentru acest angajat.</p>
                    ) : (
                        <ul>
                            {leaveDetails.cereriConcediuDTO.map((request) => (
                                <li
                                    key={request.id}
                                    style={{
                                        marginBottom: '20px',
                                        padding: '10px',
                                        border: '1px solid #ccc',
                                        borderRadius: '5px',
                                    }}
                                >
                                    <p><strong>Data Început:</strong> {request.startDate}</p>
                                    <p><strong>Data Sfârșit:</strong> {request.endDate}</p>
                                    <p><strong>Motiv:</strong> {request.motiv}</p>
                                    <p><strong>Status:</strong> {request.status}</p>
                                    <div style={{ marginTop: '10px' }}>
                                        <Link
                                            to={`/edit-leave/${angajatId}/${request.id}`}
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
                                            onClick={() => handleDelete(request.id)}
                                            style={{
                                                padding: '10px',
                                                backgroundColor: 'red',
                                                color: 'black',
                                                textDecoration: 'none',
                                                borderRadius: '5px',
                                                marginRight: '10px',
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
            )}
        </div>
    );
};

export default LeaveOverview;
