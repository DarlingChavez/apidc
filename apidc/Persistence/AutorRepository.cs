using apidc.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace apidc.Persistence
{
    public class AutorRepository
    {
        private readonly string _connectionString;

        public AutorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Autor> ObtenerAutor()
        {
            var Autors = new List<Autor>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_ObtenerAutor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Autors.Add(new Autor
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : string.Empty
                            });
                        }
                    }
                }
            }

            return Autors;
        }

        public void InsertarAutor(Autor Autor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_InsertarAutor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", Autor.Name);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarAutor(Autor Autor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_ActualizarAutor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", Autor.Id);
                    command.Parameters.AddWithValue("@Nombre", Autor.Name);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarAutor(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_EliminarAutor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
