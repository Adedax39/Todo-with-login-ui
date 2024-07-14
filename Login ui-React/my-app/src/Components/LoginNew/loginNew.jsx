import React from 'react';
import { Modal, Form } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import './loginNew.css';

const LoginForm = ({ show, handleClose }) => {
  const navigate = useNavigate();

  const handleSignIn = () => {
    navigate("/todolist"); 
  };

  return (
    <Modal show={show} onHide={handleClose} centered>
      <Modal.Header closeButton>
        <Modal.Title>Sign In</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form className="SignUpForm">
          <Form.Group controlId="formBasicEmail">
            <Form.Label>User Name</Form.Label>
            <Form.Control type="text" placeholder="Enter email" />
          </Form.Group>
          <Form.Group controlId="formBasicPassword">
            <Form.Label>Password</Form.Label>
            <Form.Control type="password" placeholder="Enter User password" />
          </Form.Group>
          <div className="d-grid gap-2">
            <button className="btn btn-light" type="button" onClick={handleSignIn}>Sign in</button>
          </div>
        </Form>
      </Modal.Body>
    </Modal>
  );
};

export default LoginForm;
