import './App.css';
import Content from './Components/Content/Content';
import Navbar1 from './Components/Navbar/Navbar';
import backgroundImage from './images/wp4069431.png';
import BoxSystemProps from './Components/Content/Content';

function App() {
  return (
<div className='app'>
  <div className='background'></div>
  <div className='content-navbar'>
  <Navbar1 /> 
  </div>
  <BoxSystemProps />
</div>

  );
}

export default App;





// export default function App() {
//   return (
//     <Spline scene="https://prod.spline.design/J1cHlCskNK99BAFX/scene.splinecode" />
//   );
// }

