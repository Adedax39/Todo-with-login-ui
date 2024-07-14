import * as React from 'react';
import './Content.css'
import ArrowForwardIosIcon from '@mui/icons-material/ArrowForwardIos';
import { useState } from 'react';
import SignUpForm from '../SignUp/signup.jsx';
import LoginForm from '../LoginNew/loginNew.jsx';
import { useNavigate } from 'react-router-dom';
export default function BoxSystemProps() {
  const [showLogin, setShowLogin] = useState(false);
  const [showSignUp, setShowSignUp] = useState(false);
  const [visible, setVisible] = useState(false);
  const navigate = useNavigate();

  const handleClose = () => {
    setShowLogin(false)
    setVisible(false)
  };

  const handleClose1 = () => {
    setVisible(false)
    setShowSignUp(false)
  };
  const handleShowSignUp = () => {
    setVisible(true)
    setShowSignUp(true);
  }
  const handleShowLogin = () => {
    setVisible(true)
    setShowLogin(true);
  }




  return (
    <div>
<div className='background'></div>
    
    <div className={`MuiBox-root ${showLogin || showSignUp ? 'change-background' : ''}`}>
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
              <a className="signupButton" onClick={handleShowSignUp}>Sign up<ArrowForwardIosIcon /></a>
              <a className="loginButton" onClick={handleShowLogin}>Sign in<ArrowForwardIosIcon /></a>
            </div>
          </div>
        </div>
      )}

      {visible && (<div>
        <LoginForm show={showLogin} handleClose={handleClose} />
        <SignUpForm show={showSignUp} handleClose={handleClose1} />
      </div>)}

    </div>
    </div>
  );
}