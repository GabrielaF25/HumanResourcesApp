import React from 'react';

const Sidebar = () => (
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
                    <li><a href="/find-employee">Cauta Angajat</a></li>
                  
                </ul>
            </nav>
        </div>
    </div>
);

export default Sidebar;
