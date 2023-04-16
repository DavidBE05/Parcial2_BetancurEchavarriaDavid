using Parcial2_BetancurEchavarriaDavid.DAL.Entities;
using System.Data.SqlClient;

namespace Parcial2_BetancurEchavarriaDavid.Views
{

    public partial class Form1 : Form
        {
            private const string connectionString = "Data Source=(local);Initial Catalog=ConcertDB;Integrated Security=True";

            public Form1()
            {
                InitializeComponent();
                DatabaseManager dbManager = new DatabaseManager();
                dbManager.CreateDatabase();
            }

            private void btnValidateTicket_Click(object sender, EventArgs e)
            {
                int ticketID = int.Parse(txtTicketID.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if ticket exists
                    SqlCommand cmd = new SqlCommand("SELECT IsUsed FROM Tickets WHERE TicketID = @TicketID", connection);
                    cmd.Parameters.AddWithValue("@TicketID", ticketID);
                    bool isUsed = (bool?)cmd.ExecuteScalar() ?? false;

                    if (!isUsed)
                    {
                        // Update ticket with entrance gate and current datetime
                        cmd = new SqlCommand("UPDATE Tickets SET UseDate = @UseDate, IsUsed = 1, EntranceGate = @EntranceGate WHERE TicketID = @TicketID", connection);
                        cmd.Parameters.AddWithValue("@UseDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@EntranceGate", cbEntranceGate.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@TicketID", ticketID);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Entrada permitida", "Mensaje");
                    }
                    else
                    {
                        // Get ticket info
                        cmd = new SqlCommand("SELECT UseDate, EntranceGate FROM Tickets WHERE TicketID = @TicketID", connection);
                        cmd.Parameters.AddWithValue("@TicketID", ticketID);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            DateTime useDate = (DateTime)reader["UseDate"];
                            string entranceGate = (string)reader["EntranceGate"];
                            string message = string.Format("La boleta ya fue usada el {0} en la portería {1}", useDate, entranceGate);
                            MessageBox.Show(message, "Mensaje");
                        }
                        else
                        {
                            MessageBox.Show("Boleta no válida", "Mensaje");
                        }

                        reader.Close();
                    }

                    connection.Close();
                }
            }
        }
  

}
