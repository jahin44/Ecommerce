import NavMenubar from "../components/navbar/NavMenubar";
import Products from "../components/products/products";
import Cart from "../components/cart/cart";
import { useEffect, useState } from "react";
import classes from "./dashboard.css";

const Dashboard = () => {
  const [cartItems, setCartItems] = useState([{}]);

  useEffect(() => {
    console.log(cartItems, "all items log");
  }, [cartItems]);
  return (
    <>
      <NavMenubar />
      <Products cart={cartItems} setCart={setCartItems} />
      <div className="cart">
      <table className="table_row">
        <tr>
          <th>Name</th>
          <th>Quantity</th>
          <th>   </th>
        </tr>
      </table>
      {cartItems.map((product) => (
          <Cart product={product}/>
        ))}
    </div>
        
    </>
  );
};

export default Dashboard;
