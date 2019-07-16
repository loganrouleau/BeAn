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
    programSaveComplete: false,
    redirectToStudentInfo: "",
    studentInfoRedirect: false,
    programs: [],
    addProgramOptions: [],
    newlyAddedProgramIds: [],
    student: {
      studentId: "",
      studentInitials: "",
      remark: "",
      lastUpdated: ""
    }
  };

  constructor(props) {
    super(props);
    if (props.location.student) {
      this.state.student.studentId = props.location.student.studentId;
      this.state.student.studentInitials =
        props.location.student.studentInitials;
      this.state.student.remark = props.location.student.remark;
    }
  }

  componentDidMount() {
    this.populateProgramData();
    this.getAddProgramOptions();
  }

  async populateProgramData() {
    const response = await fetch(
      "api/student/programs/" + this.props.match.params.id
    );
    const data = await response.json();
    this.setState({
      programs: data
    });
  }

  async getAddProgramOptions() {
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

  handleInput = event => {
    let value = event.target.value;
    let name = event.target.name;
    this.setState(prevState => ({
      student: {
        ...prevState.student,
        [name]: value
      }
    }));
  };

  //display programs associated with the student
  renderPrograms() {
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
      ),
      newlyAddedProgramIds: [...state.newlyAddedProgramIds, eventId]
    }));
  };

  //2019-07-13 TODO: last updated time not changing after save
  handleSubmit = event => {
    this.savePrograms();
    this.saveStudents();
    event.preventDefault();
  };

  saveStudents() {
    if (this.props.location.student) {
      fetch(
        "https://localhost:5001/api/student/" + this.props.match.params.id,
        {
          method: "POST",
          body: JSON.stringify({
            id: this.props.match.params.id,
            studentId: this.state.student.studentId,
            studentInitials: this.state.student.studentInitials,
            remark: this.state.student.remark
          }),
          cache: "no-cache",
          headers: {
            "content-type": "application/json"
          }
        }
      )
        .catch(err => console.error(err))
        .then(() => {
          this.setState(() => ({
            redirectToStudentInfo: this.props.match.params.id
          }));
        });
    } else {
      let url = "https://localhost:5001/api/Student/create";
      fetch(url, {
        method: "POST",
        body: JSON.stringify({
          studentId: this.state.student.studentId,
          studentInitials: this.state.student.studentInitials,
          remark: this.state.student.remark
        }),
        cache: "no-cache",
        headers: {
          "content-type": "application/json"
        }
      })
        .then(response => response.json())
        .then(newStudent => {
          this.setState(() => ({
            redirectToStudentInfo: newStudent.id
          }));
        })
        .catch(err => console.error(err));
    }
  }

  savePrograms() {
    let promises = [];
    this.getProgramsToSave().then(programsToSave => {
      var i;
      for (i = 0; i < programsToSave.length; i++) {
        promises.push(
          fetch("https://localhost:5001/api/program/" + programsToSave[i].id, {
            method: "POST",
            body: JSON.stringify({
              ...programsToSave[i],
              studentId: this.props.match.params.id
            }),
            cache: "no-cache",
            headers: {
              "content-type": "application/json"
            }
          })
        );
      }
      Promise.all(promises).then(() => {
        this.setState({ programSaveComplete: true });
      });
    });
  }

  getProgramsToSave() {
    let promises = [];
    this.state.newlyAddedProgramIds.forEach(program => {
      promises.push(
        fetch("https://localhost:5001/api/program/" + program)
          .then(response => response.json())
          .catch(err => console.error(err))
      );
    });
    return Promise.all(promises);
  }

  handleStudentInfoRedirect = () => {
    if (this.state.studentInfoRedirect === false) {
      this.setState({
        studentInfoRedirect: true
      });
    }
  };

  render() {
    if (this.state.redirectToStudentInfo && this.state.programSaveComplete) {
      return <Redirect to={"/students/" + this.state.redirectToStudentInfo} />;
    }else if (this.state.studentInfoRedirect) {
      let path;
      if(this.props.match.params.id===undefined){
        path = "/students";
      }else{
        path = "/students/"+this.props.match.params.id;
      }
      console.log(path);
      return (
        <Redirect
          to={{
            pathname: path
          }}
        />
      );
    }
    return (
      <div>
        <h1>Student Information Update</h1>
        <button
          className="btn btn-primary"
          // onClick={() => this.props.history.goBack()}
          //onClick={() => this.props.history.goBack()}
          onClick={this.handleStudentInfoRedirect}
        >
          Go Back
        </button>
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
            name={"studentInitials"}
            value={this.state.student.studentInitials}
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
