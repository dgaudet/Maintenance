import React, { Component } from 'react';
import Task from './Task'

function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [year, month, day].join('-');
}

export default class TaskList extends Component {
  render() {
    return (
      <table className="task-table">
        <tbody>
        <tr>
          <td><h3>All tasks</h3></td>
          <td></td>
          <td></td>
          <td></td>
        </tr>
        <tr>
          <td><strong>VIN</strong></td>
          <td><strong>Type</strong></td>
          <td><strong>Date</strong></td>
          <td></td>
        </tr>
        {this.props.tasks.map(function(task){
          return (
            <Task VIN={task.VIN} type={task.type} typeDescription={task.TypeDescription} date={formatDate(task.Date)} key={task.VIN}/>
          );
        })}
        </tbody>
      </table>
    );
  }
}

TaskList.propTypes = {
  tasks: React.PropTypes.arrayOf(
    React.PropTypes.shape({
      VIN: React.PropTypes.string.isRequired,
      type: React.PropTypes.number.isRequired,
      TypeDescription: React.PropTypes.string.isRequired,
      Date: React.PropTypes.any.isRequired,
    })
  ).isRequired,
};
