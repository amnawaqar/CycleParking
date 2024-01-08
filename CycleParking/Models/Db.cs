
using System.Collections.Generic;
using System.Data.SqlClient;


namespace CycleParking.Models
{
    public class DbService : IDbService
    {
        private readonly string _connectionString;
        public DbService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public CycleParkingService GetCycleParkingDetails(int id)
        {
            CycleParkingService parking = new CycleParkingService();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM CyclePark WHERE Id=" + id, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            parking = new CycleParkingService
                            {
                                Id = (int)reader["Id"],
                                Title = reader["Title"].ToString(),
                                Location = reader["Location"].ToString(),
                                Type = reader["Type"].ToString(),
                                Secure = reader["Secure"].ToString(),
                                Capacity = (int)reader["Capacity"],
                                Availability = reader["Availability"].ToString(),
                                Longitude = reader["Longitude"].ToString(),
                                Latitude = reader["Latitude"].ToString()
                            };
                        }
                    }
                }
            }

            return parking;
        }
        public List<CycleParkingService> GetCycleParkings()
        {
            List<CycleParkingService> cycleParkings = new List<CycleParkingService>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM CyclePark", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CycleParkingService parking = new CycleParkingService
                            {
                                Id = (int)reader["Id"],
                                Title = reader["Title"].ToString(),
                                Location = reader["Location"].ToString(),
                                Type = reader["Type"].ToString(),
                            };

                            cycleParkings.Add(parking);
                        }
                    }
                }
            }

            return cycleParkings;
        }
    }
}

