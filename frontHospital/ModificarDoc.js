const URLDocumento = 'https://localhost:7290/api/'

async function editDocumento(){
    var dataDocumento = {
        "id": document.getElementById('txtIdDoc').value,
        "Nom_Doc": document.getElementById('txtDoc').value
      }

    var urlDoc = URLDocumento + 'TipoDoc'
     await fetch(urlDoc, {
         "method": 'PUT',
         'body': JSON.stringify(dataDocumento),
         "headers":{
             "Content-type": 'application/json'
         }
         

     })
     alert("Usuario actualizado correctamente")
     window.location.reload();
    
 }
 