import { patientConstants } from '../constants';

const patientsReducer = (state = {}, action) => {
    switch(action.type){
        case patientConstants.GETALL_REQUEST:
            return {
                ...state,
                user: action.payload
                // loggedIn: true
            }
        case patientConstants.GETALL_SUCCESS:
            return {
                patients: action.patients
              };
        case patientConstants.GETALL_FAILURE:
            return {
                ...state,
                user: {},
                // loggedIn: false
            }
        default:
            return state
    }
}

export default patientsReducer;