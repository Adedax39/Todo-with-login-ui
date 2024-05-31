import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import Button from '@mui/material/Button';
import './Navbar.css' 

const Navbar1 = () =>{
    return(
    <Navbar className="bg-body-tertiary">
      <Container>
        <Navbar.Brand href="#home" className='Topic'>Todo-App</Navbar.Brand>
        <Navbar.Toggle />
        <Navbar.Collapse className="justify-content-end">
        <Button  className='Topic'>Created By Lasath Rathnayake</Button>
        </Navbar.Collapse>
      </Container>
    </Navbar>
    )

}
export default Navbar1