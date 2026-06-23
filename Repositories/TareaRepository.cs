using System.ComponentModel.Design;
using Dapper;
using Microsoft.Data.SqlClient;
using TaskApi.Models;
namespace TaskApi.Repositories

{
    public class TareaRepository
    {
        private readonly string _connectionString;
        public TareaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<TareaModel>> ObtenerTodas()
        {
            using var connection = GetConnection();
            return await connection.QueryAsync<TareaModel>("SELECT * FROM Tareas");

        }

        public async Task<TareaModel?> ObtenerPorId(int id)
        {
            using var connection = GetConnection();
            return await connection.QueryFirstOrDefaultAsync<TareaModel>("SELECT * FROM Tareas WHERE Id = @Id", new { Id = id });
        }
        public async Task<int> Crear(TareaModel tarea)
        {
            using var connection = GetConnection();
            var sql = @"INSERT INTO Tareas (Titulo,Descripcion,Completada,FechaCreacion)
                        VALUES (@Titulo, @Description, @Completada, @FechaCreacion);
                        SELECT SCOPE_IDENTTITY();";
              return await connection.ExecuteScalarAsync<int>(sql, tarea);
             
        }
        public async Task<bool> Actualizar(TareaModel tarea)
        {
            using var connection = GetConnection();
            var sql = @"UPDATE Tareas SET Titulo = @Titulo , Descripcion = @Descripcion, Completada = @Completada WHERE Id = @Id";
            var filas = await connection.ExecuteAsync(sql, tarea);
            return filas > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            using var connection = GetConnection();
            var filas = await connection.ExecuteAsync("DELETE FROM Tareas WHERE Id = @Id", new { Id = id });
            return filas > 0;

        }





    }
}


/// ME FALTA  EL ACTUALIZAR Y OBTENER POR ID