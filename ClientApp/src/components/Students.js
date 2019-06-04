import React, { Component } from "react";
import { Container, Row, Col } from "reactstrap";

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
    console.log(this.props);
    const response = await fetch("api/student/" + this.props.match.params.id, {
      headers: {}
    });
    const data = await response.json();
    console.log(data);
    this.setState({
      studentId: data.studentId,
      studentInitial: data.studentInitial,
      remark: data.remark,
      programId: data.programId,
      lastUpdated: data.lastUpdated
    });
    console.log(this.state);
  }

  async populateProgramData() {
    //const token = await authService.getAccessToken();
    console.log("About to fetch ");
    const response = await fetch(
      "api/student/programs/" + this.props.match.params.id,
      {
        headers: {}
      }
    );
    const data = await response.json();
    console.log(data);
    this.setState({
      programIdOptions: Object.keys(data).map(i => data[i].name)
    });
  }

  render() {
    return (
      <Container>
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
        <Row>
          <Col>Programs</Col>
          <Col>{this.state.programIdOptions}</Col>
        </Row>
      </Container>
    );
  }
}
