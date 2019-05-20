import React, { Component } from 'react';
import CheckBox from '../components/CheckBox';
import Input from '../components/Input';
import TextArea from '../components/TextArea';
import Select from '../components/Select';
import Button from '../components/Button'
import authService from './api-authorization/AuthorizeService'


export class EnterData extends Component {
  static displayName = EnterData.name;

  constructor(props) {
    super(props);
    this.state = {
      studentId: 'student123',
      lastUpdated: '2019-05-19',
      programId: 'program321',
      programDescription: 'programDescription',
      dataPointsJson: 'datapoint'
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({ value: event.target.value });
  }

  handleSubmit(event) {
    alert('A name was submitted: ' + this.state.value);
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
      <form onSubmit={this.handleSubmit}>
        <label>
          Name:
            <input type="text" value={this.state.value} onChange={this.handleChange} />
        </label>

        {/*<Select /> {/* Gender Selection */}

        <Input /> {/* Name of the user */}
        <Input /> {/* Input for Age */}
            <Input /> {/* Input for Age */} 
        <Input /> {/* Input for Age */}
            <Input /> {/* Input for Age */} 
        <Input /> {/* Input for Age */}
            <Input /> {/* Input for Age */} 
        <Input /> {/* Input for Age */}
        {/*<CheckBox /> {/* List of Skills (eg. Programmer, developer) */}
        <TextArea value="about you" /> {/* About you */}
        <Button value="about you" /> { /*Submit */}
        <Button /> {/*Clear the form */}


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

