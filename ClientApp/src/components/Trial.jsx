import React from "react";
import { Row, Col } from "reactstrap";

const Trial = props => {
  return (
    <div>
      <Row>
        <Col>
          <button>+</button>
        </Col>
        <Col>
          <button>-</button>
        </Col>
      </Row>
    </div>
  );
};

export default Trial;
