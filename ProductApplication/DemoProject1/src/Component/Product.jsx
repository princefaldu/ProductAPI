import React from 'react';

const Product = ({ product, onDelete, onUpdate }) => {
    const { ProductID, Name, Category, Description, Status } = product;

    return (
        <div className="product">

            <h3>{ProductID}</h3>
            <h3>{Name}</h3>
            <h3>{Category}</h3>
            <h3>{Description}</h3>
            <h3>{Status}</h3>
            <button onClick={() => onDelete(ProductID)}>Delete</button>
            <button onClick={() => onUpdate(ProductID)}>Edit</button>
        </div>
    );
};

export default Product;
