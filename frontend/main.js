window.addEventListener('DOMContentLoaded',(event)=>{ 
    getVisitCount();
})


const functionApi = ''; //URL of the API 

const getVisitCount = () => {
    let count = 30;
    fetch(functionApi).then(response =>{ // get the data from the URL that call the azure Function 
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