using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class SubCategoriaDA : ISubCategoriaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;


        public SubCategoriaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        public async Task<IEnumerable<SubCategoria>> Obtener(Guid IdCategoria)
        {
            string query = @"ObtenerSubCategorias";
            var resultadoConsulta = await _sqlConnection.QueryAsync<SubCategoria>(query,
                new { IdCategoria });
            return resultadoConsulta;
        }
    }
}
