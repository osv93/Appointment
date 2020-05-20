import { patientConstants } from '../constants';
import { patientService } from '../services';

export const patientActions = {
    getAll
};

function getAll() {
    return dispatch => {
        dispatch(request());

        patientService.getAll()
            .then(
                patients => dispatch(success(patients)),
                error => dispatch(failure(error.toString()))
            );
    };

    function request() { return { type: patientConstants.GETALL_REQUEST } }
    function success(patients) { return { type: patientConstants.GETALL_SUCCESS, patients } }
    function failure(error) { return { type: patientConstants.GETALL_FAILURE, error } }
}