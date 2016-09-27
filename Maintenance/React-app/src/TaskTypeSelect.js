import React, { Component } from 'react';
import $ from 'jquery';

export default class TaskTypeSelect extends Component {
  constructor(props){
    super(props);
    this.state = {
      data: [],
    };
    this.loadTaskTypes = this.loadTaskTypes.bind(this);
  }

  loadTaskTypes = function(){
    var urlWithVIN = this.props.url + this.props.VIN

    $.ajax({
        url: urlWithVIN,
        dataType: 'json',
        cache: false,
        success: function (data){
            this.setState({data: data});
        }.bind(this),
        error: function(xhr, status, err){
            console.error(urlWithVIN, status, err.toString());
        }
    });
  }

  componentDidMount = function(){
    this.loadTaskTypes();
  }

  render(){
    return (
      <select id="TaskTypeSelect" className="form-control">
      {this.state.data.map(function(taskType){
        return(
          <option key={taskType.Type} value={taskType.Type}>{taskType.Description}</option>
        );
      })}
      </select>
    );
  }
}

TaskTypeSelect.propTypes = {
  VIN: React.PropTypes.string.isRequired,
  url: React.PropTypes.string.isRequired,
}
