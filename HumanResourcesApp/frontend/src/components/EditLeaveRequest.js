import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getConcediuForAngajat, updateLeaveRequest } from '../api'; // Funcții din API

const EditLeaveRequest = () => {
    const { angajatId, requestId } = useParams(); // Preia angajatId și requestId din URL
    const navigate = useNavigate();

    const [leaveRequest, setLeaveRequest] = useState({
        dataInceput: '',
        dataSfarsit: '',
        status: '',
        motiv:'',
    });
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchLeaveRequest = async () => {
            try {
                const concediuData = await getConcediuForAngajat(angajatId);
                const request = concediuData.cereriConcediuDTO.find(
                    (req) => req.id === parseInt(requestId)
                );
                if (!request) {
                    throw new Error('Cererile de concediu nu au fost găsite.');
                }
                setLeaveRequest(request);
            } catch (err) {
                console.error('Eroare la încărcarea cererii de concediu:', err);
                setError('Nu s-au putut încărca datele cererii de concediu.');
            } finally {
                setIsLoading(false);
            }
        };

        fetchLeaveRequest();
    }, [angajatId, requestId]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setLeaveRequest((prev) => ({
            ...prev,
            [name]: value,
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await updateLeaveRequest(angajatId, requestId, leaveRequest);
            alert('Cererea de concediu a fost actualizată cu succes!');
            navigate(`/leave-details/${angajatId}`); // Redirecționează înapoi la lista de cereri
        } catch (err) {
            console.error('Eroare la actualizarea cererii de concediu:', err);
            setError('Actualizarea cererii de concediu a eșuat.');
        }
    };

    if (isLoading) {
        return <p>Se încarcă datele cererii de concediu...</p>;
    }

    if (error) {
        return <p style={{ color: 'red' }}>{error}</p>;
    }

    return (
        <div style={{ padding: '20px' }}>
            <h2>Editare Cerere de Concediu</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Data Început:</label>
                    <input
                        type="date"
                        name="dataInceput"
                        value={leaveRequest.dataInceput}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Data Sfârșit:</label>
                    <input
                        type="date"
                        name="dataSfarsit"
                        value={leaveRequest.dataStarsit}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label>Status:</label>
                    <select
                        name="status"
                        value={leaveRequest.status}
                        onChange={handleChange}
                        required
                    >
                        <option value="Aprobat">Aprobat</option>
                        <option value="Respins">Respins</option>
                        <option value="În Așteptare">În Așteptare</option>
                    </select>
                </div>
                <div>
                    <label>Motiv:</label>
                    <input
                        name="motiv"
                        value={leaveRequest.motiv}
                        onChange={handleChange}
                        required
                    >        
                    </input>
                </div>
                <button type="submit">Salvează</button>
            </form>
        </div>
    );
};

export default EditLeaveRequest;
