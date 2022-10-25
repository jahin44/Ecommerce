import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import NavDropdown from "react-bootstrap/NavDropdown";
import classes from "./navMenubar.css";
import { Routes, Route, useNavigate } from "react-router-dom";

const NavMenubar = ({ children }) => {
  const navigate = useNavigate();
  let Token = localStorage.getItem("Token");
  let btn;
  if (Token == null) {
    btn = "LogIn";
  } else {
    btn = "LogOut";
  }
  const login = () => {
    if (window.confirm("Want to LogOut?") == true) {
      let Token = localStorage.getItem("Token");
      localStorage.removeItem("Token");
      navigate("/Login");
    }
  };

  return (
    <>
      <nav className="nav">
        <ul>
          <li>
            <h1>E-Shop</h1>
          </li>
          <li>
            <button
              onClick={() => {
                navigate("/");
              }}
              className="brand"
            >
              <h3>Dashboard</h3>
            </button>
          </li>
          <li>
            <button
              onClick={() => {
                navigate("/Reports");
              }}
              className="brand"
            >
              <h3>Report</h3>
            </button>
          </li>
          <li>
            <button
              onClick={() => {
                navigate("/AdminPanel");
              }}
              className="brand"
            >
              <h3>Admin Panel</h3>
            </button>
          </li>
          <li>
            <button onClick={login} className="brand">
              <h3>{btn}</h3>
            </button>
          </li>
        </ul>
      </nav>
    </>
  );
};

export default NavMenubar;
