import React, { Component } from 'react';
import CheckBox from '../components/CheckBox';
import Input from '../components/Input';
import TextArea from '../components/TextArea';
import Select from '../components/Select';
import Button from '../components/Button';
import authService from './api-authorization/AuthorizeService';

// ref: https://www.codementor.io/blizzerand/building-forms-using-react-everything-you-need-to-know-iz3eyoq4y
export class EnterData extends Component {
  static displayName = EnterData.name;

  constructor(props) {
    super(props);
    this.state = {
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
    }).then(response => {
      response.json().then(data => {
        console.log("Successful" + data);
      });
    }).catch(err => {
        console.error(err);
      });
  }

  render() {
    return (
      <form name="studentInfo" onSubmit={this.handleSubmit}>
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
//   static renderForecastsTable(forecasts) {
//     return (
//       <table className='table table-striped'>
//         <thead>
//           <tr>
//             <th>Date</th>
//             <th>Temp. (C)</th>
//             <th>Temp. (F)</th>
//             <th>Summary</th>
//           </tr>
//         </thead>
//         <tbody>
//           {forecasts.map(forecast =>
//             <tr key={forecast.dateFormatted}>
//               <td>{forecast.dateFormatted}</td>
//               <td>{forecast.temperatureC}</td>
//               <td>{forecast.temperatureF}</td>
//               <td>{forecast.summary}</td>
//             </tr>
//           )}
//         </tbody>
//       </table>
//     );
//   }

//   render() {
//     return (
//         <div>
//           <h1>Enter Data</h1>
  
//           <p>This is a simple example of a React component.</p>
  
//           <p>Current count: <strong>{this.state.currentCount}</strong></p>
  
//           <button className="btn btn-primary" onClick={this.incrementCounter}>Increment</button>
//         </div>
//       );
    // let contents = this.state.loading
    //   ? <p><em>Loading...</em></p>
    //   : FetchData.renderForecastsTable(this.state.forecasts);

    // return (
    //   <div>
    //     <h1>Weather forecast</h1>
    //     <p>This component demonstrates fetching data from the server.</p>
    //     {contents}
    //   </div>
    // );
//   }

//   async populateWeatherData() {
//     const token = await authService.getAccessToken();
//     const response = await fetch('api/SampleData/WeatherForecasts', {
//       headers: !token ? {} : { 'Authorization': `Bearer ${token}` }
//     });
//     const data = await response.json();
//     this.setState({ forecasts: data, loading: false });
//   }

