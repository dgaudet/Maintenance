import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './index.css';

ReactDOM.render(
  <App url="http://localhost:52970/api/maintenancetask" pollInterval={10000000000}/>,
  document.getElementById('root')
);
