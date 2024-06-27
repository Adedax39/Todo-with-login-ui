import * as React from 'react';
import Box from '@mui/material/Box';
import './Content.css'
import Button from 'react-bootstrap/Button';
import ArrowForwardIosIcon from '@mui/icons-material/ArrowForwardIos';
import { useState } from 'react';
import SignUpForm from '../Login/Login.jsx';
import SignUpForm1 from '../SignUp/signup.jsx';

export default function BoxSystemProps() {
  const [showSignUp, setShowSignUp] = useState(false);
  const [showSignUp1, setShowSignUp1] = useState(false);
  const [visible, setVisible] = useState(false);
  const handleShow = () => {
    setShowSignUp(true)
  setVisible(true)};
  const handleClose = () => {
    setShowSignUp(false)
  setVisible(false)};
  
  const handleShow1 = () => {
    setVisible(true)
    setShowSignUp1(true);
  }
  const handleClose1 = () => {
    setVisible(false)
    setShowSignUp1(false)
  };




  return (
    <div className={`MuiBox-root ${showSignUp || showSignUp1 ? 'change-background' : ''}`}>
      {!visible && (
        <div className='content-page'>
          <h1 className='success'>Success</h1>
          <p className='message'>consists of going from failure to failure without loss of enthusiasm.</p>
          <br />
          <br />
          <div>
            <p className='message'>Try join with us.</p>
            <br />
            <br />
            <br />
            <div className='button-group'>
            <a href="#" class="myButton1" onClick={handleShow1}>Sign up<ArrowForwardIosIcon /></a>
            <a href="#" class="myButton" onClick={handleShow}>Sign in<ArrowForwardIosIcon /></a>
            </div>
          </div>
        </div>
      )}

      {visible && (<div>
        <SignUpForm show={showSignUp} handleClose={handleClose} />
        <SignUpForm1 show={showSignUp1} handleClose={handleClose1} />
      </div>)}

    </div>

  );
}