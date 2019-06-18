import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import Input from "./Input";
import TextArea from "./TextArea";

// ref: https://www.codementor.io/blizzerand/building-forms-using-react-everything-you-need-to-know-iz3eyoq4y
export class EditStudent extends Component {
  state = {
    redirectToStudentId: "",
    student: {
      studentId: "",
      studentInitial: "",
      remark: ""
    }
  };

  constructor(props) {
    super(props);
    if (props.location.student) {
      this.state.student.studentId = props.location.student.studentId;
      this.state.student.studentInitial = props.location.student.studentInitial;
      this.state.student.remark = props.location.student.remark;
    }
  }

  handleInput = event => {
    let value = event.target.value;
    let name = event.target.name;
    this.setState(
      prevState => ({
        student: {
          ...prevState.student,
          [name]: value
        }
      }),
      () => console.log(this.state.student)
    );
  };

  handleSubmit = event => {
    event.preventDefault();
    if (this.props.location.student) {
      fetch(
        "https://localhost:5001/api/student/" + this.props.match.params.id,
        {
          method: "POST",
          body: JSON.stringify({
            ...this.state.student,
            id: this.props.match.params.id
          }),
          cache: "no-cache",
          headers: {
            "content-type": "application/json"
          }
        }
      )
        .catch(err => console.error(err))
        .then(() =>
          this.setState(() => ({
            redirectToStudentId: this.props.match.params.id
          }))
        );
    } else {
      let url = "https://localhost:5001/api/Student/create";
      let responsedata;
      fetch(url, {
        method: "POST",
        body: JSON.stringify(this.state.student),
        cache: "no-cache",
        headers: {
          "content-type": "application/json"
        }
      })
        .then(response => response.json())
        .then(data => {
          console.log("Successful" + data);
          responsedata = data.id;
        })
        .catch(err => console.error(err))
        .then(() =>
          this.setState(() => ({ redirectToStudentId: responsedata }))
        );
    }
  };

  render() {
    console.log(this.props);
    if (this.state.redirectToStudentId) {
      return <Redirect to={"/students/" + this.state.redirectToStudentId} />;
    }
    return (
      <div>
        <h1>New Student</h1>
        <form name="enterStudentInfo" onSubmit={this.handleSubmit}>
          {/* Student ID */}
          <Input
            inputType={"text"}
            title={"Student ID"}
            name={"studentId"}
            value={this.state.student.studentId}
            placeholder={"Enter Student ID"}
            handleChange={this.handleInput}
          />
          {/* Student Initial */}
          <Input
            inputType={"text"}
            title={"Student Initial"}
            name={"studentInitial"}
            value={this.state.student.studentInitial}
            placeholder={"Enter Student Initials"}
            handleChange={this.handleInput}
          />
          {/* Remark */}
          <TextArea
            title={"Remark"}
            row={3}
            value={this.state.student.remark}
            name={"remark"}
            handleChange={this.handleInput}
            placeholder={"Any additional information"}
          />
          <input type="submit" value="Submit" />
        </form>
      </div>
    );
  }
}
