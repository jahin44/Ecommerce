import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import classes from './navMenubar.css';
import {Routes, Route, useNavigate} from 'react-router-dom';


const NavMenubar = ({ children }) => {
    return (
      <>
      <nav className="nav">
          <ul>
              <li>
                  <h1>E-Shop</h1>
              </li>
              <li>
                  <a onClick={() => {}} className="brand">
                      <h3>Dashboard</h3>
                  </a>
              </li>
              <li>
                  <a onClick={() => {console.log("Image clicked on navbar")}} className="brand">
                      <h3>Report</h3>
                  </a>
              </li>
              <li>
                  <a onClick={() => {console.log("Image clicked on navbar")}} className="brand">
                      <h3>Admin Panel</h3>
                  </a>
              </li>
              <li>
                  <a onClick={() => {console.log("Image clicked on navbar")}} className="brand">
                      <h3>Login</h3>
                  </a>
              </li>
          </ul>
      </nav>
  </>
    );
}

export default NavMenubar;