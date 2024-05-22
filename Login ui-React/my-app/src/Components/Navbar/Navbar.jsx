import Container from 'react-bootstrap/Container';
import Navbar from 'react-bootstrap/Navbar';
import Button from '@mui/material/Button';

const Navbar1 = () =>{
    return(
    <Navbar className="bg-body-tertiary">
      <Container>
        <Navbar.Brand href="#home" className='Topic'>Todo-App</Navbar.Brand>
        <Navbar.Toggle />
        <Navbar.Collapse className="justify-content-end">
        <Button >Sign in</Button>
        <Button >Sign up</Button>
        </Navbar.Collapse>
      </Container>
    </Navbar>
    )

}
export default Navbar1