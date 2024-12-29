import React from 'react';

const Header = () => (
    <header id="header">
        <a href="/" className="logo"><strong>Welcome, Gabriela Formagiu</strong></a>
        <ul className="icons">
            {/* Poți păstra sau elimina aceste icon-uri, după preferință */}
            <li><a href="#" className="icon brands fa-twitter"><span className="label">Twitter</span></a></li>
            <li><a href="#" className="icon brands fa-facebook-f"><span className="label">Facebook</span></a></li>
            <li><a href="#" className="icon brands fa-instagram"><span className="label">Instagram</span></a></li>
        </ul>
    </header>
);

export default Header;
