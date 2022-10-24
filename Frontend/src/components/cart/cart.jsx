import classes from "./cart.css";
import { Button } from "@material-ui/core";
import React, { useState } from "react";

const Cart = ({ product }) => {
  return (
    <a>
      <table className="tabledata">
          <td>{product.name}</td>
          <td>{product.quantity}</td>
          <td>
            <button>+</button>
          </td>
          <td>
            <button>-</button>
          </td>
      </table>
    </a>
  );
};

export default Cart;
