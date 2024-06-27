// components/Spinner.js
import React from 'react';
import '../styles/Spinner.css';

const Spinner = () => (
  <div className="spinner-overlay">
    <div className="spinner-container">
      <div className="spinner-border text-light" role="status">
        <span className="visually-hidden">Loading...</span>
      </div>
    </div>
  </div>
);

export default Spinner;