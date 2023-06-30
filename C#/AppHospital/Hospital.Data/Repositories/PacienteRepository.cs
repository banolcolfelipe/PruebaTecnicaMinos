using Dapper;
using Hospital.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Repositories
{
    public class PacienteRepository : IPaciente
    {
        private readonly MySQLConfiguration _connectionString;
        public PacienteRepository (MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString); 
        }


        public async Task<IEnumerable<Paciente>> GetAllPacientes()
        {
            var db = dbConnection();
            var sql = @"SELECT id, documento_id,num_documento, nombre, apellido, sexo, fecha_nacimiento, rh
                        FROM paciente";
            return await db.QueryAsync<Paciente>(sql, new { });
        }

        public async Task<Paciente> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, documento_id, num_documento, nombre, apellido, sexo, fecha_nacimiento, rh
                        FROM paciente
                        WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Paciente>(sql, new { Id = id });
        }

        public async Task<bool> InsertPaciente(Paciente paciente)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO  paciente(documento_id, num_documento, nombre, apellido, sexo, fecha_nacimiento, rh) 
                        VALUES( @Documento_Id, @Num_Documento, @Nombre, @Apellido, @Sexo, @Fecha_Nacimiento, @Rh)";

            var result = await db.ExecuteAsync(sql, new
            { paciente.Documento_Id, paciente.Num_Documento, paciente.Nombre, paciente.Apellido,
                         paciente.Sexo, paciente.Fecha_Nacimiento, paciente.Rh });
            return result > 0;
        }

        public async Task<bool> UpdatePaciente(Paciente paciente)
        {
            var db = dbConnection();
            var sql = @"UPDATE  paciente
                        SET documento_id = @Documento_Id, 
                            num_documento = @Num_Documento,
                            nombre = @Nombre,
                            apellido = @Apellido, 
                            sexo = @Sexo, 
                            fecha_nacimiento= @Fecha_Nacimiento, 
                            rh= @Rh
                        WHERE id=@Id";

            var result = await db.ExecuteAsync(sql, new
            {
                paciente.Id,
                paciente.Documento_Id,
                paciente.Num_Documento,
                paciente.Nombre,
                paciente.Apellido,
                paciente.Sexo,
                paciente.Fecha_Nacimiento,
                paciente.Rh
            });
            return result > 0;
        }

        public async Task<bool> DeletePaciente(Paciente paciente)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM paciente WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = paciente.Id });
            return result > 0;
        }

    }
}
