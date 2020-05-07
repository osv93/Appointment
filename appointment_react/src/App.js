import React, {useState , useEffect} from 'react';
import Card from './Components/Patient/Card'
import Form from './Components/Form'
import './App.css';

import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';

function Button(props){
  const handleClick = () => props.onClickFunction(props.increment);
  return <button onClick={handleClick}>
                  +{props.increment}
        </button>
}

function Display(props){
  return(
    <div>{props.message}</div>
  );
}

function useClock(){
  const [date, setDate] = useState(new Date());

  useEffect(() => {
    const timerID = setInterval(() => tick(),
      1000
    )
    return () => {
      clearInterval(timerID);
    };
  },[date]);

  const tick = () =>{
    setDate(new Date());
  };

  return date;
}

function App () { 

  const [counter, setCounter] = useState(5);
  const [patients, setPatients] = useState([]);
  const date = useClock();

  const addNewProfile = (newProfile) =>{
     setPatients([...patients,  newProfile.data]);
  };

  const incrementMethod = (incrementValue) => {
    setCounter(counter + incrementValue);
  }

    return (
      <div>
        <div><h2>It is {date.toLocaleTimeString()}.</h2></div>
        <div className="App">
          <Button onClickFunction={incrementMethod} increment={1}/>
          <Button onClickFunction={incrementMethod} increment={5}/>
          <Button onClickFunction={incrementMethod} increment={10}/>
          <Display message={counter}/>
          <Form onSubmit={addNewProfile}/>
          <Grid item xs={12} sm={8}>
                <Paper >
                  <Card patients={patients}></Card>
                </Paper>
          </Grid>
        </div>
      </div>
    )
  

}

export default App;
