import React, { useEffect, useState } from 'react';
import { getConcediuForAngajat } from '../api';
import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';
const LeaveRequestList = () => {
    const { angajatId } = useParams(); 
    const [leaveRequests, setLeaveRequests] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchLeaveRequests = async () => {
            try {
                const concediuData = await getConcediuForAngajat(angajatId);
                console.log('Date concediu:', concediuData); // DEBUG
                setLeaveRequests(concediuData.cereriConcediuDTO || []); // Accesăm cereriConcediuDTO
            } catch (err) {
                console.error('Eroare la încărcarea cererilor de concediu:', err);
                setError('Nu am putut încărca datele despre concedii.');
            } finally {
                setIsLoading(false);
            }
        };

        fetchLeaveRequests();
    }, [angajatId]);

    if (isLoading) {
        return <p>Se încarcă cererile de concediu...</p>;
    }

    if (error) {
        return <p style={{ color: 'red' }}>{error}</p>;
    }

    if (leaveRequests.length === 0) {
        return <p>Nu există cereri de concediu pentru acest angajat.</p>;
    }

    return (
        <div>
            <h2>Cereri de Concediu</h2>
            <ul>
                {leaveRequests.map((request) => (
                    <li key={request.id} style={{ marginBottom: '20px', padding: '10px', border: '1px solid #ccc', borderRadius: '5px' }}>
                        <p><strong>Data Început:</strong> {request.dataInceput}</p>
                        <p><strong>Data Sfârșit:</strong> {request.dataSfarsit}</p>
                        <p><strong>Status:</strong> {request.status}</p>
                        <p><strong>Motiv:</strong> {request.motiv}</p>
                        <Link
                            to={`/edit-leave/${angajatId}/${request.id}`}
                            style={{
                                display: 'inline-block',
                                marginTop: '10px',
                                padding: '10px 20px',
                                backgroundColor: '#007bff',
                                color: 'white',
                                textDecoration: 'none',
                                borderRadius: '5px',
                            }}
                        >
                            Modifică
                        </Link>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default LeaveRequestList;
