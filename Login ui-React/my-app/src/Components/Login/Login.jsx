import React from 'react';
import { Modal, Button, Form } from 'react-bootstrap';
import './Login.css'


const SignUpForm = ({ show, handleClose }) => {
  return (
    <Modal show={show} onHide={handleClose} centered >
      <Modal.Header closeButton>
        <Modal.Title>Sign Up</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form className="SignUpForm">
          <Form.Group controlId="formBasicEmail">
            <Form.Label>User Name</Form.Label>
            <Form.Control type="text" placeholder="Enter email" />
          </Form.Group>
          <Form.Group controlId="formBasicEmail">
            <Form.Label>Password</Form.Label>
            <Form.Control type="password" placeholder="Enter User password" />
          </Form.Group>
          <div class="d-grid gap-2">
            <button class="btn btn-light" type="button">Sign in</button>
          </div>
        </Form>
      </Modal.Body>
    </Modal>
  );
};

export default SignUpForm;
