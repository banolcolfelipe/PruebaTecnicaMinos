using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Repositories
{
    public interface ITipo_Doc
    {
        Task<IEnumerable<Tipo_Documento>> GetAllTipoDocs();
        Task<Tipo_Documento> GetDetails(int id);
        Task<bool> InsertTipoDoc(Tipo_Documento tipoDoc);
        Task<bool> DeleteTipoDoc(Tipo_Documento tipoDoc);
        Task<bool> UpdateTipoDoc(Tipo_Documento tipoDoc);
    }
}
