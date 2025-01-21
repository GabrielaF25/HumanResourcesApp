import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getDocumentById } from '../api';

const DocumentDetails = () => {
    const { id } = useParams(); // Get the document ID from the URL params
    const [document, setDocument] = useState(null);

    useEffect(() => {
        // Fetch the document details by ID
        getDocumentById(id)
            .then((response) => setDocument(response.data))
            .catch((error) => console.error('Eroare la obținerea documentului:', error));
    }, [id]);

    return (
        <div className="container">
            {document ? (
                <>
                    <h1>{document.nume}</h1>
                    <p><strong>Tip Document:</strong> {document.tipDocument}</p>
                    <p><strong>Data Încărcării:</strong> {new Date(document.dataIncarcare).toLocaleDateString()}</p>
                    <p><strong>ID Angajat:</strong> {document.angajatId}</p>
                </>
            ) : (
                <p>Se încarcă...</p>
            )}
        </div>
    );
};

export default DocumentDetails;
