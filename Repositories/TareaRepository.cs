using Dapper;
using Microsoft.Data.SqlClient;
using TaskApi.Models;
namespace TaskApi.Repositories

{
    public class TarerRespository
    {
        private readonly string _connectionString;  
        public TareaRepository(string connectionString)
    }
        _connectionString = connectionString;
    }

    private SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public async Task<IEnumerable<TareaModel>> ObtenerTodas()
    {
        usign var connection = getConnection();
        return await connection.QueryAsync<TareaModel>("SELECT * FROM Tareas");

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
        var filas = await connection.ExecuteAsync("DELETE FROM Tareas WHERE Id = @Id", new {Id = id});
        return filas > 0;
    }

    
}