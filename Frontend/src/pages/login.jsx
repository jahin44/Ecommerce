import NavMenubar from "../components/navbar/NavMenubar";
import Form from "react-bootstrap/Form";
import classes from "./login.css";
import { Button } from '@material-ui/core';
import React, { useState } from 'react';
import axios from 'axios'
import {Routes, Route, useNavigate} from 'react-router-dom';


const Login = () => {
    
    const [username, setUserName] = useState();
    const [password, setPassword] = useState();
    const navigate = useNavigate();

    const handleClick = async () => {
        try {
            await axios.post('https://localhost:7137/api/LogIn',{username: username, password:password})
            .then((res) => {
              if(res.status === 200) {
              console.log(res.data.token);
              localStorage.setItem("Token",res.data.token);
              navigate('/');}
            })
            .catch((err) => console.error(err))
        
        } catch (err) {
            console.log(err)
        } 
      };
  return (
    <>
      <NavMenubar />

      <div className="login">
        <Form>
          <Form.Group className="mb-3" controlId="name">
            <Form.Label>Name</Form.Label>
            <Form.Control type="name" placeholder="name" onChange={e => setUserName(e.target.value)} />
          </Form.Group>
          <Form.Group className="mb-3" controlId="password" >
            <Form.Label>Password</Form.Label>
            <Form.Control type="password" placeholder="Password" onChange={e => setPassword(e.target.value)} />
          </Form.Group>
        </Form>
        <div>
          <Button
            variant="contained"
            color="green"
            size="small"
            title="login"
            onClick={handleClick}
          >
           Login
          </Button>
        </div>
      </div>
    </>
  );
};

export default Login;
