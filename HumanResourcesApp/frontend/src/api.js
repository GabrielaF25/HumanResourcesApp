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
