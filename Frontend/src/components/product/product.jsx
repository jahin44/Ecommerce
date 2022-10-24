import classes from "./product.css";
import { Button } from "@material-ui/core";
import React, { useState } from "react";

const Product = ({ product, addToCart }) => {
  const setToCart = () => {
    if (product.stock > 0) {
      addToCart(product.id, product.name,product.price);
      product.stock = product.stock - 1;
    }
  };
  return (
    <a>
      <div className="video">
        <p>{product.name}</p>
        <p>Price: {product.price}</p>
        <p>Stock: {product.stock}</p>
        <div>
          <Button
            variant="contained"
            color="default"
            size="large"
            className={classes.button}
            title="Add"
            onClick={setToCart}
          >
            {" "}
            Add to cart
          </Button>
        </div>
      </div>
    </a>
  );
};

export default Product;
