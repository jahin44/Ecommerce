import NavMenubar from "../components/navbar/NavMenubar";
import Products from "../components/products/products";

const Dashboard = () => {
    var AllItems = sessionStorage.getItem("CartItems");

    return (
        <>
            <NavMenubar />
            <Products />
        </>
    )
}

export default Dashboard;