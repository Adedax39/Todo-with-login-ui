import React, { useState } from 'react';
import { Modal, Form } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import './loginNew.css';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import axios from 'axios';

const LoginForm = ({ show, handleClose }) => {
  const [formData, setFormData] = useState({ username: '', password: '' });
  const navigate = useNavigate();

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSignIn = async () => {
    try {
      const response = await axios.post('https://localhost:7014/api/Register/Login', {
        userName: formData.username,
        password: formData.password
      });

      if (response.status === 200) {
        toast.success('Authentication Successful!');
        navigate('/todolist');
      }
    } catch (error) {
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
    <>
      <Modal show={show} onHide={handleClose} centered>
        <Modal.Header closeButton>
          <Modal.Title>Sign In</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form className="SignUpForm">
            <Form.Group controlId="formBasicText">
              <Form.Label>User Name</Form.Label>
              <Form.Control
                type="text"
                name="username"
                placeholder="Enter username"
                value={formData.username}
                onChange={handleChange}
              />
            </Form.Group>
            <Form.Group controlId="formBasicPassword">
              <Form.Label>Password</Form.Label>
              <Form.Control
                type="password"
                name="password"
                placeholder="Enter User password"
                value={formData.password}
                onChange={handleChange}
              />
            </Form.Group>
            <div className="d-grid gap-2">
              <button className="btn btn-light" type="button" onClick={handleSignIn}>
                Sign in
              </button>
            </div>
          </Form>
        </Modal.Body>
      </Modal>
      <ToastContainer />
    </>
  );
};

export default LoginForm;
