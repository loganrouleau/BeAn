import React, { Component } from "react";

// ref: https://www.codementor.io/blizzerand/building-forms-using-react-everything-you-need-to-know-iz3eyoq4y
export class Students extends Component {
  state = {
    toStudentInfo: false,
    newStudent: {
      studentId: "",
      studentInitial: "",
      remark: "",
      programId: "",
      lastUpdated: ""
    },
    programIdOptions: []
  };

  componentDidMount() {
    this.loadStudent();
    this.populateProgramData();
  }

  async loadStudent() {
    let id = this.props.match.params.id;
    console.log(this.props);
    const response = await fetch("api/Student/" + id, {
      headers: {}
    });
    const data = await response.json();
    console.log(data);
    this.setState({
      newStudent: {
        studentId: data.studentId,
        studentInitial: data.studentInitial,
        remark: data.remark,
        programId: data.programId,
        lastUpdated: data.lastUpdated
      }
    });
    console.log(this.state);
  }

  async populateProgramData() {
    //const token = await authService.getAccessToken();
    console.log("About to fetch ");
    const response = await fetch(
      "api/Student/programs/" + this.props.match.params.id,
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
      <div>
        <title>Student</title>
        <p>
          Hello
          {this.state.programIdOptions}
        </p>
      </div>
    );
  }
}
