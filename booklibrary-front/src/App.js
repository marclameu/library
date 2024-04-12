import './App.css';
import React, { useEffect, useState } from 'react';
import './App.css';

function App() {
  const [options, setOptions] = useState([]);

  useEffect(() => {
    fetch('http://localhost:5086/api/Book')
      .then(response => response.json())
      .then(data => {
        console.log(data);
        setOptions(data);
      })
      .catch(error => console.error(error));
  }, []);

  const [searchValue, setSearchValue] = useState('');
  const [searchBy, setSearchBy] = useState('Author');

  const handleSearchValueChange = (event) => {
    setSearchValue(event.target.value);
  };

  const handleSearchByChange = (event) => {
    setSearchBy(event.target.value);
  };

  const handleSearch = () => {
    fetch(`http://localhost:5086/api/Book/search?by=${searchBy}&value=${searchValue}`)
      .then(response => response.json())
      .then(data => {
        setOptions(data);
      })
      .catch(error => console.error(error));
  };

  return (
    <div className="App">
      <header className="">
        <p>
          <h3>Search By:</h3>
          <h3>
            <select value={searchBy} onChange={handleSearchByChange}>
              <option value="Author">Author</option>
              <option value="ISBN">ISBN</option>
              <option value="TITLE">TITLE</option>
            </select>
          </h3>
        </p>
        <p>
          <h3>Search Value:</h3>
          <h3>
            <input type="text" value={searchValue} onChange={handleSearchValueChange} />
            <br />
            <button type="button" onClick={handleSearch}>Search</button>
          </h3>
          <h3>
            <table className=''>
              <thead>
                <tr>
                  <th>Book Title</th>
                  <th>Publisher</th>
                  <th>Authors</th>
                  <th>Type</th>
                  <th>ISBN</th>
                  <th>Category</th>
                  <th>Available Copies</th>
                </tr>
              </thead>
              <tbody>
                {options.map((option) => (
                  <tr key={option.id}>
                    <td>{option.title}</td>
                    <td>{option.firstName}</td>
                    <td>{option.lastName}</td>
                    <td>{option.type}</td>
                    <td>{option.isbn}</td>
                    <td>{option.category}</td>
                    <td>{option.availableCopies}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </h3>
        </p>
      </header>
    </div>
  );
}


export default App;
