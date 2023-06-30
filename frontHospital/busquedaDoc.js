/* https://localhost:7290/api/TipoDoc/1 */

const URL_API = 'https://localhost:7290/api/'

function buscarDato() {
    var id = document.getElementById('inputId').value;
    var urlDoc = URL_API + 'TipoDoc/' + id; 
  
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
          <td>${data.nom_Doc}</td>
        <tr>`;
  
      document.querySelector('#docTable > tbody').innerHTML = row;
    })
    .catch(error => {
      console.error('Error:', error);
      // Mensaje de error en la tabla
      document.querySelector('#docTable > tbody').innerHTML = '<tr><td colspan="3">Error al buscar el documento</td></tr>';
    });
  }
  