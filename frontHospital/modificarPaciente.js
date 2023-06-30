//* https://localhost:7290/api/Paciente *//

const URLPaciente = 'https://localhost:7290/api/'

async function editPaciente(){   

    var newDataPaciente = {
        "id":document.getElementById('txtIdPaciente').value,
        "documento_Id": document.getElementById('txtIdDocP').value,
        "num_Documento": document.getElementById('txtNumDoc').value,
        "nombre": document.getElementById('txtName').value,
        "apellido": document.getElementById('txtApellido').value,
        "sexo": document.getElementById('txtSexo').value,
        "fecha_Nacimiento": document.getElementById('txtDate').value,
        "rh": document.getElementById('txtRh').value
      }

        var urlPaciente =  URLPaciente + 'Paciente'
         await fetch(urlPaciente, {
            "method" : 'PUT',
            "body": JSON.stringify(newDataPaciente),
            "headers": {
                "Content-Type" : 'application/json'
            }
        })
        alert("Usuario actualizado correctamente")
        window.location.reload();
}