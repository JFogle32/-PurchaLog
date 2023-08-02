// MyCloset/Repositories/ClothesRepository.cs

using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyCloset.Models;
using MyCloset.Utils;
using MyCLOSET.Models;
using MYCLOSET.Utils;

namespace MyCloset.Repositories
{
    public class ClothesRepository : IClothesRepository
    {
        private readonly string _connectionString;

        public ClothesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private SqlConnection Connection => new SqlConnection(_connectionString);

        public List<Clothes> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Name, Size, Status, Image, Material, Notes, UserId
                        FROM Clothes";

                    var reader = cmd.ExecuteReader();

                    var clothesList = new List<Clothes>();
                    while (reader.Read())
                    {
                        clothesList.Add(new Clothes()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Size = DbUtils.GetString(reader, "Size"),
                            Status = DbUtils.GetBool(reader, "Status"),
                            Image = DbUtils.GetString(reader, "Image"),
                            Material = DbUtils.GetString(reader, "Material"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            UserId = DbUtils.GetInt(reader, "UserId")
                        });
                    }

                    reader.Close();

                    return clothesList;
                }
            }
        }

        public Clothes GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Name, Size, Status, Image, Material, Notes, UserId
                        FROM Clothes
                        WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    Clothes clothesItem = null;
                    if (reader.Read())
                    {
                        clothesItem = new Clothes()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Size = DbUtils.GetString(reader, "Size"),
                            Status = DbUtils.GetBool(reader, "Status"),
                            Image = DbUtils.GetString(reader, "Image"),
                            Material = DbUtils.GetString(reader, "Material"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            UserId = DbUtils.GetInt(reader, "UserId")
                        };
                    }

                    reader.Close();

                    return clothesItem;
                }
            }
            // In MyCloset/Repositories/ClothesRepository.cs

            public void Add(Clothes clothesItem)
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO Clothes (Name, Size, Status, Image, Material, Notes, UserId) 
                                OUTPUT INSERTED.ID 
                                VALUES (@Name, @Size, @Status, @Image, @Material, @Notes, @UserId)";
                        DbUtils.AddParameter(cmd, "@Name", clothesItem.Name);
                        DbUtils.AddParameter(cmd, "@Size", clothesItem.Size);
                        DbUtils.AddParameter(cmd, "@Status", clothesItem.Status);
                        DbUtils.AddParameter(cmd, "@Image", clothesItem.Image);
                        DbUtils.AddParameter(cmd, "@Material", clothesItem.Material);
                        DbUtils.AddParameter(cmd, "@Notes", clothesItem.Notes);
                        DbUtils.AddParameter(cmd, "@UserId", clothesItem.UserId);

                        clothesItem.Id = (int)cmd.ExecuteScalar();
                    }
                }
            }

            public void Update(Clothes clothesItem)
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Clothes 
                                SET Name = @Name, Size = @Size, Status = @Status, Image = @Image, Material = @Material, Notes = @Notes, UserId = @UserId
                                WHERE Id = @Id";
                        DbUtils.AddParameter(cmd, "@Id", clothesItem.Id);
                        DbUtils.AddParameter(cmd, "@Name", clothesItem.Name);
                        DbUtils.AddParameter(cmd, "@Size", clothesItem.Size);
                        DbUtils.AddParameter(cmd, "@Status", clothesItem.Status);
                        DbUtils.AddParameter(cmd, "@Image", clothesItem.Image);
                        DbUtils.AddParameter(cmd, "@Material", clothesItem.Material);
                        DbUtils.AddParameter(cmd, "@Notes", clothesItem.Notes);
                        DbUtils.AddParameter(cmd, "@UserId", clothesItem.UserId);

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
                        cmd.CommandText = "DELETE FROM Clothes WHERE Id = @Id";
                        DbUtils.AddParameter(cmd, "@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
