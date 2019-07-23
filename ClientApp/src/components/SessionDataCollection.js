import React, { Component } from "react";
import { Container } from "reactstrap";
import Select from "./Select";

export class SessionDataCollection extends Component {
  state = {
    isSessionActive: false,
    addStudentOptions: [],
    addProgramOptions: [],
    selectedStudent: "",
    selectedProgram: ""
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
    console.log("getting program options for student: " + studentId);
    console.log(this.state.selectedStudent);
    const response = await fetch("api/student/programs/" + studentId);
    let data = await response.json();
    this.setState({ addProgramOptions: data });
  }

  handleStudentSelectInput = event => {
    let selectedStudentId = event.target.value;
    console.log(selectedStudentId);

    this.setState(state => ({
      selectedStudent: state.addStudentOptions.find(
        s => s.id.toString(10) === selectedStudentId
      )
    }));
    console.log(this.state.selectedStudent);
    console.log(this.state.addStudentOptions);
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

  handleStartStopSession = () => {
    if (this.state.isSessionActive) {
      this.setState({
        isSessionActive: false
      });
    } else {
      this.setState({
        isSessionActive: true
      });
      let url = "api/session/create";
      let responsedata;
      fetch(url, {
        method: "POST",
        body: JSON.stringify(this.state.selectedStudent),
        cache: "no-cache",
        headers: {
          "content-type": "application/json"
        }
      })
        .then(response => response.json())
        .then(data => {
          responsedata = data.id;
        })
        .catch(err => console.error(err))
        .then(() =>
          this.setState(() => ({ redirectToStudentId: responsedata }))
        );
    }
  };

  render() {
    return (
      <Container>
        <h1>Record Data</h1>
        {this.renderSelects()}
        {this.renderButton()}
      </Container>
    );
  }

  renderButton() {
    if (this.state.selectedStudent) {
      return (
        <button
          className="btn btn-primary"
          onClick={this.handleStartStopSession}
        >
          {this.state.isSessionActive ? "End Session" : "Start Session"}
        </button>
      );
    }
  }

  renderSelects() {
    if (this.state.isSessionActive) {
      return <h2>Record data! (WIP - Logan July 11th)</h2>;
    } else {
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
  }

  renderStudentSelect() {
    return (
      <div>
        <h2>Choose a student for the session</h2>
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
        <h2>Choose a starting program for the session</h2>
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
