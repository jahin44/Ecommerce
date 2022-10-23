import classes from './cart.css';
import { Button } from '@material-ui/core';
import React, { useState } from 'react';



const Cart = ({product}) => {

    return (
        <a>
            <div className="video">
                <p>{product.name}</p>
                    <p>Price: {product.price}</p>
                    <p>Quantity: {product.quantity}</p>
                    {/* <div>
                        <Button
                            variant="contained"
                            color="default"
                            size="large"
                            className={classes.button}
                            title= "Add"
                            onClick={setToCart}
                        > Add to cart
                        </Button>
                    </div> */}
            </div>

        </a>
    );
}

export default Cart;