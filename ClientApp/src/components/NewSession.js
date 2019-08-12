import React, { Component } from "react";
import { Container } from "reactstrap";
import Select from "./Select";
import Input from "./Input";
import { Redirect } from "react-router-dom";

export class NewSession extends Component {
  state = {
    addStudentOptions: [],
    addProgramOptions: [],
    selectedStudent: "",
    selectedProgram: "",
    sessionDescription: "",
    sessionId: ""
  };

  componentDidMount() {
    this.getAddStudentOptions();
  }

  async getAddStudentOptions() {
    const response = await fetch("api/student");
    let data = await response.json();
    this.setState({ addStudentOptions: data });
  }

  async getAddProgramOptions(studentId) {
    const response = await fetch("api/student/programs/" + studentId);
    let data = await response.json();
    this.setState({ addProgramOptions: data });
  }

  handleDescriptionInput = event => {
    let value = event.target.value;
    let name = event.target.name;
    this.setState({ sessionDescription: value });
  };

  handleStudentSelectInput = event => {
    let selectedStudentId = event.target.value;
    this.setState(state => ({
      selectedStudent: state.addStudentOptions.find(
        s => s.id.toString(10) === selectedStudentId
      )
    }));
    this.getAddProgramOptions(selectedStudentId);
  };

  handleProgramSelectInput = event => {
    let selectedProgramId = event.target.value;
    this.setState(state => ({
      selectedProgram: state.addProgramOptions.find(
        p => p.id.toString(10) === selectedProgramId
      )
    }));
  };

  handleStartSession = () => {
    let url = "api/session/create";
    let responsedata;
    fetch(url, {
      method: "POST",
      body: JSON.stringify({
        studentId: this.state.selectedStudent.id,
        description: this.state.sessionDescription
      }),
      cache: "no-cache",
      headers: {
        "content-type": "application/json"
      }
    })
      .then(response => response.json())
      .then(data => {
        responsedata = data.id;
      })
      .then(() => this.setState(() => ({ sessionId: responsedata })))
      .catch(err => console.error(err));
  };

  render() {
    if (this.state.sessionId) {
      return (
        <Redirect
          to={{
            pathname: "/session-data-collection/" + this.state.sessionId,
            student: this.state.selectedStudent,
            program: this.state.selectedProgram,
            description: this.state.sessionDescription
          }}
        />
      );
    } else {
      return (
        <Container>
          <h1>Start a new session</h1>
          {this.renderDescriptionInput()}
          {this.renderSelects()}
          {this.renderButton()}
        </Container>
      );
    }
  }

  renderDescriptionInput() {
    return (
      <div>
        <h2>Describe this session</h2>
        <Input
          inputType={"text"}
          name={"sessionDescription"}
          value={this.state.sessionDescription}
          placeholder={"Session description"}
          handleChange={this.handleDescriptionInput}
        />
      </div>
    );
  }

  renderButton() {
    if (this.state.selectedStudent && this.state.selectedProgram) {
      return (
        <button className="btn btn-primary" onClick={this.handleStartSession}>
          Start Session
        </button>
      );
    }
  }

  renderSelects() {
    if (this.state.selectedStudent) {
      return (
        <div>
          {this.renderStudentSelect()}
          {this.renderProgramSelect()}
        </div>
      );
    } else {
      return this.renderStudentSelect();
    }
  }

  renderStudentSelect() {
    return (
      <div>
        <h2>Choose a student for this session</h2>
        <Select
          title="Select Student"
          name={"addStudent"}
          value={this.state.selectedStudent.id}
          options={this.state.addStudentOptions}
          handleChange={this.handleStudentSelectInput}
          placeholder={"Select Student"}
          labelField="studentId"
        />
      </div>
    );
  }

  renderProgramSelect() {
    return (
      <div>
        <h2>Choose a starting program for this session</h2>
        <Select
          title="Select Program"
          name={"addProgram"}
          value={this.state.selectedProgram.id}
          options={this.state.addProgramOptions}
          handleChange={this.handleProgramSelectInput}
          placeholder={"Select Program"}
          labelField="name"
        />
      </div>
    );
  }
}
