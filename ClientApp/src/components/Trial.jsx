import React, { Component } from "react";
import { Row, Col } from "reactstrap";
import "../scss/custom.css";

export class Trial extends Component {
  constructor(props) {
    super(props);
    this.state = {
      prompt: props.prompt,
      target: props.target,
      program: props.program,
      progress: "",
      successfulAttempts: 0,
      totalAttempts: 0,
      trialComplete: false
    };
  }

  updateCounter(isAttemptSuccessful) {
    if (this.state.trialComplete) {
      return;
    }
    let plusMinusChar = isAttemptSuccessful ? "+" : "-";
    this.setState(
      state => ({
        progress: state.progress + " " + plusMinusChar,
        successfulAttempts:
          state.successfulAttempts + (isAttemptSuccessful ? 1 : 0),
        totalAttempts: state.totalAttempts + 1
      }),
      () => {
        if (this.state.totalAttempts === this.state.target.maxTrial) {
          this.setState({ trialComplete: true });
        }
      }
    );
  }

  handleSuccessfulAttempt = () => {
    this.updateCounter(true);
  };

  handleFailedAttempt = () => {
    this.updateCounter(false);
  };

  handleUndoLastAttempt = () => {
    if (this.state.totalAttempts <= 0) {
      return;
    }
    let lastResultChar = this.state.progress.slice(-1);
    let countToAdd = lastResultChar === "+" ? -1 : 0;
    this.setState(state => ({
      progress: state.progress.substring(0, state.progress.length - 2),
      successfulAttempts: state.successfulAttempts + countToAdd,
      totalAttempts: state.totalAttempts - 1,
      trialComplete: state.trialComplete ? false : state.trialComplete
    }));
  };

  getClassName() {
    if (!this.state.trialComplete) {
      return "";
    }
    if (
      this.state.successfulAttempts / this.state.totalAttempts >=
      this.state.program.masteryCriteriaCompareTo / 100
    ) {
      return "trial-success";
    }
    return "trial-failure";
  }

  render() {
    console.log(this.state.trialComplete);
    return (
      <div className={"trial " + this.getClassName()}>
        <Row>
          <Col>
            <p>{"Prompt description: " + this.state.prompt.description}</p>
          </Col>
          <Col>
            <p>{"Prompt level: " + this.state.prompt.level}</p>
          </Col>
          <Col>
            <p>
              {"Consecutive successful sessions: " +
                this.state.prompt.consecutiveSuccessfulSession +
                "/" +
                this.state.program.masteryCriteriaConsecutiveSessions}
            </p>
          </Col>
          <Col>
            <p>{"Min trials: " + this.state.target.minTrial}</p>
          </Col>
          <Col>
            <p>{"Max trials: " + this.state.target.maxTrial}</p>
          </Col>
          <Col>
            <p>
              {"Mastery criteria: " +
                this.state.program.masteryCriteriaCompareTo}
            </p>
          </Col>
        </Row>
        <Row>
          <Col>
            <button onClick={this.handleSuccessfulAttempt}>+</button>
            <button onClick={this.handleFailedAttempt}>-</button>
            <button onClick={this.handleUndoLastAttempt}>Undo</button>
          </Col>
          <Col>
            <p>{this.state.progress}</p>
            <p>{"Successes: " + this.state.successfulAttempts}</p>
          </Col>
          <Col>
            <p>
              {"Percentage: " +
                Math.round(
                  100 *
                    (this.state.successfulAttempts / this.state.totalAttempts)
                ) +
                "%"}
            </p>
          </Col>
        </Row>
      </div>
    );
  }
}
