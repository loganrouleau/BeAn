import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { StudentInfoUpdate } from "./components/StudentInfoUpdate";
import { StudentInfo } from "./components/StudentInfo";
import { MyStudents } from "./components/MyStudents";
import { ActiveSession } from "./components/ActiveSession";
import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
import ApiAuthorizationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { ApplicationPaths } from "./components/api-authorization/ApiAuthorizationConstants";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        {/* <Provider store={props.store}>
        <Router history={browserHistory} routes={routes} />
        </Provider> */}
        <Route exact path="/" component={Home} />
        <AuthorizeRoute path="/fetch-data" component={FetchData} />
        <Route exact path="/students" component={MyStudents} />
        <Route path="/students/create" component={StudentInfoUpdate} />
        <Route exact path="/students/:id([-]?\d+)" component={StudentInfo} />
        <Route path="/students/:id([-]?\d+)/edit" component={StudentInfoUpdate} />
        <Route path="/active-session" component={ActiveSession} />
        <Route
          path={ApplicationPaths.ApiAuthorizationPrefix}
          component={ApiAuthorizationRoutes}
        />
      </Layout>
    );
  }
}
