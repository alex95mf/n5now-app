import React, { useEffect, useState } from 'react';
import { getPermissions } from '../services/permissionService';
import PermissionItem from './PermissionItem';
import PermissionForm from './PermissionForm';
import '../styles/PermissionList.css';

const PermissionList = () => {
  const [permissions, setPermissions] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchPermissions = async () => {
      try {
        const response = await getPermissions();
        setPermissions(response);
      } catch (err) {
        setError(err.message);
      }
    };
    fetchPermissions();
  }, []);

  const handleAddPermission = (newPermission) => {
    setPermissions([...permissions, newPermission]);
  };

  const getTipoPermisoDetalle = (tipoPermiso) => {
    switch (tipoPermiso) {
      case 1:
        return { id: 1, description: 'Administrador' };
      case 2:
        return { id: 2, description: 'Usuario' };
      default:
        return { id: tipoPermiso, description: 'Permiso desconocido' };
    }
  };

  const handleUpdatePermission = (updatedPermission) => {
    const updatedPermissions = permissions.map((perm) => {
      if (perm.id === updatedPermission.id) {
        return {
          ...updatedPermission,
          tipoPermisoDetalle: getTipoPermisoDetalle(updatedPermission.tipoPermiso),
        };
      }
      return perm;
    });
    setPermissions(updatedPermissions);
  };

  return (
    <div className="container mt-4">
      <div className="card shadow-sm p-3 mb-5 bg-body-tertiary rounded">
        <div className="header mb-4">
          <h2 className="header-title">Lista de Permisos</h2>
        </div>
        {error ? (
          <div className="alert alert-danger">{error}</div>
        ) : (
          <div>
            <div className="row">
              {permissions.map((permission) => (
                <div key={permission.id} className="col-md-4 mb-4">
                  <PermissionItem
                    permission={permission}
                    onUpdate={handleUpdatePermission}
                  />
                </div>
              ))}
            </div>
            <PermissionForm onSubmit={handleAddPermission} />
          </div>
        )}
      </div>
    </div>
  );
};

export default PermissionList;
