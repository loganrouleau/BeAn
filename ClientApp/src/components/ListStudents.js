import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import { Container } from "reactstrap";

export class ListStudents extends Component {
  state = {
    newStudentRedirect: false,
    students: []
  };

  componentDidMount() {
    this.populateStudentData();
  }

  async populateStudentData() {
    const response = await fetch("api/student");
    let data = await response.json();
    this.setState({ students: data });
  }

  renderStudents() {
    if (this.state.students.length > 0) {
      return (
        <ul>
          {this.state.students.map(s => (
            <li key={s.id}>
              <a href={"/students/" + s.id}>
                Name: {s.studentId} Id: {s.id}
              </a>
            </li>
          ))}
        </ul>
      );
    } else {
      return <p>No programs for this student</p>;
    }
  }

  handleNewStudentRedirect = () => {
    if (this.state.newStudentRedirect === false) {
      this.setState({
        newStudentRedirect: true
      });
    }
  };

  render() {
    if (this.state.newStudentRedirect) {
      return <Redirect to="/students/create" />;
    } else {
      return (
        <Container>
          <h1>Students</h1>
          <button
            className="btn btn-primary"
            onClick={this.handleNewStudentRedirect}
          >
            New Student
          </button>
          {this.renderStudents()}
        </Container>
      );
    }
  }
}
