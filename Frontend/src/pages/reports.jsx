import NavMenubar from "../components/navbar/NavMenubar";
import { useEffect, useState } from "react";
import axios from "axios";
import classes from "./reports.css";


const Reports = () => {
  const [reports, setReports] = useState([]);

  useEffect(() => {
    try {
      axios
        .get("https://localhost:7137/api/order")
        .then((res) => {
          if (res.status === 200) {
            setReports(res.data);
            console.log("Success");
          }
        })
        .catch((err) => console.error(err));
    } catch (err) {
      console.log(err);
    }
  }, []);
  return (
    <>
      <NavMenubar />
      <div className="tableReport">
        <h2>Report </h2>
        <table>
          <tr>
            <th>Product Name</th>
            <th>Quantity</th>
            <th>User Name</th>
            <th>Order Id</th>
          </tr>
          {reports.map((report) => (
            <tr>
              <td>{report.name}</td>
              <td>{report.quantity}</td>
              <td>{report.userName}</td>
              <td>{report.orderId}</td>
            </tr>
          ))}
        </table>
      </div>
    </>
  );
};

export default Reports;
