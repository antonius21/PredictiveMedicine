using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PredictiveMedicine
{
    internal class DB
    {
        public string ConnectionString { get; set; } // Your connection string here
                                                     //Add methods to interact with database (GetPatientData, etc)
        public DataTable GetPatientData()
        {
            /*
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Patients", connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            */
            return null;
        }
    }
}
