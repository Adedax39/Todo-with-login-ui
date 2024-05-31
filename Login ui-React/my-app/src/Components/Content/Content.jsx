import * as React from 'react';
import Box from '@mui/material/Box';
import './Content.css'
import Button from 'react-bootstrap/Button';
import ArrowForwardIosIcon from '@mui/icons-material/ArrowForwardIos';

export default function BoxSystemProps() {
  return (
    <div className="MuiBox-root">
    <h1 className='success'>Success</h1>
     <p className='message'>consists of going from failure to failure without loss of enthusiasm.</p>  
     <br/>
     <br />
     <div>
     <p className='message'>Try join with us.</p>
     <br/>
     <br/>
     <br/>
     <a href="#" class="myButton1">Sign up<ArrowForwardIosIcon/></a>
     <a href="#" class="myButton">Sign in<ArrowForwardIosIcon/></a>
     </div>
    </div>
  );
}