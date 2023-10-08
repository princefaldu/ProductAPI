// ProductForm.js
import React, { useState } from 'react';

const ProductForm = ({ onSubmit }) => {
    const [name, setName] = useState('');
    const [Category, setCategory] = useState('');
    const [Description, setDescription] = useState('');
    const [Status, setStatus] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit({ name, Category, Description, Status  });
        setName('');
        setCategory('');
        setDescription('');
        setStatus('');
    };

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                placeholder="Product Name"
                value={name}
                onChange={(e) => setName(e.target.value)}
                required
            />
            <input
                type="text"
                placeholder="Category"
                value={Category}
                onChange={(e) => setCategory(e.target.value)}
                required
            />
            <input
                type="number"
                placeholder="Description"
                value={Description}
                onChange={(e) => setDescription(e.target.value)}
                required
            />
            <input
                type="number"
                placeholder="Status"
                value={Status}
                onChange={(e) => setStatus(e.target.value)}
                required
            />
            <button type="submit">Add Product</button>
        </form>
    );
};

export default ProductForm;
