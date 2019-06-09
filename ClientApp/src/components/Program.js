import React from "react";
import { Row, Col } from "reactstrap";

const Program = props => {
  return (
    <div>
      <Row>
        <Col>Program Name</Col>
        <Col>{props.program.name}</Col>
      </Row>
      <Row>
        <Col>Program Description</Col>
        <Col>{props.program.description}</Col>
      </Row>
      <Row>
        <Col>Last Updated</Col>
        <Col>{props.program.lastUpdated}</Col>
      </Row>
    </div>
  );
};

export default Program;
