import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import Input from "./Input";
import TextArea from "./TextArea";
import Select from "./Select";
import Program from "./Program";

//import { browserHistory } from 'react-router';
//import { createStackNavigator, createAppContainer } from "react-navigation";

// ref: https://www.codementor.io/blizzerand/building-forms-using-react-everything-you-need-to-know-iz3eyoq4y
export class StudentInfoUpdate extends Component {
  state = {
    redirectToStudentId: "",
    programs: [],
    addProgramOptions: [],
    student: {
      studentId: "",
      studentInitial: "",
      remark: "",
      lastUpdated: "",
      //programs: [],
      // addProgramOptions: []
    }
  };

  constructor(props) {
    super(props);
    //this.goBack = this.goBack.bind(this);
    console.log(props);
    if (props.location.student) {
      // this.state.student.studentId = -2;
      
      this.state.student.studentId = props.location.student.studentId;
      this.state.student.studentInitial = props.location.student.studentInitial;
      this.state.student.remark = props.location.student.remark;
    }
  }

  componentDidMount() {
    console.log(this.state.student);
    console.log("componentDidMount");
    this.populateProgramData();
    this.getAddProgramOptions();
  }

  async populateProgramData() {
    console.log("populateProgramData");
    //const token = await authService.getAccessToken();
    const response = await fetch(
      "api/student/programs/" + this.state.student.studentId
    );
    const data = await response.json();
    console.log(data);
    this.setState({
      programs: data
    });
  }

  async getAddProgramOptions() {
    console.log("getAddProgramOptions");
    const response = await fetch("api/program");
    let data = await response.json();
    data = data.filter(program => {
      for (var i = 0; i < this.state.programs.length; i++) {
        if (this.state.programs[i].id === program.id) {
          return false;
        }
      }
      return true;
    });
    this.setState({ addProgramOptions: data });
  }

  //this may not be used. to be cleaned-up
  handleStudentIdRedirect = () => {
      this.setState(() => ({
        redirectToStudentId: this.props.match.params.id
      }));
  };

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

  //display programs associated with the student
  renderPrograms() {
    console.log("renderProgram");
    if (this.state.programs.length > 0) {
      return (
        <ul>
          {this.state.programs.map(p => (
            <li key={p.id}>
              <Program program={p} />
            </li>
          ))}
        </ul>
      );
    } else {
      return <p>No programs for this student</p>;
    }
  }

  handleProgramSelectInput = event => {
    let eventId = event.target.value;

    this.setState(state => ({
      programs: [
        ...state.programs,
        state.addProgramOptions.find(p => p.id.toString(10) === eventId)
      ],
      addProgramOptions: state.addProgramOptions.filter(
        p => p.id.toString(10) !== eventId
      )
    }));
  };

  //2019-07-12 TODO: update code to saving program associated with a student
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
    console.log("render");
    if (this.state.redirectToStudentId) {
      return <Redirect to={"/students/" + this.state.redirectToStudentId} />;
    }
    return (
      <div>
        <h1>Student Information Update</h1>
        {/* <button
          className="btn btn-primary"
          onClick={this.handleStudentIdRedirect}
        >
          Back
        </button> */}
        <button className="btn btn-primary" onClick={() => this.props.history.goBack()}>Go Back</button>
        {/* <button className="btn btn-primary" onClick={handleTestClick}>test</button> */}
        
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
          
          {this.renderPrograms()}
          <Select 
            title={"Add existing Program"}
            name={"addProgram"}
            value=""
            options={this.state.addProgramOptions}
            handleChange={this.handleProgramSelectInput}
            placeholder={"Select Program"}
            labelField={"name"}
          />
          <input type="submit" value="Submit" />
        </form>
      </div>
    );
  }
}
