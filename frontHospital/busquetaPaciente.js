const URL_API = 'https://localhost:7290/api/'

function buscarDatoPAciente() {
    var id = document.getElementById('inputIdPaciente').value;
    var urlDoc = URL_API + 'Paciente/' + id; 
  
    fetch(urlDoc, {
      "method": 'GET',
      "headers":{
        "Content-type": 'application/json'
      }
    })
    .then(response => {
      if (response.ok) {
        return response.json(); // Si la respuesta es exitosa, convierte la respuesta a JSON
      } else {
        throw new Error('Error al buscar el documento');
      }
    })
    .then(data => {
      var row = `
        <tr>
          <td scope="row">${data.id}</td>
          <td>${data.documento_Id}</td>
          <td>${data.num_Documento}</td>
          <td>${data.nombre}</td>
          <td>${data.apellido}</td>
          <td>${data.sexo}</td>
          <td>${data.fecha_Nacimiento}</td>
          <td>${data.rh}</td>
        <tr>`;
  
      document.querySelector('#pacienteTable > tbody').innerHTML = row;
    })
    .catch(error => {
      console.error('Error:', error);
      // Mensaje de error en la tabla
      document.querySelector('#pacienteTable > tbody').innerHTML = '<tr><td colspan="3">Error al buscar el documento</td></tr>';
    });
  }
  