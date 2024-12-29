import axios from 'axios';

const apiClient = axios.create({
    baseURL: '/api', // Prefix pentru API
    headers: {
        'Content-Type': 'application/json',
    },
});
export const getEmployees = () => apiClient.get('/Angajat');
export const getEmployeeById = (id) => apiClient.get(`/Angajat/${id}`);
export const addEmployee = (data) => apiClient.post('/Angajat', data);
export const updateEmployee = (id, data) => apiClient.put(`/Angajat/${id}`, data);
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
        const response = await apiClient.get('/Concediu/count');
        return response.data;
    } catch (error) {
        console.error('Eroare la obținerea numărului de cereri de concediu:', error);
        throw error;
    }
};
