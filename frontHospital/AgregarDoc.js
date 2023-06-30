
//* https://localhost:7290/api/TipoDoc *//

const URL_API = 'https://localhost:7290/api/'




async function save(){
    var data = {
        "Nom_Doc": document.getElementById('txtDoc').value
      }

    var url = URL_API + 'TipoDoc'
     await fetch(url, {
         "method": 'POST',
         'body': JSON.stringify(data),
         "headers":{
             "Content-type": 'application/json'
         }
         

     })
     alert("Usuario registrado correctamente")
     window.location.reload();
    
 }
 