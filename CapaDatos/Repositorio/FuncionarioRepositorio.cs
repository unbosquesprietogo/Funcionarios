using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos.Configuracion;
using CapaDatos.Entidades;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly Conectar _conexion;

        public FuncionarioRepositorio(IOptions<Conectar> conexion)
        {
            _conexion = conexion.Value;
        }


        public async Task<List<Funcionario>> ObtenerFuncionarios()
        {
            List<Funcionario> lista = new List<Funcionario>();

            using (var conexion = new SqlConnection(_conexion.CadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerFuncionarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = await cmd.ExecuteReaderAsync())
                {

                    while (await dr.ReadAsync())
                    {

                        lista.Add(new Funcionario()
                        {
                            idFuncionario = Convert.ToInt32(dr["IdFuncionario"]),
                            nombre = dr["Nombre"].ToString(),
                            apellido = dr["Apellido"].ToString(),
                            fechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                            documentoIdentificacion = dr["DocumentoIdentificacion"].ToString()
                        });


                    }
                }


            }

            return lista;
        }

        public async Task<Funcionario> ObtenerFuncionario(int idFuncionario)
        {
            Funcionario funcionario = new Funcionario();

            using (var conexion = new SqlConnection(_conexion.CadenaSQL))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerFuncionario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agrega el parámetro al comando
                SqlParameter parametro = new SqlParameter("@idFuncionario", idFuncionario);
                cmd.Parameters.Add(parametro);

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        funcionario = new Funcionario()
                        {
                            idFuncionario = Convert.ToInt32(dr["IdFuncionario"]),
                            nombre = dr["Nombre"].ToString(),
                            apellido = dr["Apellido"].ToString(),
                            fechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                            documentoIdentificacion = dr["DocumentoIdentificacion"].ToString()
                        };
                    }
                }
            }

            return funcionario;
        }

    }
}
