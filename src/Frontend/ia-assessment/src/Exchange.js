import * as React from 'react';
import {useEffect, useState} from 'react';
import Accordion from '@mui/material/Accordion';
import AccordionSummary from '@mui/material/AccordionSummary';
import AccordionDetails from '@mui/material/AccordionDetails';
import {Card, CardContent, CardHeader, CardMedia} from "@mui/material";
import './Exchange.css';

export default function Exchanges() {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        fetch('http://localhost:5000/Overview')
            .then(response => response.json())
            .then(data => {
                setData(data);
                setLoading(false);
            })
            .catch(error => console.error(error));
    }, []);

    return (
        <div>
            {loading ? (
                <div className="spinner"></div>
            ) : (
                <div>
                    {data.map(continent => (
                        <Accordion>
                            <AccordionSummary>
                                <b>{continent.continentName}</b>
                            </AccordionSummary>
                            <AccordionDetails>
                                {continent.countries.map(country => (
                                    <Card className="exchange">
                                        <CardContent>
                                            <div className="exchange-header">
                                                <img src="{country.countryFlagURL}"></img>
                                                <div>{country.exchangeName} ({country.countryName})</div>
                                            </div>
                                            <div>
                                                <p>Year: {country.yearEstablished}</p>
                                                <p>Has Incentive: {country.hasIncentive ? (<span>Yes</span>) : (<span>No</span>)}</p>
                                                <p>Trade: ${country.tradeVolume.toFixed(4)}</p>
                                            </div>
                                        </CardContent>
                                    </Card>
                                ))}
                            </AccordionDetails>
                        </Accordion>
                    ))}
                </div>
            )}
        </div>
    )
}
