import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Home";
import { FetchData } from "./components/FetchData";
import { Counter } from "./components/Counter";
import { StudentInfoUpdate } from "./components/StudentInfoUpdate";
import { StudentInfo } from "./components/StudentInfo";
import { MyStudents } from "./components/MyStudents";
import AuthorizeRoute from "./components/api-authorization/AuthorizeRoute";
import ApiAuthorizationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";
import { ApplicationPaths } from "./components/api-authorization/ApiAuthorizationConstants";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route path="/counter" component={Counter} />
        <AuthorizeRoute path="/fetch-data" component={FetchData} />
        <Route exact path="/students" component={MyStudents} />
        <Route path="/students/create" component={StudentInfoUpdate} />
        <Route exact path="/students/:id([-]?\d+)" component={StudentInfo} />
        <Route path="/students/:id([-]?\d+)/edit" component={StudentInfoUpdate} />
        <Route
          path={ApplicationPaths.ApiAuthorizationPrefix}
          component={ApiAuthorizationRoutes}
        />
      </Layout>
    );
  }
}
