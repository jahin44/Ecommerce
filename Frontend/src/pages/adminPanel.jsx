import NavMenubar from "../components/navbar/NavMenubar";
import classes from "./adminPanel.css";
import { useEffect, useState } from "react";
import axios from "axios";
import { Routes, Route, useNavigate } from "react-router-dom";

const AdminPanel = () => {
  const [products, setProducts] = useState([]);
  const [name, setName] = useState();
  const [stock, setStock] = useState();
  const [price, setPrice] = useState();
  const [id, setId] = useState(0);
  const navigate = useNavigate();
  let Token = localStorage.getItem("Token");

  const addProduct = async () => {
    setId(0);
    setName("");
    setPrice(0);
    setStock(0);
  };
  const deleteProduct = async (Id) => {
    let Token = localStorage.getItem("Token");
    console.log(Id);
    if (window.confirm("Do You want Delete this product?") == true) {
      try {
        axios
          .delete("https://localhost:7137/api/Products/" + Id, {
            headers: { Authorization: `Bearer ${Token}` },
          })
          .then((res) => {
            if (res.status === 200) {
            }
          })
          .catch((err) => console.error(err));
      } catch (err) {
        console.log(err);
      }
    }
    window.location.reload();
  };
  const editProduct = async (product) => {
    setId(product.id);
    setName(product.name);
    setPrice(product.price);
    setStock(product.stock);
  };
  const submit = async () => {
    let Token = localStorage.getItem("Token");
    console.log(Token);
    if (window.confirm("Are you sure") == true) {
      if (id === 0) {
        try {
          axios
            .post(
              "https://localhost:7137/api/Products",
              { name: name, price: price, stock: stock },
              { headers: { Authorization: `Bearer ${Token}` } }
            )
            .then((res) => {
              if (res.status === 200) {
                setProducts(res.data);
                console.log("Success");
                setId(0);
              }
            })
            .catch((err) => console.error(err));
        } catch (err) {
          console.log(err);
        }
      } else {
        try {
          axios
            .put(
              "https://localhost:7137/api/Products",
              { id: id, name: name, price: price, stock: stock },
              { headers: { Authorization: `Bearer ${Token}` } }
            )
            .then((res) => {
              if (res.status === 200) {
                setProducts(res.data);
                console.log("Success");
                setId(0);
              }
            })
            .catch((err) => console.error(err));
        } catch (err) {
          console.log(err);
        }
      }
    }
  };
  useEffect(() => {
    let Token = localStorage.getItem("Token");
    try {
      axios
        .get("https://localhost:7137/api/Products", {
          headers: { Authorization: `Bearer ${Token}` },
        })
        .then((res) => {
          if (res.status === 200) {
            setProducts(res.data);
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
      <div className="tableStart">
        <button className="btn" type="button" onClick={addProduct}>
          Add Product
        </button>
        <table>
          <tr>
            <th>Product Name</th>
            <th>Stock</th>
            <th>Price</th>
            <th className="action">Action</th>
          </tr>
          {products.map((product) => (
            <tr>
              <td>{product.name}</td>
              <td>{product.stock}</td>
              <td>{product.price}</td>
              <td>
                <button
                  className="btn"
                  onClick={() => {
                    editProduct(product);
                  }}
                >
                  Edit
                </button>
                <button
                  className="btn"
                  onClick={() => {
                    deleteProduct(product.id);
                  }}
                >
                  Delete
                </button>
              </td>
            </tr>
          ))}
        </table>
        <form className="form">
          <label className="input">
            Product name
            <input
              type="text"
              value={name}
              onChange={(e) => setName(e.target.value)}
            />{" "}
          </label>

          <label className="input">
            Stock
            <input
              type="number"
              value={stock}
              onChange={(e) => setStock(e.target.value)}
            />
          </label>
          <label className="input">
            Price
            <input
              type="number"
              value={price}
              onChange={(e) => setPrice(e.target.value)}
            />
          </label>
          <button
            className="btn"
            onClick={() => {
              submit();
            }}
          >
            Submit
          </button>
        </form>
      </div>
    </>
  );
};

export default AdminPanel;
