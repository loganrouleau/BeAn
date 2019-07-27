import React, { Component } from "react";
import { Container } from "reactstrap";

export class SessionDataCollection extends Component {
  state = {
    sessionId: "",
    program: "",
    description: "",
    targets: ""
  };

  constructor(props) {
    // TODO: Load program/session from backend if they're not passed in as props
    super(props);
    if (props.location.program) {
      this.state.sessionId = props.match.params.id;
      this.state.program = props.location.program;
      this.state.description = props.location.description;
    }
  }

  componentDidMount() {
    console.log(this.props);
    this.getTargets();
  }

  async getTargets() {
    const response = await fetch(
      "api/program/targets/" + this.state.program.id
    );
    let data = await response.json();
    console.log("data: ");
    console.log(data);
    this.setState({ targets: data });
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

  handleStopSession = () => {};

  render() {
    console.log(this.state);
    return (
      <Container>
        <h1>Start recording your data!</h1>
        {this.renderButton()}
      </Container>
    );
  }

  renderButton() {
    return (
      <button className="btn btn-primary" onClick={this.handleStopSession}>
        End Session
      </button>
    );
  }
}
