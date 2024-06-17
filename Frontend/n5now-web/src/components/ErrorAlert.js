import React from 'react';

const ErrorAlert = ({ message }) => {
  return (
    <div className="alert alert-danger">
      {message}
    </div>
  );
};

export default ErrorAlert;
