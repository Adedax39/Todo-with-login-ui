import React, { useState } from 'react';
import { Modal, Form } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import './loginNew.css';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const LoginForm = ({ show, handleClose }) => {
  const [formData, setFormData] = useState({ username: '', password: '' });
  const [message, setMessage] = useState('');
  const navigate = useNavigate();

  // Fixed the destructuring and corrected 'Value' to 'value'
  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData({ ...formData, [name]: value });
  };

  // Fixed the function brace placement
  const handleSignIn = async () => {
    try {
      const response = await fetch('https://localhost:7014/api/Register/Login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          userName: formData.username,
          password: formData.password
        })
      });

      if (response.ok) {
        toast.success('Authentication Successful!',{
          position: toast.POSITION.TOP_CENTER
        });
        navigate('/todolist');
      } else if (response.status === 404) {
        toast.error('User not found',{
          position: toast.POSITION.TOP_CENTER
        });
      } else if (response.status === 401) {
        toast.error('Incorrect Password',{
          position: toast.POSITION.TOP_CENTER
        });
      } else {
        toast.error('An error occurred. Please try again.',{
          position: toast.POSITION.TOP_CENTER
        })
      }
    } catch (error) {
      toast.error('An error occurred. Please try again.');
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
        {message && <p>{message}</p>}
      </Modal.Body>
    </Modal>
    <ToastContainer />
    </>
  );
};

export default LoginForm;
