import React, { Component } from "react";
import { Container } from "reactstrap";
import Trial from "./Trial";

export class SessionDataCollection extends Component {
  state = {
    sessionId: "",
    program: "",
    description: "",
    targets: []
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
    this.getTargets();
  }

  getTargets = async function() {
    const response = await fetch(
      "api/program/targets/" + this.state.program.id
    );
    let data = await response.json();
    this.setState({ targets: data }, () => {
      this.state.targets.forEach((target, index) => {
        this.getPrompts(target, index);
      });
    });
  };

  getPrompts = async function(target, index) {
    const response = await fetch("api/target/prompts/" + target.id);
    let data = await response.json();
    let targets = this.state.targets;
    targets[index].prompts = data;
    this.setState({ targets: targets });
  };

  handleStopSession = () => {};

  render() {
    console.log(this.state);
    return (
      <Container>
        <h1>Start recording your data!</h1>
        <p>{"Session description: " + this.state.description}</p>
        {this.renderCurrentProgram()}
        {this.renderPrompts()}
        {this.renderStopSessionButton()}
      </Container>
    );
  }

  renderCurrentProgram() {
    return (
      <div>
        <p>{"Program name: " + this.state.program.name}</p>
        <p>{"Program description: " + this.state.program.description}</p>
      </div>
    );
  }

  renderPrompts() {
    if (this.state.targets.length > 0) {
      return this.state.targets.forEach(target => {
        if (target.prompts !== null && target.prompts.length > 0) {
          target.prompts.forEach(prompt => this.renderPrompt(prompt));
        }
      });
    }
  }

  renderPrompt(prompt) {
    return <Trial />;
  }

  renderStopSessionButton() {
    return (
      <button className="btn btn-primary" onClick={this.handleStopSession}>
        End Session
      </button>
    );
  }
}
