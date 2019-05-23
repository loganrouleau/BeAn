import React, { Component } from 'react';
import CheckBox from '../components/CheckBox';
import Input from '../components/Input';
import TextArea from '../components/TextArea';
import Select from '../components/Select';
import Button from '../components/Button';
import authService from './api-authorization/AuthorizeService';


export class EnterData extends Component {
  static displayName = EnterData.name;

  constructor(props) {
    super(props);
    this.state = {
      studentId: 'SID0096',
      studentInitial: 'AA',
      lastUpdated: '2019-05-19',
      programId: 'PID0023',
      programDescription: 'programDescription',
      dataPointsJson: 'datapoint',
      remark:'',
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
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

  handleSubmit(event) {
    alert('The Student ID submitted is: ' + this.state.studentId+'\n'+
    'The Student Initial submitted is: ' +this.state.studentInitial);
    
    event.preventDefault();

    var url = 'https://localhost:5001/api/SampleData/test';
    fetch(url, {
      body: JSON.stringify(this.state),
      cache: 'no-cache',
      headers: {
        'content-type': 'application/json'
      },
      method: 'POST'
    })
      .catch(err => {
        console.error(err);
      });
  }

  render() {
    return (
      <form name="studentInfo" onSubmit={this.handleSubmit}>
        <label>
          Student ID:
            <input name="studentId" type="text" value={this.state.studentId} onChange={this.handleChange} />
        </label>
        <div/>
        <label>
          Student Initial:
            <input name="studentInitial" type="text" value={this.state.studendInitial} onChange={this.handleChange} />
        </label>
        <div/>
        <label>
          Program ID:
          <select value={this.state.programId} onChange={this.handleChange}>
              {/* BC: to be refactor to use db values*/}
              <option value="PID0023">PID0023</option>
              <option value="lime">Lime</option>
              <option value="coconut">Coconut</option>
              <option value="mango">Mango</option>
          </select>
        </label>
        <div/>
        <label>
          Remark: 
          <TextArea name="remark" value="" /> 
        </label>
        {/*<CheckBox /> {/* List of Skills (eg. Programmer, developer) */}
        {/* <Button value="about you" /> { /*Submit */}
        {/* <Button /> Clear the form */}
        <div/>
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

