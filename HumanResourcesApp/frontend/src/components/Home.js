﻿import React, { useEffect, useState } from 'react';
import { getEmployeeCount, getLeaveRequestsCount, getEvaluationCounts } from '../api'; // Funcția care face apelul API

const Home = () => {
    const [employeeCount, setEmployeeCount] = useState(0); // Stocăm numărul angajaților
    const [isLoading, setIsLoading] = useState(true); // Pentru a afișa un mesaj de încărcare
    const [leaveRequestsCount, setLeaveRequestsCount] = useState(0);
    const [evaluationsCount, setEvaluationCounts] = useState(0);
    useEffect(() => {
        // Funcție pentru a obține toate datele necesare
        const fetchData = async () => {
            try {
                // Rulăm toate apelurile API în paralel
                const [employeeCount, leaveRequestsCount, evaluationCounts] = await Promise.all([
                    getEmployeeCount(),
                    getLeaveRequestsCount(),
                    getEvaluationCounts()
                ]);

                // Setăm stările pentru fiecare rezultat
                console.log('Număr angajați primit:', employeeCount); // DEBUG
                setEmployeeCount(employeeCount);

                console.log('Număr concedii aprobate:', leaveRequestsCount); // DEBUG
                setLeaveRequestsCount(leaveRequestsCount);

                console.log('Număr evaluări:', evaluationCounts); // DEBUG
                setEvaluationCounts(evaluationCounts);
            } catch (error) {
                console.error('Eroare la încărcarea datelor:', error);
            } finally {
                // Setăm încărcarea ca finalizată
                setIsLoading(false);
            }
        };

        fetchData();
    }, []); // Se execută o singură dată la montarea componentei

    return (

        <section id="home" style={{ padding: '20px' }}>
            {/* Titlul principal */}
            <header>
                <h1>Bine ai venit la Human Resources App</h1>
            </header>

            {/* Descrierea aplicației */}
            <p>
                Această aplicație este destinată gestionării resurselor umane. Funcționalitățile includ:
                <ul>
                    <li>Adăugarea, modificarea și ștergerea angajaților</li>
                    <li>Gestionarea cererilor de concediu</li>
                    <li>Evaluarea performanțelor angajaților</li>
                    <li>Stocarea documentelor asociate fiecărui angajat</li>
                </ul>
                Explorează meniul din stânga pentru a accesa funcționalitățile aplicației.
            </p>

            {/* Secțiunea cu statistici */}
            <div className="stats" style={{ marginTop: '40px', textAlign: 'center' }}>
                <h2>Statistici:</h2>
                <div className="stat-items" style={{ display: 'flex', justifyContent: 'center', gap: '20px' }}>
                    <div className="stat-item" style={statItemStyle}>
                        <h3>{isLoading ? 'Se încarcă...' : employeeCount}</h3>
                        <p>Angajați înregistrați</p>
                    </div>
                    <div className="stat-item" style={statItemStyle}>
                        <h3>{isLoading ? 'Se încarcă...' : leaveRequestsCount}</h3>
                        <p>Cereri de concediu procesate</p>
                    </div>
                    <div className="stat-item" style={statItemStyle}>
                        <h3>{isLoading ? 'Se încarcă...' : evaluationsCount}</h3>
                        <p>Evaluări finalizate</p>
                    </div>
                </div>
            </div>

            {/* Secțiunea cu galerie foto */}
            <div className="gallery" style={{ marginTop: '40px', textAlign: 'center' }}>
                <h2>Galerie foto</h2>
                <div className="images" style={{ display: 'flex', justifyContent: 'center', gap: '15px' }}>
                    <img src="/assets/images/team1.jpg" alt="Echipa 1" style={imageStyle} />
                    <img src="/assets/images/team2.jpg" alt="Echipa 2" style={imageStyle} />
                    <img src="/assets/images/team3.jpg" alt="Echipa 3" style={imageStyle} />
                </div>
            </div>


            {/* Secțiunea cu testimoniale */}
            <div className="testimonials" style={testimonialStyle}>
                <h2>Ce spun utilizatorii:</h2>
                <div className="testimonial" style={{ marginTop: '20px', textAlign: 'center' }}>
                    <p>"Această aplicație mi-a simplificat enorm munca!"</p>
                    <p>- Manager HR</p>
                </div>
                <div className="testimonial" style={{ marginTop: '20px', textAlign: 'center' }}>
                    <p>"Interfața este simplă și ușor de folosit."</p>
                    <p>- Specialist HR</p>
                </div>
            </div>
        </section>
    );
};

// Stiluri personalizate pentru fiecare secțiune
const statItemStyle = {
    background: '#f9f9f9',
    borderRadius: '8px',
    padding: '20px',
    boxShadow: '0 2px 4px rgba(0, 0, 0, 0.1)',
};

const imageStyle = {
    width: '200px',
    height: '150px',
    objectFit: 'cover',
    borderRadius: '8px',
    boxShadow: '0 2px 4px rgba(0, 0, 0, 0.1)',
};

const ctaButtonStyle = {
    padding: '15px 30px',
    fontSize: '1.2em',
    backgroundColor: '#007bff',
    color: 'white',
    border: 'none',
    borderRadius: '8px',
    cursor: 'pointer',
};

const testimonialStyle = {
    marginTop: '40px',
    padding: '20px',
    background: '#f8f9fa',
    borderRadius: '8px',
    boxShadow: '0 2px 4px rgba(0, 0, 0, 0.1)',
};

export default Home;
