import React, { Component } from 'react';
import { Link } from "react-router-dom";


export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Welcome to BeAn!</h1>
        <p>We are here to help you to make your life a little easy with your ABA work.</p>
        <p>How does BeAn help?</p>
        <ul>
          <li>BeAn helps you <strong>collect data in your sessions</strong> with your student.</li>
          <li>BeAn helps you <strong>keep track of all the students and programs</strong>.</li>
          {/* <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li> */}
          {/* <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li> */}
          {/* <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li> */}
        </ul>
        <p>Get started with one of these options:</p>
        <ul>
          <li><a href='/new-session'>Start a session</a> - start collecting data for your student session.</li>
          <li><a href='/students'>My Students</a> - add, edit your list of student and their session data.</li>
          <li><a href='/programs'>My Programs</a> - add, edit, and associate programs to your students.</li>
          {/* <li><strong>Client-side navigation</strong>. For example, click <em>Counter</em> then <em>Back</em> to return here.</li>
          <li><strong>Development server integration</strong>. In development mode, the development server from <code>create-react-app</code> runs in the background automatically, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file.</li>
          <li><strong>Efficient production builds</strong>. In production mode, development-time features are disabled, and your <code>dotnet publish</code> configuration produces minified, efficiently bundled JavaScript files.</li> */}
        </ul>
        {/* <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p> */}
      </div>
    );
  }
}
