import { combineReducers } from 'redux';

import patientsReducer from './patients.reducer';

const rootReducer = combineReducers({
    patientsReducer
});

export default rootReducer;