// MyCloset/Repositories/GadgetRepository.cs

using System.Collections.Generic;
using System.Data.SqlClient;
using MyCloset.Models;
using MyCloset.Utils;
using MYCLOSET.Utils;

namespace MyCloset.Repositories
{
    public class GadgetRepository : IGadgetRepository
    {
        private readonly string _connectionString;

        public GadgetRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Gadget> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name, Status, Image, Notes, UserId FROM Gadgets";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Gadget> gadgets = new List<Gadget>();

                    while (reader.Read())
                    {
                        gadgets.Add(new Gadget()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Status = DbUtils.GetInt(reader, "Status") == 1,
                            Image = DbUtils.GetString(reader, "Image"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            UserId = DbUtils.GetInt(reader, "UserId")
                        });
                    }

                    reader.Close();

                    return gadgets;
                }
            }
        }

        public Gadget GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name, Status, Image, Notes, UserId FROM Gadgets WHERE Id = @id";
                    DbUtils.AddParameter(cmd, "@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    Gadget gadget = null;

                    if (reader.Read())
                    {
                        gadget = new Gadget()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Status = DbUtils.GetInt(reader, "Status") == 1,
                            Image = DbUtils.GetString(reader, "Image"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            UserId = DbUtils.GetInt(reader, "UserId")
                        };
                    }

                    reader.Close();

                    return gadget;
                }
            }
        }

        public void Add(Gadget gadget)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Gadgets (Name, Status, Image, Notes, UserId) 
                                        OUTPUT INSERTED.ID 
                                        VALUES (@Name, @Status, @Image, @Notes, @UserId)";

                    DbUtils.AddParameter(cmd, "@Name", gadget.Name);
                    DbUtils.AddParameter(cmd, "@Status", gadget.Status);
                    DbUtils.AddParameter(cmd, "@Image", gadget.Image);
                    DbUtils.AddParameter(cmd, "@Notes", gadget.Notes);
                    DbUtils.AddParameter(cmd, "@UserId", gadget.UserId);

                    gadget.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Gadget gadget)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Gadgets 
                                        SET Name = @Name, 
                                            Status = @Status, 
                                            Image = @Image, 
                                            Notes = @Notes, 
                                            UserId = @UserId
                                        WHERE Id = @id";

                    DbUtils.AddParameter(cmd, "@Name", gadget.Name);
                    DbUtils.AddParameter(cmd, "@Status", gadget.Status);
                    DbUtils.AddParameter(cmd, "@Image", gadget.Image);
                    DbUtils.AddParameter(cmd, "@Notes", gadget.Notes);
                    DbUtils.AddParameter(cmd, "@UserId", gadget.UserId);
                    DbUtils.AddParameter(cmd, "@id", gadget.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Gadgets WHERE Id = @id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
