import React, { useState } from 'react';
import axios from 'axios';

function Form (props) {

    const [userName, setUserName] = useState("");

    const axiosConfig = {
        headers: {
            'Accept': 'application/vnd.github.v3+json'
        }
      };
    
    const handleSubmit = async (event) =>{
        event.preventDefault();
        const resp = await axios.get(`https://api.github.com/users/${userName}`,axiosConfig)
        props.onSubmit(resp);
        setUserName("");
    };

    return (
        <form onSubmit={handleSubmit}>
            <input type="text" 
            placeholder="Patient name" 
            value={userName}
            onChange={event => setUserName(event.target.value)}
            required>
            </input>
            <button >Add card</button>
        </form>
    );
}

export default Form;