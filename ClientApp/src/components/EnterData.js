import React, { Component } from 'react';
import CheckBox from '../components/CheckBox';
import Input from '../components/Input';
import TextArea from '../components/TextArea';
import Select from '../components/Select';
import Button from '../components/Button';
import authService from './api-authorization/AuthorizeService';
import { Redirect } from 'react-router-dom'

// ref: https://www.codementor.io/blizzerand/building-forms-using-react-everything-you-need-to-know-iz3eyoq4y
export class EnterData extends Component {
  static displayName = EnterData.name;
  constructor(props) {
    super(props);
    this.state = {
      toStudentInfo: false,
      newStudent:{
        studentId: 'SID0096',
        studentInitial: '',
        lastUpdated: '2019-05-19',
        programId: "",
        programDescription: 'programDescription',
        dataPointsJson: 'datapoint',
        remark:''
      },
      programIdOptions: ["A","B","C","PID0023"]
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleInput = this.handleInput.bind(this);
    this.handleTextArea = this.handleTextArea.bind(this);
  }

  handleChange(event) {
    //this.setState({ studentId: event.target.value });
    //this.setState({ studentInitial: event.target.value });
    const target = event.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });

  }

  handleInput(e) {
    let value = e.target.value;
    let name = e.target.name;
    this.setState(
      prevState => ({
        newStudent: {
          ...prevState.newStudent,
          [name]: value
        }
      }),
      () => console.log(this.state.newStudent)
    );
  }

  handleTextArea(e) {
    console.log("Inside handleTextArea");
    let value = e.target.value;
    this.setState(
      prevState => ({
        newStudent: {
          ...prevState.newStudent,
          remark: value
        }
      }),
      () => console.log(this.state.newStudent)
    );
  }
  
  handleSubmit(event) {
    //this.setState({toStudentInfo: true})
    alert('The Student ID submitted is: ' + this.state.newStudent.studentId+'\n'+
    'The Student Initial submitted is: ' +this.state.newStudent.studentInitial);
    event.preventDefault();
    let userData = this.state.newStudent;
    var url = 'https://localhost:5001/api/SampleData/test';
    fetch(url, {
      method: 'POST',
      body: JSON.stringify(userData),
      cache: 'no-cache',
      headers: {
        'content-type': 'application/json'
      }
    })
    .then(response => response.json())
    .then(data => console.log("Successful" + data))
    .catch(err => console.error(err))
    .then (()=> this.setState( ()=>({toStudentInfo: true})))
    ;
  }

  render() {
    if(this.state.toStudentInfo===true){
      return <Redirect to = '/student-info' />;
    }
    return (
      <form name="enterStudentInfo" onSubmit={this.handleSubmit}>
        {/* Student ID */}
        <Input
          inputType={"text"}
          title={"Student ID"}
          name={"studentId"}
          value={this.state.newStudent.studentId}
          placeholder={"SID0001"}
          handleChange={this.handleInput}
        />{" "}
        {/* Student Initial */}
        <Input
          inputType={"text"}
          title={"Student Initial"}
          name={"studentInitial"}
          value={this.state.newStudent.studentInitial}
          placeholder={"Enter Student Initials"}
          handleChange={this.handleInput}
        />{" "}
        {/* Remark */}
        <TextArea 
          title={"Remark"}
          row={3}
          value={this.state.newStudent.remark}
          name={"remark"}
          handleChange={this.handleTextArea}
          placeholder={"Any additional information"}
        />{""}
        {/* Program ID (to be removed for another page) */}
        <Select
          title={"Program ID"}
          name={"programId"}
          value={this.state.newStudent.programId} 
          options={this.state.programIdOptions}
          handleChange={this.handleInput}
          placeholder={"Select Program"}
        />{""}
        <input type="submit" value="Submit" />
      </form>
    );
  }
}
