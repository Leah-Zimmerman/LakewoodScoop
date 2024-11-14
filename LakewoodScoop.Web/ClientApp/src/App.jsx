import React, { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';

const App = () => {

    const [news, setNews] = useState([]);

    const scrapeLakewoodScoop = async () => {
        const { data } = await axios.get('/api/news/scrape');
        setNews(data);
    }
    useEffect(() => {
        scrapeLakewoodScoop();
    }, []);

    return (
        <>
            <div className='container'>
                <table className='table table-bordered table-striped table-hover'>
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Image</th>
                            <th>Text</th>
                            <th>Comments</th>
                        </tr>
                    </thead>
                    <tbody>
                        {news.map((item) => (
                            <tr key={item.url}>
                                <td>
                                    <a target='blank' href={item.url}>{item.title}</a>
                                </td>
                                <td>
                                    <img src={item.image} style={{width:'200px'}} />
                                </td>
                                <td>{item.text}</td>
                                <td>{item.comments}</td>
                            </tr>
                        ))}
                    </tbody>
            </table>
        </div >
    </>
  );
};

export default App;