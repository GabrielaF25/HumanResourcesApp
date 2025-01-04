import axios from 'axios';

const apiClient = axios.create({
    baseURL: '/api', // Prefix pentru API
    headers: {
        'Content-Type': 'application/json',
    },
});
export const getEmployees = () => apiClient.get(`/Angajat`);
export const getEmployeeById = async (id) => {
    try {
        const response = await apiClient.get(`/Angajat/${id}`);
        return response.data; // API-ul trebuie să returneze un obiect JSON valid
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
        return response.data;
    } catch (error) {
        console.error('Eroare la obținerea numărului de angajați:', error);
        throw error;
    }
};
export const getLeaveRequestsCount = async () => {
    try {
        const response = await apiClient.get(`/1/concediu/count`);
        return response.data;
    } catch (error) {
        console.error('Eroare la obținerea numărului de cereri de concediu:', error);
        throw error;
    }
};
export const getEvaluationCounts = async () => {
    try {
        const response = await apiClient.get(`/1/Evaluare/aprobate`);
        return response.data;
    }
    catch (error) {
        console.error('Eroare la obținerea numărului de cereri de concediu:', error);
        throw error;
    }
}
export const getConcediuForAngajat = async (angajatId) => {
    try {
        const response = await apiClient.get(`/${angajatId}/concediu`);
        return response.data;
    } catch (error) {
        console.error('Eroare la obținerea concediilor:', error);
        throw error;
    }
};
export const getZileRamase = async (angajatId) => {
    try {
        const response = await apiClient.get(`/${angajatId}/concediu/zile-ramase`);
        return response.data;
    } catch (error) {
        console.error('Eroare la obținerea zilelor rămase:', error);
        throw error;
    }
};

// Obține numărul de zile consumate pentru un angajat
export const getZileConsumate = async (angajatId) => {
    try {
        const response = await apiClient.get(`/${angajatId}/concediu/zile-consumate`);
        return response.data;
    } catch (error) {
        console.error('Eroare la obținerea zilelor consumate:', error);
        throw error;
    }
};

// Obține numărul total de zile disponibile pentru un angajat
export const getZileTotale = async (angajatId) => {
    try {
        const response = await apiClient.get(`/${angajatId}/concediu/zile-totale`);
        return response.data;
    } catch (error) {
        console.error('Eroare la obținerea zilelor totale:', error);
        throw error;
    }
};
export const addLeaveRequest = async (angajatId, leaveRequest) => {
    try {
        const response = await apiClient.post(`${angajatId}/concediu`, leaveRequest);
        return response.data;
    } catch (error) {
        console.error('Eroare la adaugarea cererii de concediu:', error);
        throw error;
    }
};
export const updateLeaveRequest = async (angajatId, cerereId, leaveRequest) => {
    try {
        await apiClient.put(`/${angajatId}/concediu/${cerereId}`, leaveRequest);
    } catch (error) {
        console.error('Eroare la actualizarea cererii de concediu:', error);
        throw error;
    }
};
export const deleteLeaveRequest = async (angajatId, cerereId) => {
    try {
        await apiClient.delete(`/${angajatId}/concediu/${cerereId}`);
    } catch (error) {
        console.error('Eroare la ștergerea cererii de concediu:', error);
        throw error;
    }
}
// Obține evaluările unui angajat
export const getEvaluariByAngajatId = async (idAngajat) => {
    try {
        const response = await apiClient.get(`/${idAngajat}/evaluare`);
        return response.data;
    } catch (error) {
        console.error('Eroare la obținerea evaluărilor:', error);
        throw error;
    }
};

// Adaugă o evaluare
export const addEvaluare = async (idAngajat, evaluareData) => {
    try {
        const response = await apiClient.post(`/${idAngajat}/evaluare`, evaluareData);
        return response.data;
    } catch (error) {
        console.error('Eroare la adăugarea evaluării:', error);
        throw error;
    }
};

// Modifică o evaluare
export const updateEvaluare = async (id, evaluareData) => {
    try {
        await apiClient.put(`/evaluare/${id}`, evaluareData);
    } catch (error) {
        console.error('Eroare la actualizarea evaluării:', error);
        throw error;
    }
};

// Șterge o evaluare
export const deleteEvaluare = async (id) => {
    try {
        await apiClient.delete(`/evaluare/${id}`);
    } catch (error) {
        console.error('Eroare la ștergerea evaluării:', error);
        throw error;
    }
};

