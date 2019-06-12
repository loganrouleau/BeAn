import React, { Component } from "react";
import { Container, Row, Col } from "reactstrap";
import Program from "./Program";
import Select from "./Select";

export class Students extends Component {
  state = {
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

  render() {
    return (
      <Container>
        <h1>Student Information</h1>
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
        <h1>Programs</h1>
        {this.renderPrograms()}
        <Select
          title="Add existing Program"
          name={"addProgram"}
          value=""
          options={this.state.addProgramOptions}
          handleChange={this.handleProgramSelectInput}
          placeholder={"Select Program"}
        />
      </Container>
    );
  }
}
