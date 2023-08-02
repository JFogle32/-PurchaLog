using System.Collections.Generic;
using System.Data.SqlClient;
using YourNamespace.Models;
using Microsoft.Extensions.Configuration;
using MyCLOSET.Models;

namespace MyCLOSET.Repositories
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly string _connectionString;

        public ShoeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        private SqlConnection Connection => new SqlConnection(_connectionString);


        public List<Shoe> GetAll()
        {
            var shoes = new List<Shoe>();

            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name, Size, Status, Image, Notes, UserId FROM Shoes";
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        shoes.Add(new Shoe
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Size = reader.GetString(reader.GetOrdinal("Size")),
                            Status = reader.GetBoolean(reader.GetOrdinal("Status")),
                            Image = reader.GetString(reader.GetOrdinal("Image")),
                            Notes = reader.GetString(reader.GetOrdinal("Notes")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        });
                    }
                    reader.Close();
                }
            }
            return shoes;
        }

        public Shoe GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name, Size, Status, Image, Notes, UserId FROM Shoes WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    var reader = cmd.ExecuteReader();

                    Shoe shoe = null;
                    if (reader.Read())
                    {
                        shoe = new Shoe
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Size = reader.GetString(reader.GetOrdinal("Size")),
                            Status = reader.GetBoolean(reader.GetOrdinal("Status")),
                            Image = reader.GetString(reader.GetOrdinal("Image")),
                            Notes = reader.GetString(reader.GetOrdinal("Notes")),
                            UserId = reader.GetInt32(reader.GetOrdinal("UserId"))
                        };
                    }
                    reader.Close();
                    return shoe;
                }
            }
        }

        public void Add(Shoe shoe)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Shoes (Name, Size, Status, Image, Notes, UserId) 
                                        VALUES (@Name, @Size, @Status, @Image, @Notes, @UserId)";
                    cmd.Parameters.AddWithValue("@Name", shoe.Name);
                    cmd.Parameters.AddWithValue("@Size", shoe.Size);
                    cmd.Parameters.AddWithValue("@Status", shoe.Status);
                    cmd.Parameters.AddWithValue("@Image", shoe.Image);
                    cmd.Parameters.AddWithValue("@Notes", shoe.Notes);
                    cmd.Parameters.AddWithValue("@UserId", shoe.UserId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Shoe shoe)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Shoes 
                                        SET Name = @Name, 
                                            Size = @Size, 
                                            Status = @Status, 
                                            Image = @Image, 
                                            Notes = @Notes, 
                                            UserId = @UserId
                                        WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", shoe.Id);
                    cmd.Parameters.AddWithValue("@Name", shoe.Name);
                    cmd.Parameters.AddWithValue("@Size", shoe.Size);
                    cmd.Parameters.AddWithValue("@Status", shoe.Status);
                    cmd.Parameters.AddWithValue("@Image", shoe.Image);
                    cmd.Parameters.AddWithValue("@Notes", shoe.Notes);
                    cmd.Parameters.AddWithValue("@UserId", shoe.UserId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Shoes WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

