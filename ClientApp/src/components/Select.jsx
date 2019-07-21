import React from "react";

const Select = props => {
  return (
    <div className="form-group">
      <label> {props.title} </label>
      <select
        id={props.name}
        name={props.name}
        value={props.value}
        onChange={props.handleChange}
        className="form-control"
      >
        <option value="" disabled selected>
          {props.placeholder}
        </option>
        {props.options.map(option => {
          return (
            <option
              key={option.id}
              value={option.id}
              label={option[props.labelField]}
            >
              {option.name}
            </option>
          );
        })}
      </select>
    </div>
  );
};

export default Select;
