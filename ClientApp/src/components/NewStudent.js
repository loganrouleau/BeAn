import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import Input from "./Input";
import TextArea from "./TextArea";

// ref: https://www.codementor.io/blizzerand/building-forms-using-react-everything-you-need-to-know-iz3eyoq4y
export class NewStudent extends Component {
  state = {
    redirectToStudentId: "",
    newStudent: {
      studentId: "",
      studentInitial: "",
      remark: ""
    }
  };

  handleInput = event => {
    let value = event.target.value;
    let name = event.target.name;
    this.setState(
      prevState => ({
        newStudent: {
          ...prevState.newStudent,
          [name]: value
        }
      }),
      () => console.log(this.state.newStudent)
    );
  };

  handleSubmit = event => {
    event.preventDefault();
    let url = "https://localhost:5001/api/Student/create";
    let responsedata;
    fetch(url, {
      method: "POST",
      body: JSON.stringify(this.state.newStudent),
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
      .then(() => this.setState(() => ({ redirectToStudentId: responsedata })));
  };

  render() {
    if (this.state.redirectToStudentId) {
      return <Redirect to={"/students/" + this.state.redirectToStudentId} />;
    }
    return (
      <form name="enterStudentInfo" onSubmit={this.handleSubmit}>
        {/* Student ID */}
        <Input
          inputType={"text"}
          title={"Student ID"}
          name={"studentId"}
          value={this.state.newStudent.studentId}
          placeholder={"Enter Student ID"}
          handleChange={this.handleInput}
        />
        {/* Student Initial */}
        <Input
          inputType={"text"}
          title={"Student Initial"}
          name={"studentInitial"}
          value={this.state.newStudent.studentInitial}
          placeholder={"Enter Student Initials"}
          handleChange={this.handleInput}
        />
        {/* Remark */}
        <TextArea
          title={"Remark"}
          row={3}
          value={this.state.newStudent.remark}
          name={"remark"}
          handleChange={this.handleInput}
          placeholder={"Any additional information"}
        />
        <input type="submit" value="Submit" />
      </form>
    );
  }
}
