import NavMenubar from "../components/navbar/NavMenubar";
import Products from "../components/products/products";
import Cart from "../components/cart/cart";
import { useEffect, useState } from "react";
import classes from "./dashboard.css";
import axios from "axios";
import { Routes, Route, useNavigate } from "react-router-dom";

const Dashboard = () => {
  const [cartItems, setCartItems] = useState([]);
  const [totalPrice, setTotalPrice] = useState(0);
  
  let isOrderSuccess = true;
  const navigate = useNavigate();

  const orderClick = async () => {
    console.log(cartItems);
    try {
      await axios
        .post("https://localhost:7137/api/Order", cartItems)
        .then((res) => {
          if (res.status === 200) {
            setTotalPrice(0);
            setCartItems([]);
          } else{ navigate("/LogIn");}
        })
        .catch((err) => console.error(err));
    } catch (err) {
      console.log(err);
    }
  };
  useEffect(() => {
    for (let i in cartItems) {
      setTotalPrice(totalPrice + cartItems[i].price);
      console.log(totalPrice);
    }
  }, [cartItems]);

  return (
    <>
      <NavMenubar />
      <Products cart={cartItems} setCart={setCartItems} />
      <div className="cart">
        <button className="order" onClick={orderClick}>
          Order
        </button>
        <table className="table_row">
          <tr>
            <th>Name</th>
            <th>Quantity</th>
          </tr>
        </table>
        {cartItems.map((product) => (
          <Cart product={product} />
        ))}
        <div className="price">ToTal Price={totalPrice}</div>
      </div>
    </>
  );
};

export default Dashboard;
