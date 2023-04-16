using System.Data.SqlClient;

namespace Parcial2_BetancurEchavarriaDavid.DAL.Entities
{
    
        public class DatabaseManager
        {
            private const string connectionString = "Data Source=(local);Initial Catalog=master;Integrated Security=True";

            public void CreateDatabase()
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create database
                    SqlCommand cmd = new SqlCommand("CREATE DATABASE ConcertDB", connection);
                    cmd.ExecuteNonQuery();

                    // Create table
                    cmd = new SqlCommand("USE ConcertDB; CREATE TABLE Tickets (TicketID int PRIMARY KEY, UseDate datetime NULL, IsUsed bit DEFAULT 0, EntranceGate varchar(50) NULL)", connection);
                    cmd.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    
}
