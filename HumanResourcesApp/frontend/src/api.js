import axios from 'axios';

const apiClient = axios.create({
    baseURL: '/api', // Prefix pentru API
    headers: {
        'Content-Type': 'application/json',
    },
});

// Employee API calls
export const getEmployees = () => apiClient.get(`/Angajat`);
export const getEmployeeById = async (id) => {
    try {
        const response = await apiClient.get(`/Angajat/${id}`);
        return response.data; // Return the employee data
    } catch (error) {
        console.error('Eroare la obținerea angajatului:', error);
        throw error;
    }
};
export const updateEmployee = (id, data) => apiClient.put(`/Angajat/${id}`, data);
export const addEmployee = (data) => apiClient.post(`/Angajat`, data);
export const deleteEmployee = (id) => apiClient.delete(`/Angajat/${id}`);
export const getEmployeeCount = async () => {
    try {
        const response = await apiClient.get('/Angajat/count');
        return response.data; // Return employee count
    } catch (error) {
        console.error('Eroare la obținerea numărului de angajați:', error);
        throw error;
    }
};

// Leave API calls
export const getLeaveRequestsCount = async () => {
    try {
        const response = await apiClient.get(`/1/concediu/count`);
        return response.data; // Return leave requests count
    } catch (error) {
        console.error('Eroare la obținerea numărului de cereri de concediu:', error);
        throw error;
    }
};
export const getConcediuForAngajat = async (angajatId) => {
    try {
        const response = await apiClient.get(`/${angajatId}/concediu`);
        return response.data; // Return leave data for employee
    } catch (error) {
        console.error('Eroare la obținerea concediilor:', error);
        throw error;
    }
};
export const getZileRamase = async (angajatId) => {
    try {
        const response = await apiClient.get(`/${angajatId}/concediu/zile-ramase`);
        return response.data; // Return remaining days
    } catch (error) {
        console.error('Eroare la obținerea zilelor rămase:', error);
        throw error;
    }
};

// Document API calls

// Get all documents
export const getDocuments = async () => {
    try {
        const response = await apiClient.get(`/Document`);
        return response.data; // Returns the list of documents
    } catch (error) {
        console.error('Error getting documents:', error);
        throw error; // Re-throw the error for handling in the component
    }
};

// Get a document by ID
export const getDocumentById = async (id) => {
    try {
        const response = await apiClient.get(`/Document/${id}`);
        return response.data; // Returns the document details
    } catch (error) {
        console.error('Error getting document by ID:', error);
        throw error; // Re-throw the error for handling in the component
    }
};

// Add a new document
export const addDocument = async (documentData) => {
    try {
        const response = await apiClient.post(`/Document`, documentData);
        return response.data; // Returns the newly created document
    } catch (error) {
        console.error('Error adding document:', error);
        throw error; // Re-throw the error for handling in the component
    }
};

// Update an existing document
export const updateDocument = async (id, documentData) => {
    try {
        const response = await apiClient.put(`/Document/${id}`, documentData);
        return response.data; // Returns the updated document
    } catch (error) {
        console.error('Error updating document:', error);
        throw error; // Re-throw the error for handling in the component
    }
};

// Delete a document by ID
export const deleteDocument = async (id) => {
    try {
        await apiClient.delete(`/Document/${id}`);
    } catch (error) {
        console.error('Error deleting document:', error);
        throw error; // Re-throw the error for handling in the component
    }
};

// Evaluation API calls
export const getEvaluariByAngajatId = async (idAngajat) => {
    try {
        const response = await apiClient.get(`/${idAngajat}/evaluare`);
        return response.data; // Returns the evaluations for an employee
    } catch (error) {
        console.error('Eroare la obținerea evaluărilor:', error);
        throw error;
    }
};

export const addEvaluare = async (idAngajat, evaluareData) => {
    try {
        const response = await apiClient.post(`/${idAngajat}/evaluare`, evaluareData);
        return response.data; // Returns the created evaluation
    } catch (error) {
        console.error('Eroare la adăugarea evaluării:', error);
        throw error;
    }
};

export const updateEvaluare = async (id, evaluareData) => {
    try {
        await apiClient.put(`/evaluare/${id}`, evaluareData);
    } catch (error) {
        console.error('Eroare la actualizarea evaluării:', error);
        throw error;
    }
};

export const deleteEvaluare = async (id) => {
    try {
        await apiClient.delete(`/evaluare/${id}`);
    } catch (error) {
        console.error('Eroare la ștergerea evaluării:', error);
        throw error;
    }
};
