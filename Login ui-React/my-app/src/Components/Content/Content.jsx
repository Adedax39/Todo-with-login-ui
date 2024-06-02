import * as React from 'react';
import Box from '@mui/material/Box';
import './Content.css'
import Button from 'react-bootstrap/Button';
import ArrowForwardIosIcon from '@mui/icons-material/ArrowForwardIos';
import { useState } from 'react';
import SignUpForm from '../Login/Login.jsx';

export default function BoxSystemProps() {
    const[showSignUp,setShowSignUp] = useState(false);
    const handleShow = () => setShowSignUp(true);
    const handleClose = () => setShowSignUp(false);

  return (
    <div className={`MuiBox-root ${showSignUp ? 'blur-background' : ''}`}>
    <h1 className='success'>Success</h1>
     <p className='message'>consists of going from failure to failure without loss of enthusiasm.</p>  
     <br/>
     <br />
     <div>
     <p className='message'>Try join with us.</p>
     <br/>
     <br/>
     <br/>
     <a href="#" class="myButton1" onClick={handleShow}>Sign up<ArrowForwardIosIcon/></a>
     <a href="#" class="myButton">Sign in<ArrowForwardIosIcon/></a>
     </div>
     <SignUpForm show={showSignUp} handleClose={handleClose} />
    </div>
  );
}