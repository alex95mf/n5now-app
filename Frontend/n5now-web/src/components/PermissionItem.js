import React, { useState } from 'react';
import { modifyPermission } from '../services/permissionService';
import ErrorAlert from './ErrorAlert';
import Spinner from './Spinner';

const PermissionItem = ({ permission, onUpdate }) => {
  const [editing, setEditing] = useState(false);
  const [editedPermission, setEditedPermission] = useState({ ...permission });
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setEditedPermission(prev => ({ ...prev, [name]: value }));
  };

  const handleEdit = () => {
    setEditing(true);
  };

  const handleUpdate = async () => {
    try {
      setLoading(true);
      const updatedPermission = await modifyPermission(editedPermission.id, editedPermission);
      onUpdate(updatedPermission);
      setEditing(false);
      setError(null);
    } catch (error) {
      setError(`Error updating permission: ${error.message}`);
    } finally {
      setLoading(false);
    }
  };

  const handleCancelEdit = () => {
    setEditedPermission({ ...permission });
    setEditing(false);
  };

  return (
    <div className="card bg-light">
      <div className="card-body">
        {error && <ErrorAlert message={error} />}
        {editing ? (
          <div>
            <input
              type="text"
              className="form-control mb-2"
              name="nombreEmpleado"
              value={editedPermission.nombreEmpleado}
              onChange={handleChange}
            />
            <input
              type="text"
              className="form-control mb-2"
              name="apellidoEmpleado"
              value={editedPermission.apellidoEmpleado}
              onChange={handleChange}
            />
            <select
              className="form-select mb-2"
              name="tipoPermiso"
              value={editedPermission.tipoPermiso}
              onChange={handleChange}
            >
              <option value="1">Administrador</option>
              <option value="2">Usuario</option>
            </select>
            <input
              type="date"
              className="form-control mb-2"
              name="fechaPermiso"
              value={editedPermission.fechaPermiso}
              onChange={handleChange}
            />
          </div>
        ) : (
          <div>
            <h5 className="mb-1">{permission.nombreEmpleado} {permission.apellidoEmpleado}</h5>
            <p className="mb-1">{permission.tipoPermisoDetalle.description}</p>
            <small>Fecha: {new Date(permission.fechaPermiso).toLocaleDateString()}</small>
          </div>
        )}
      </div>
      <div className="card-footer">
        {loading ? (
          <Spinner />
        ) : editing ? (
          <div>
            <button className="btn btn-sm btn-success mx-2" onClick={handleUpdate}>
              Guardar cambios
            </button>
            <button className="btn btn-sm btn-secondary mx-2" onClick={handleCancelEdit}>
              Cancelar
            </button>
          </div>
        ) : (
          <button className="btn btn-sm btn-primary mx-2" onClick={handleEdit}>
            Editar
          </button>
        )}
      </div>
    </div>
  );
};

export default PermissionItem;