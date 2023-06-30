//* https://localhost:7290/api/Paciente *//

const URLPaciente = 'https://localhost:7290/api/'

async function savePaciente(){   

    var dataPaciente = {
        "documento_Id": document.getElementById('txtIdPaciente').value,
        "num_Documento": document.getElementById('txtNumDoc').value,
        "nombre": document.getElementById('txtName').value,
        "apellido": document.getElementById('txtApellido').value,
        "sexo": document.getElementById('txtSexo').value,
        "fecha_Nacimiento": document.getElementById('txtDate').value,
        "rh": document.getElementById('txtRh').value
      }

        var urlPaciente =  URLPaciente + 'Paciente'
         await fetch(urlPaciente, {
            "method" : 'POST',
            "body": JSON.stringify(dataPaciente),
            "headers": {
                "Content-Type" : 'application/json'
            }
        })
        alert("Usuario registrado correctamente")
        window.location.reload();
}