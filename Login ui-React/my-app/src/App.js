import './App.css';
import Navbar1 from './Components/Navbar/Navbar';
import BoxSystemProps from './Components/Content/Content';
import TodoList from './Details/todo';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
      <div className='app'>
        <div className='content-navbar'>
          <Navbar1 />
        </div>
        <Routes>
          <Route path="/" element={<BoxSystemProps />} />
          <Route path="/todolist" element={<TodoList />} /> 
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
