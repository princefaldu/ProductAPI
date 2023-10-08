import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Product from './Component/Product';
import ProductForm from './Component/AddProduct';
import axios from 'axios';
import { useEffect } from 'react';

function App() {
    const [products, setProducts] = useState([]);
    const [editingId, setEditingId] = useState(null);
    const [data, setData] = useState({});
    //consol.log("Hello world");
    //useEffect(() => {
    //    fetchProducts();
    //}, []);

    //const fetchProducts = async () => {
    //    const response = await axios.get('http://localhost:7274/api/products/getallproducts');

    //    .then((response) => {
    //        setData(response.data);
    //    })
    //    .catch((error) => {
    //        console.error('Error fetching data:', error);
    //    });
    //};
    useEffect(() => {
        
        axios.get('http://localhost:7274/api/products/getallproducts')
            .then((response) => {
                setData(response?.data);
                console.log(response);
            })
            .catch((error) => {
                console.error('Error fetching data:', error);
            });
    }, []);

    const addProduct = async (product) => {
        try {
            const response = await axios.post('http://localhost:7274/api/products/AddNewProducts', product);  
            setProducts([...products, response.data]);
        } catch (error) {
            console.error('Error adding product:', error);
        }
    };

    const deleteProduct = async (id) => {
        try {
            await axios.delete(`http://localhost:7274/api/products/DeleteProductsByID/${id}`); 
            setProducts(products.filter((product) => product.id !== id));
        } catch (error) {
            console.error('Error deleting product:', error);
        }
    };

    const updateProduct = (id) => {
        setEditingId(id);
    };

    const saveProduct = async (id, updatedProduct) => {
        try {
            await axios.put(`http://localhost:7274/api/products/UpdateProducts/${id}`, updatedProduct); 
            const updatedProducts = products.map((product) =>
                product.id === id ? { ...updatedProduct, id } : product
            );
            setProducts(updatedProducts);
            setEditingId(null);
        } catch (error) {
            console.error('Error updating product:', error);
        }
    };

    return (
        <div className="App">
            <h1>Product CRUD</h1>

            <div>
                <h1>Table Data</h1>
                <table>
                    <thead>
                        <tr>
                            <th>ProductID</th>
                            <th>Name</th>
                            <th>Category</th>
                            <th>Description</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.map((item) => (
                            <tr key={item.ProductID}>
                                <td>{item.ProductID}</td>
                                <td>{item.Name}</td>
                                <td>{item.Category}</td>
                                <td>{item.Description}</td>
                                <td>{item.Status}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>

            <ProductForm onSubmit={addProduct} />
            {/*{products.map((product) => (*/}
            {/*    <Product*/}
            {/*        key={product.ProductID}*/}
            {/*        product={product}*/}
            {/*        onDelete={deleteProduct}*/}
            {/*        onUpdate={updateProduct}*/}
            {/*    />*/}
            {/*))}*/}
        </div>
    );
}

export default App
