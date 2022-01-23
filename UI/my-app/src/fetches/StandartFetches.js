
const apiUrl = 'https://localhost:44341/api';

function getStandart(controllerPlusId, thenFunc, errorFunc) {
    //let accessToken = localStorage.getItem('token');
    fetch(apiUrl + controllerPlusId, {
        method: 'GET',
        // headers: {
        //     'Authorization': 'bearer ' + accessToken
        // }
    })
        .then(response => {
            if(response.ok === true){
                return response.json()
            } 
            return null;    
        })
        .then(data => {
            console.log(data)
            if(data != null){
                thenFunc(data)
            } else{
                errorFunc()
            }
            
        })
}

export {getStandart, apiUrl}