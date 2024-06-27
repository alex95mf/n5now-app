import React, { useState } from 'react';
import { requestPermission } from '../services/permissionService';
import Spinner from './Spinner';

const PermissionForm = ({ onSubmit }) => {
  const [permission, setPermission] = useState({ nombreEmpleado: '', apellidoEmpleado: '', tipoPermiso: '1', fechaPermiso: '' });
  const [loading, setLoading] = useState(false);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setPermission((prev) => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      setLoading(true);
      const response = await requestPermission(permission);
      onSubmit(response);
      setPermission({ nombreEmpleado: '', apellidoEmpleado: '', tipoPermiso: '1', fechaPermiso: '' }); // Limpiar el formulario después de enviar
    } catch (error) {
      console.error('Error submitting permission:', error.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="card bg-secondary text-white mt-4 mb-4">
      <div className="card-body">
        <h5 className="card-title mb-3 text-white">Registrar Permiso</h5>
        {loading ? (
          <Spinner />
        ) : (
          <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <input
              type="text"
              className="form-control"
              name="nombreEmpleado"
              value={permission.nombreEmpleado}
              onChange={handleChange}
              placeholder="Nombre"
              required
            />
          </div>
          <div className="mb-3">
            <input
              type="text"
              className="form-control"
              name="apellidoEmpleado"
              value={permission.apellidoEmpleado}
              onChange={handleChange}
              placeholder="Apellido"
              required
            />
          </div>
          <div className="mb-3">
            <select
              className="form-select"
              name="tipoPermiso"
              value={permission.tipoPermiso}
              onChange={handleChange}
              required
            >
              <option value="1">Administrador</option>
              <option value="2">Usuario</option>
            </select>
          </div>
          <div className="mb-3">
            <input
              type="date"
              className="form-control"
              name="fechaPermiso"
              value={permission.fechaPermiso}
              onChange={handleChange}
              required
            />
          </div>
          <button type="submit" className="btn btn-success">Registrar</button>
        </form>
        )}        
      </div>
    </div>
  );
};

export default PermissionForm;
