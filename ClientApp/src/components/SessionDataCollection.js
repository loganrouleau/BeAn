import React, { Component } from "react";
import { Container } from "reactstrap";
import { Trial } from "./Trial";

export class SessionDataCollection extends Component {
  state = {
    sessionId: "",
    sessionDescription: "",
    student: "",
    currentProgram: "",
    currentProgramTargets: [],
    expandedProgramId: "",
    programOptions: ""
  };

  constructor(props) {
    // TODO: Load program/session from backend if they're not passed in as props
    super(props);
    if (props.location.program) {
      this.state.sessionId = props.match.params.id;
      this.state.sessionDescription = props.location.description;
      this.state.student = props.location.student;
      this.state.currentProgram = props.location.program;
      this.state.expandedProgramId = this.state.currentProgram.id;
    }
  }

  componentDidMount() {
    this.getTargetsForProgram(this.state.currentProgram.id);
    this.getProgramOptions();
  }

  getTargetsForProgram = async function(programId) {
    const response = await fetch("api/program/targets/" + programId);
    let data = await response.json();
    this.setState({ currentProgramTargets: data }, () => {
      this.state.currentProgramTargets.forEach((target, index) => {
        this.getPrompts(target, index);
      });
    });
  };

  getProgramOptions = async function() {
    const response = await fetch(
      "api/student/programs/" + this.state.student.id
    );
    let responseJson = await response.json();
    this.setState({
      programOptions: responseJson
    });
  };

  getPrompts = async function(target, index) {
    const response = await fetch("api/target/prompts/" + target.id);
    let data = await response.json();
    let targets = this.state.currentProgramTargets;
    targets[index].prompts = data;
    this.setState({ currentProgramTargets: targets });
  };

  handleStopSession = () => {};

  handleExpandProgram(program) {
    console.log("handleExpandedProgram");
    this.getTargetsForProgram(program.id);
    // TODO: allow other programs to be expanded
    this.setState({
      expandedProgramId: program.id,
      currentProgram: program
    });
  }

  render() {
    console.log(this.state);
    return (
      <Container>
        <h1>Start recording your data!</h1>
        <p>{"Session description: " + this.state.sessionDescription}</p>
        {this.renderPrograms()}
        {this.renderStopSessionButton()}
      </Container>
    );
  }

  renderPrograms() {
    return (
      <div>
        {Object.values(this.state.programOptions).map(program =>
          this.renderProgram(program)
        )}
      </div>
    );
  }

  renderProgram(program) {
    let programHeader = (
      <div>
        <h3>{"Program name: " + program.name}</h3>
        <p>{"Program description: " + program.description}</p>
      </div>
    );
    let expandButton = (
      <button
        className="btn btn-secondary"
        onClick={() => this.handleExpandProgram(program)}
      >
        Expand
      </button>
    );
    if (program.id === this.state.expandedProgramId) {
      return (
        <div>
          <div style={{ borderStyle: "solid", borderWidth: "2px" }}>
            {programHeader}
            {this.renderTargets()}
          </div>
          <div>
            <br />
          </div>
        </div>
      );
    } else {
      return (
        <div>
          <div style={{ borderStyle: "solid", borderWidth: "1px" }}>
            {programHeader}
            {expandButton}
          </div>
          <div>
            <br />
          </div>
        </div>
      );
    }
  }

  renderTargets() {
    if (this.state.currentProgramTargets.length > 0) {
      return (
        <div>
          {this.state.currentProgramTargets.map(target =>
            this.renderPrompts(target)
          )}
        </div>
      );
    }
    return <p>No targets found for this program.</p>;
  }

  renderPrompts(target) {
    if (target.prompts && target.prompts.length > 0) {
      return (
        <div>
          <p>{"Target name: " + target.name}</p>
          {target.prompts.map(prompt => (
            <Trial
              sessionId={this.state.sessionId}
              prompt={prompt}
              target={target}
              program={this.state.currentProgram}
              handleTrialComplete={this.handleTrialComplete}
              key={prompt.id}
            />
          ))}
        </div>
      );
    }
    return <p>No prompts found for this target.</p>;
  }

  handleTrialComplete = trialData => {
    console.log("Trial complete callback entered");
  };

  renderStopSessionButton() {
    return (
      <button className="btn btn-primary" onClick={this.handleStopSession}>
        End Session
      </button>
    );
  }
}
