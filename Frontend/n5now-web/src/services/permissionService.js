import axios from 'axios';

const API_URL = 'http://localhost:5283/api/permissions';

export const getPermissions = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    if (error.response) {
      // El servidor respondió con un código de error (4xx o 5xx)
      throw new Error(`Server responded with status ${error.response.status}: ${error.response.data}`);
    } else if (error.request) {
      // La solicitud se hizo pero no se recibió respuesta
      throw new Error('No response received from server. Please check your connection.');
    } else {
      // Ocurrió un error antes de que se enviara la solicitud
      throw new Error('Failed to send request to server.');
    }
  }
};

export const requestPermission = async (permission) => {
  try {
    const response = await axios.post(API_URL, permission);
    return response.data;
  } catch (error) {
    if (error.response) {
      throw new Error(`Server responded with status ${error.response.status}: ${error.response.data}`);
    } else if (error.request) {
      throw new Error('No response received from server. Please check your connection.');
    } else {
      throw new Error('Failed to send request to server.');
    }
  }
};

export const modifyPermission = async (id, permission) => {
  try {
    const response = await axios.put(`${API_URL}/${id}`, permission);
    return response.data;
  } catch (error) {
    if (error.response) {
      throw new Error(`Server responded with status ${error.response.status}: ${error.response.data}`);
    } else if (error.request) {
      throw new Error('No response received from server. Please check your connection.');
    } else {
      throw new Error('Failed to send request to server.');
    }
  }
};
