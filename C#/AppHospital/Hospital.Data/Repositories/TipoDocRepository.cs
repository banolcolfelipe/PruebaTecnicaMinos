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
    public class TipoDocRepository : ITipo_Doc
    {
        private readonly MySQLConfiguration _connectionString;
        public TipoDocRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        // Funcionalidad 

        public async Task<IEnumerable<Tipo_Documento>> GetAllTipoDocs()
        {
            var db= dbConnection();
            var sql = @"SELECT id, nom_doc
                        FROM tipo_documento";

            return await db.QueryAsync<Tipo_Documento>(sql, new { });
        }


        public async Task<Tipo_Documento> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, nom_doc
                        FROM tipo_documento
                        WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Tipo_Documento>(sql, new {Id = id });
        }

        public async Task<bool> InsertTipoDoc(Tipo_Documento tipoDoc)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO tipo_documento(nom_doc) 
                        VALUES(@Nom_Doc)";

            var result = await db.ExecuteAsync(sql, new 
                { tipoDoc.Nom_Doc  });

            return result > 0;
        }

        public async Task<bool> UpdateTipoDoc(Tipo_Documento tipoDoc)
        {
            var db = dbConnection();

            var sql = @"UPDATE tipo_documento
                        SET id=@Id,
                            nom_doc = @Nom_Doc
                        WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new
            { tipoDoc.Id, tipoDoc.Nom_Doc });
            return result > 0;
        }

        

        public async Task<bool> DeleteTipoDoc(Tipo_Documento tipoDoc)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM tipo_documento WHERE id = @Id ";
            var result = await db.ExecuteAsync(sql, new { Id = tipoDoc.Id });
            return result > 0;
        }

    }
}
