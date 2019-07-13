import React, { Component } from "react";
import { Container, Row, Col } from "reactstrap";
import Program from "./Program";
import Select from "./Select";
import { Redirect } from "react-router-dom";

export class StudentInfo extends Component {
  state = {
    editStudentRedirect: false,
    myStudentsRedirect: false,
    studentId: "",
    studentInitial: "",
    remark: "",
    lastUpdated: "",
    programs: [],
    addProgramOptions: []
  };

  componentDidMount() {
    this.loadStudent();
    this.populateProgramData();
    this.getAddProgramOptions();
  }

  async loadStudent() {
    const response = await fetch("api/student/" + this.props.match.params.id);
    const data = await response.json();
    this.setState({
      studentId: data.studentId,
      studentInitial: data.studentInitial,
      remark: data.remark,
      lastUpdated: data.lastUpdated
    });
  }

  async populateProgramData() {
    //const token = await authService.getAccessToken();
    const response = await fetch(
      "api/student/programs/" + this.props.match.params.id
    );
    const data = await response.json();
    this.setState({
      programs: data
    });
  }

  async getAddProgramOptions() {
    const response = await fetch("api/program");
    let data = await response.json();
    data = data.filter(program => {
      for (var i = 0; i < this.state.programs.length; i++) {
        if (this.state.programs[i].id === program.id) {
          return false;
        }
      }
      return true;
    });
    this.setState({ addProgramOptions: data });
  }

  renderPrograms() {
    if (this.state.programs.length > 0) {
      return (
        <ul>
          {this.state.programs.map(p => (
            <li key={p.id}>
              <Program program={p} />
            </li>
          ))}
        </ul>
      );
    } else {
      return <p>No programs for this student</p>;
    }
  }

  handleProgramSelectInput = event => {
    let eventId = event.target.value;

    this.setState(state => ({
      programs: [
        ...state.programs,
        state.addProgramOptions.find(p => p.id.toString(10) === eventId)
      ],
      addProgramOptions: state.addProgramOptions.filter(
        p => p.id.toString(10) !== eventId
      )
    }));
  };

  handleEditStudentRedirect = () => {
    if (this.state.editStudentRedirect === false) {
      this.setState({
        editStudentRedirect: true
      });
    }
  };

  handleMyStudentsRedirect = () => {
    if (this.state.myStudentsRedirect === false) {
      this.setState({
        myStudentsRedirect: true
      });
    }
  };

  render() {
    if (this.state.editStudentRedirect) {
      let path = "/students/" + this.props.match.params.id + "/edit";
      return (
        <Redirect
          to={{
            pathname: path,
            student: {
              studentId: this.state.studentId,
              studentInitial: this.state.studentInitial,
              remark: this.state.remark
            }
          }}
        />
      );
    } else if (this.state.myStudentsRedirect) {
      let path = "/students";
      return (
        <Redirect
          to={{
            pathname: path
          }}
        />
      );
    } else {
      return (
        <Container>
          <h1>Student Information</h1>
          <button
            className="btn btn-primary"
            onClick={this.handleMyStudentsRedirect}
          >
            Back to My Students
          </button>

          <button
            className="btn btn-primary"
            onClick={this.handleEditStudentRedirect}
          >
            Edit Student
          </button>

          <Row>
            <Col>Student ID</Col>
            <Col>{this.state.studentId}</Col>
          </Row>
          <Row>
            <Col>Remark</Col>
            <Col>{this.state.remark}</Col>
          </Row>
          <Row>
            <Col>Last Updated</Col>
            <Col>{this.state.lastUpdated}</Col>
          </Row>

          <h2>Programs</h2>
          {this.renderPrograms()}
          {/* <Select
            title="Add existing Program"
            name={"addProgram"}
            value=""
            options={this.state.addProgramOptions}
            handleChange={this.handleProgramSelectInput}
            placeholder={"Select Program"}
            labelField="name"
          /> */}
        </Container>
      );
    }
  }
}
