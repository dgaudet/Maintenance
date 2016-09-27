import React, { Component } from 'react';

export default class Task extends Component {
  render () {
    return (
      <tr>
        <td>{this.props.VIN}</td>
        <td>{this.props.typeDescription}</td>
        <td>{this.props.date}</td>
        <td>
            <a className="btn btn-primary">View</a>
        </td>
      </tr>
    );
  }
}

Task.propTypes = {
  VIN: React.PropTypes.string.isRequired,
  type: React.PropTypes.number.isRequired,
  typeDescription: React.PropTypes.string.isRequired,
  date: React.PropTypes.string.isRequired,
};
