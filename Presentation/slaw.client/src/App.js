import './App.css';
import Login from './pages/Login';
import PracticeAreas from './pages/PracticeAreas';
import { Outlet, Route, Routes, useLocation } from 'react-router-dom';
import Navbar from './components/Navbar';
import Footer from './components/Footer';
import PracticeArea from './pages/PracticeArea';
import Home from "./pages/Home"
import AboutUs from './pages/AboutUs';
import Contact from './pages/Contact';
import { useEffect } from 'react';

function App() {

  const location = useLocation();

  const isLoginPage = location.pathname === '/login';
  const appClassName = isLoginPage ? 'App align-items-center' : 'App';

  return (
    <div className={appClassName}>
      {!isLoginPage && <Navbar />}
    <div className="content">
    <Routes>
      <Route path="/" element={<Home />}></Route>
      <Route path="/practice-areas" element={<PracticeAreas /> }></Route>
      <Route path="/about-us" element={<AboutUs />}></Route>
      <Route path="/contact" element={<Contact />}></Route>
      <Route path="/practice-area/:id" element={<PracticeArea />}></Route>
    </Routes>
    </div>
      {!isLoginPage && <Footer />} 

    </div>
  );
}

export default App;
