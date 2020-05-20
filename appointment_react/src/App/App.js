import React, { useEffect} from 'react';
import {useSelector, useDispatch} from 'react-redux'

import { patientActions } from '../actions';

const App = () => { 

  const patientsReducer = useSelector(state => state.patientsReducer);

  const dispatch = useDispatch()

  useEffect(() => {
    dispatch(patientActions.getAll());
  }, []);

  var listItems;
if(patientsReducer.patients){
 listItems = patientsReducer.patients.map((d) => <li key={d.name}>{d.name}</li>);

}

    return (
      
      <div>
        {console.log(patientsReducer.patients)}
        <div><h2>Hola.</h2></div>
    <div>{listItems}</div>
      </div>
    )
  

}

export { App };
