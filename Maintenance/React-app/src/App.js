import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import TaskList from './TaskList'
import TaskTypeSelect from './TaskTypeSelect'
import $ from 'jquery';

var TASKS = [
  {VIN: "1234VIN", type: "Oil Change", date: "Jan 1, 1999"},
  {VIN: "13VIN", type: "Oil Change", date: "Feb 12, 2009"},
]

class App extends Component {
  constructor(props){
    super(props);
    this.state = {
      data: [],
    };
    this.loadTasksFromServer = this.loadTasksFromServer.bind(this);
  }

  loadTasksFromServer = function(){
    $.ajax({
        url: this.props.url,
        dataType: 'json',
        cache: false,
        success: function (data){
            this.setState({data: data});
        }.bind(this),
        error: function(xhr, status, err){
            console.error(this.props.url, status, err.toString());
        }.bind(this)
    });
  }

  componentDidMount = function(){
      this.loadTasksFromServer();
      setInterval(this.loadTasksFromServer, this.props.pollInterval);
  }

  render() {
    return (
      <div className="App">
        <div className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h2>Welcome to React</h2>
        </div>
        <TaskList tasks={this.state.data}/>
        <TaskTypeSelect VIN="RedCar1" url="http://localhost:52970/api/maintenancetasktype/" />
      </div>
    );
  }
}

App.propTypes = {
  url: React.PropTypes.string.isRequired,
  pollInterval: React.PropTypes.number.isRequired,
}

export default App;
