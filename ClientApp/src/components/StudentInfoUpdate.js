import React, { Component } from "react";
import { Redirect } from "react-router-dom";
import Input from "./Input";
import TextArea from "./TextArea";
import Select from "./Select";
import Program from "./Program";
//import { confirmAlert } from 'react-confirm-alert'; // Import
//import 'react-confirm-alert/src/react-confirm-alert.css'; // Import css


//import { browserHistory } from 'react-router';
//import { createStackNavigator, createAppContainer } from "react-navigation";

// ref: https://www.codementor.io/blizzerand/building-forms-using-react-everything-you-need-to-know-iz3eyoq4y
export class StudentInfoUpdate extends Component {
  state = {
    newProgramCount: 0,
    programSaveComplete: false,
    redirectToStudentInfo: "",
    studentInfoRedirect: false,
    programs: [],
    newlyAddedPrograms: [],
    addProgramOptions: [],
    newlyAddedProgramIds: {
      frontendId:[],
      backendId: []
    },
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
    console.log("populateProgramData");
    const response = await fetch(
      "api/student/programs/" + this.props.match.params.id
    );
    const data = await response.json();
    this.setState({
      programs: data,
    });
    // this.setState({
    //   existingPrograms: data
    // });
  }

  async getAddProgramOptions() {
    console.log("getAddProgramOptions");
    const response = await fetch("api/program");
    let data = await response.json();
    // data = data.filter(program => {
    //   for (var i = 0; i < this.state.programs.length; i++) {
    //     if (this.state.programs[i].id === program.id) {
    //       return false;
    //     }
    //   }
    //   return true;
    // });
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

  //update this to only display remove buttons for newlyAddedProgramIds
  renderPrograms() {
    if (this.state.programs.length > 0) {
      return (
        <div>
        <ul>
          {this.state.programs.map(p => (
            <li key={p.id}>
            <Program program={p} />
            </li>
          ))}
        </ul>
        </div>
    //else if(newlyAddedProgramIds.Contains(p.id)==true){
            // return
            // <div>
            //   <button onClick={(e)=> this.removeItem(p.id)} type="button" className="btn btn-default btn-secondary">
            //   Remove
            //   </button>
            // </div>
            // }
    
      );
    } else {
      return <p>No programs for this student</p>;
    }
    
  }

  renderNewlyAddedPrograms() {
    console.log("renderNewlyAddedPrograms");
    //if (this.state.newlyAddedPrograms.length > 0) {
      return (
        <div>
        <ul>
          {this.state.newlyAddedPrograms.map(p => (
            <li key={p.id}>
            <Program program={p} />
            {/* {console.log("p.id is"+p.id)}
            {console.log("NAP IDs are"+this.state.newlyAddedProgramIds)}
            {console.log("comparison "+this.state.newlyAddedProgramIds.includes(p.id))} */}
            <button onClick={(e)=> this.removeItem(p.id)} type="button" className="btn btn-default btn-secondary">
              Remove
            </button>
            </li>
          ))}
        </ul>
        </div>
      );
  }
  //update this because only newlyAddedProgramIds would show program ID 
  removeItem(program2Remove){
    console.log("program2Remove "+program2Remove);
    //front
    const newPrograms = this.state.newlyAddedPrograms.filter(program => {
      return program.id !== program2Remove;
    });
    //backend
    //take out of want to keep
    //take out the want to remove
    //remove only one
    //put them together
    const keepProgramsIds = this.state.newlyAddedProgramIds.filter(newlyAddedProgramId => {
      return newlyAddedProgramId.frontendId !== program2Remove;
    });
    const removeProgramsIds = this.state.newlyAddedProgramIds.filter(newlyAddedProgramId => {
      return newlyAddedProgramId.frontendId == program2Remove;
    });
    removeProgramsIds.shift();
    const newProgramsIds = keepProgramsIds.concat(removeProgramsIds);

    this.setState( state => ({ 
      //programs: [...newPrograms],
      newlyAddedPrograms: [...newPrograms],
      newlyAddedProgramIds: [...newProgramsIds]
    }),() => {
      console.log("newlyAddedPrograms");
      console.log(this.state.newlyAddedPrograms);
      console.log("this.state.newlyAddedProgramIds frontendId backendId");
      console.log(this.state.newlyAddedProgramIds.frontendId+" "+this.state.newlyAddedProgramIds.backendId);
      
    });
  }

  handleProgramSelectInput = event => {
    let newProgramId = event.target.value; //backendId
    let newProgram = Object.assign({},this.state.addProgramOptions.find(p => p.id.toString(10) === newProgramId));
    
    newProgram.name = "Copy of "+ newProgram.name;
    console.log("newProgram.name "+newProgram.name);

    newProgram.id=1+this.state.newProgramCount; //frontendId
    console.log("newProgram.id "+newProgram.id);
    this.setState(state => ({
      // programs: [
      //   ...state.programs,
      //   newProgram
      //   //state.addProgramOptions.find(p => p.id.toString(10) === eventId)
      // ],
      newProgramCount: state.newProgramCount+1,
      newlyAddedPrograms: [
        ...state.newlyAddedPrograms,
        newProgram
      ],
      
      // addProgramOptions: state.addProgramOptions.filter(
      //   p => p.id.toString(10) !== eventId
      // ),
      newlyAddedProgramIds: {...state.newlyAddedProgramIds, frontendId:newProgram.id ,backendId: newProgramId }

    }),() => {
      console.log("this.state.addProgramOptions");
      console.log(this.state.addProgramOptions);
      console.log("newlyAddedPrograms");
      console.log(this.state.newlyAddedPrograms);
      console.log("this.state.newlyAddedProgramIds frontendId backendId");
      console.log(this.state.newlyAddedProgramIds.frontendId+" "+this.state.newlyAddedProgramIds.backendId);
      
    }
    );
    
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
  
  savePrograms() { //Post newlyAddedProgramIds to backend
    console.log("savePrograms")
    const programsToSave = this.state.newlyAddedProgramIds;
    fetch("https://localhost:5001/api/program/saveNewlyAddedPrograms/", {
      method: "POST",
      body: JSON.stringify({
        studentId: this.props.match.params.id,
        ...programsToSave
      }),
      cache: "no-cache",
      headers: {
        "content-type": "application/json"
      }
    }).then(() => {
      this.setState({ programSaveComplete: true });
    });
  }

  getProgramsToSave() {
    console.log("getProgramsToSave");
    let promises = [];
    this.state.newlyAddedProgramIds.forEach(program => {
      promises.push(
        fetch("https://localhost:5001/api/program/" + program)
          .then(response => response.json())
          .catch(err => console.error(err))
      );
    });
    console.log("this.state.newlyAddedProgramIds ");
    console.log(this.state.newlyAddedProgramIds);
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
          {this.renderNewlyAddedPrograms()}
          
          <Select
            title={"Add existing Program"}
            name={"addProgram"}
            value=""
            options={this.state.addProgramOptions}
            handleChange={this.handleProgramSelectInput}
            placeholder={"Select Program"}
            labelField={"name"}
          />
          <input type="submit" value="Submit" className="btn btn-primary"/>
        </form>
      </div>
    );
  }
}
