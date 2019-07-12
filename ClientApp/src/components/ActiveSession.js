import React, { Component } from "react";
import { Container, Row, Col } from "reactstrap";
import Program from "./Program";
import Select from "./Select";
import { Redirect } from "react-router-dom";

export class ActiveSession extends Component {
  state = {
    isSessionActive: false,
    addStudentOptions: [],
    selectedStudent: ""
  };

  componentDidMount() {
    this.getAddStudentOptions();
  }

  async getAddStudentOptions() {
    const response = await fetch("api/student");
    let data = await response.json();
    this.setState({ addStudentOptions: data });
  }

  handleStudentSelectInput = event => {
    let eventId = event.target.value;
    this.setState(state => ({
      selectedStudent: state.addStudentOptions.find(
        s => s.id.toString(10) === eventId
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
      let url = "https://localhost:5001/api/Session/create";
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
          console.log("Successful" + data);
          responsedata = data.id;
        })
        .catch(err => console.error(err))
        .then(() =>
          this.setState(() => ({ redirectToStudentId: responsedata }))
        );
    }
  };

  render() {
    console.log(this.state.selectedStudent);
    return (
      <Container>
        <h1>Record Data</h1>
        {/* <Row>
          <Col>Student ID</Col>
          <Col>{this.state.studentId}</Col>
        </Row> */}
        {this.renderStudentSelect()}
        <button
          className="btn btn-primary"
          onClick={this.handleStartStopSession}
        >
          {this.state.isSessionActive ? "End Session" : "Start Session"}
        </button>
      </Container>
    );
  }

  renderStudentSelect() {
    if (this.state.isSessionActive) {
      return <h2>Record data! (WIP - Logan July 11th)</h2>;
    } else {
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
  }
}
