import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import PermissionForm from './components/PermissionForm';
import PermissionList from './components/PermissionList';

function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route path="/" element={<PermissionList />} />
          <Route path="/request" element={<PermissionForm />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
