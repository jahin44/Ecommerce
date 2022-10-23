import logo from './logo.svg';
import './App.css';
import {
  createBrowserRouter,
  RouterProvider,
  Route,
} from "react-router-dom";
import Dashboard from './pages/dashboard';
import Navbar from './components/navbar/NavMenubar';
import NavMenubar from './components/navbar/NavMenubar';
import Login from './pages/login';
import AdminPanel from './pages/adminPanel';
import Reports from './pages/reports';

function App() {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <Dashboard />,
    },
    {
      path: "navbar",
      element: <Navbar />,
    },
    {
      path: "login",
      element: <Login />,
    },
    {
      path: "adminPanel",
      element: <AdminPanel />,
    },
    {
      path: "reports",
      element: <Reports />,
    },
  ]);
  
  return (
    <RouterProvider router={router} />
  );
}

export default App;
