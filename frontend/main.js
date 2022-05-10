window.addEventListener('DOMContentLoaded',(event)=>{ 
    getVisitCount();
})


const local_functionApi = 'http://localhost:7071/api/GetResumeCounter'; //URL of the API 
const FunctionApiURL = 'https://getresumecounterid.azurewebsites.net/api/GetResumeCounter?code=mTi6zbV4fgMoyHG5wNbjqT7pcWz5dPwxAvypMe-xTURGAzFuCTQ5ag==';

const getVisitCount = () => {
    let count = 30;
    fetch(FunctionApiURL).then(response =>{ // get the data from the URL that call the azure Function 
        return response.json()
    }).then(response =>{
        console.log("Website call Function API.");
        count = response.count; // assign whatever json responds 
        document.getElementById("counter").innerText = count; 
    }).catch(function(error){
        console.log(error);
    });
    return count;
}