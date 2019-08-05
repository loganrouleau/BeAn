import React, { Component } from "react";
import { Row, Col } from "reactstrap";

export class Trial extends Component {
  constructor(props) {
    super(props);
    this.state = {
      prompt: props.prompt,
      progress: "",
      count: 0
    };
  }

  updateCounter(result) {
    let plusMinusChar;
    if (result === 1) {
      plusMinusChar = "+";
    } else if (result === -1) {
      plusMinusChar = "-";
    } else {
      throw new Error("Invalid counter state");
    }
    this.setState(state => ({
      progress: state.progress + " " + plusMinusChar,
      count: state.count + result
    }));
  }

  handleIncrement = () => {
    this.updateCounter(1);
  };

  handleDecrement = () => {
    this.updateCounter(-1);
  };

  render() {
    console.log(this.state);
    return (
      <div style={{ border: "1px solid black" }}>
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
                this.state.prompt.consecutiveSuccessfulSession}
            </p>
          </Col>
        </Row>
        <Row>
          <Col>
            <button onClick={this.handleIncrement}>+</button>
            <button onClick={this.handleDecrement}>-</button>
          </Col>
          <Col>
            <p>{this.state.progress}</p>
            <p>{"Count: " + this.state.count}</p>
          </Col>
        </Row>
      </div>
    );
  }
}
