import React, { Component } from "react";
import { Container, Row, Col } from "reactstrap";
import Program from "./Program";

export class Students extends Component {
  state = {
    studentId: "",
    studentInitial: "",
    remark: "",
    programId: "",
    lastUpdated: "",
    programIdOptions: []
  };

  componentDidMount() {
    this.loadStudent();
    this.populateProgramData();
  }

  async loadStudent() {
    const response = await fetch("api/student/" + this.props.match.params.id, {
      headers: {}
    });
    const data = await response.json();
    this.setState({
      studentId: data.studentId,
      studentInitial: data.studentInitial,
      remark: data.remark,
      programId: data.programId,
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
      programIdOptions: data
    });
  }

  renderPrograms() {
    if (this.state.programIdOptions.length > 0) {
      return (
        <ul>
          {this.state.programIdOptions.map(p => (
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
      </Container>
    );
  }
}
