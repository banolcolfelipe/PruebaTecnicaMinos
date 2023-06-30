using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital.Data.Repositories
{
    public interface IPaciente
    {
        Task<IEnumerable<Paciente>> GetAllPacientes();
        Task<Paciente> GetDetails(int id);
        Task<bool> InsertPaciente(Paciente paciente);
        Task<bool> DeletePaciente(Paciente paciente);
        Task<bool> UpdatePaciente(Paciente paciente);
    }
}
