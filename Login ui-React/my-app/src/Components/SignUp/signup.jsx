import React, { useState } from 'react';
import { Modal, Button, Form } from 'react-bootstrap';
import './signup.css'
import { Email } from '@mui/icons-material';
import axios from 'axios';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useNavigate } from 'react-router-dom';


const SignUpForm = ({ show, handleClose }) => {
  const [formData,setFormData] = useState({emailAddress:'',userName:'',password:''});
  const navigate = useNavigate();
  
  const handleChange = (event) =>{
    const {name,value} = event.target
    setFormData({...formData,[name]:value});
  };
  const handleSignUp = async ()=>{
    try{
      const response = await axios.post('https://localhost:7014/api/Register',{
        emailAddress: formData.emailAddress,
        userName: formData.userName,
        password: formData.password
      });
      if (response.status === 200) {
        toast.success('Signed up Successful!');
        navigate('/');
      }
    }catch (error) {
      if (error.response) {
        if (error.response.status === 404) {
          toast.error('User not found');
        } else if (error.response.status === 401) {
          toast.error('Incorrect Password');
        } else {
          toast.error('An error occurred. Please try again.');
        }
      } else {
        toast.error('An error occurred. Please try again.');
      }
    }
  };
 

  
  return (
    <Modal show={show} onHide={handleClose} centered >
      <Modal.Header closeButton>
        <Modal.Title>Sign Up</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form className="SignUpForm">
          <Form.Group controlId="formBasicEmail">
            <Form.Label>Email address</Form.Label>
            <Form.Control 
            type="email" 
            name='emailAddress'
            placeholder="Enter email"
            value={formData.emailAddress}
            onChange={handleChange} />
          </Form.Group>
          <Form.Group controlId="formBasicEmail">
            <Form.Label>User Name</Form.Label>
            <Form.Control 
            type="text" 
            name='userName'
            placeholder="Enter User Name"
            value={formData.userName}
            onChange={handleChange} />
          </Form.Group>
          <div class="d-grid gap-2">
            <button class="btn btn-light" type="button" onClick={handleSignUp}>Sign up</button>
          </div>
        </Form>
      </Modal.Body>
    </Modal>
  );
};

export default SignUpForm;
