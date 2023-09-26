using CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorio
{
    public interface IFuncionarioRepositorio
    {
        Task<Funcionario> ObtenerFuncionario(int idFuncionario);
        Task<List<Funcionario>> ObtenerFuncionarios();
        
    }
}
