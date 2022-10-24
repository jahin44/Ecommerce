import classes from "./products.css";
import Product from "../product/product";
import axios from "axios";
import { useEffect, useState } from "react";

const Products = ({cart,setCart}) => {
  const [productsToDisplay, setProductsToDisplay] = useState([]);

  const addToCart = (id, name) => {
    let cartItems = [...cart];
    let isUnique = true;
    for (var i = 0; i < cartItems.length; i++) {
      if (id === cartItems[i].productId) {
        isUnique = false;
        cartItems[i].quantity = cartItems[i].quantity + 1;
      }
    }
    if (isUnique) {
      cartItems = [
        ...cartItems,
        { id: 0, name: name, productId: id, quantity: 1, orderId: 0 },
      ];
    }
    setCart(cartItems);
  };

  useEffect(() => {
    //Runs on every render
    axios
      .get("https://localhost:7137/api/products")
      .then((res) => {
        setProductsToDisplay(res.data);
      })
      .catch((err) => console.error(err));
  }, []);
  return (
    <div className="products">
      {productsToDisplay.map((product) => (
        <Product product={product} addToCart={addToCart} />
      ))}
    </div>
  );
};

export default Products;
