import React from 'react';

const Sidebar = ({ onLogout }) => (
    <div id="sidebar">
        <div className="inner">
            <nav id="menu">
                <header className="major">
                    <h2>Menu</h2>
                </header>
                <ul>
                    <li><a href="/">Homepage</a></li>
                    <li><a href="/employees">Lista Angajați</a></li>
                    <li><a href="/add-employee">Adaugă Angajat</a></li>
                    <li><a href="/find-employee">Caută Angajat</a></li>
                    <li><a href="/leave-overview">Situație Concedii Angajat</a></li>
                    <li><a href="/evaluation-overview">Situație Evaluări Angajat</a></li>
                    <li><a href="/documents">Lista Documente</a></li> 
                    <li><a href="/add-document">Adaugă Document</a></li> 
                </ul>
            </nav>
            <footer>
                {/* Buton de logout */}
                <button
                    style={{
                        backgroundColor: 'red',
                        color: 'white',
                        padding: '10px 20px',
                        border: 'none',
                        cursor: 'pointer',
                        marginTop: '20px',
                        width: '100%',
                    }}
                    onClick={onLogout}
                >
                    Logout
                </button>
            </footer>
        </div>
    </div>
);

export default Sidebar;
