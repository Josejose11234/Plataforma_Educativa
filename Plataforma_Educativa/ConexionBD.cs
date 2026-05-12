using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Plataforma_Educativa
{
    public class ConexionBD
    {
        private string connectionString = "server=localhost;database=login_system;uid=root;pwd=;";

        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(connectionString);
        }

        public bool ProbarConexion()
        {
            try
            {
                using (MySqlConnection conn = ObtenerConexion())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
                return false;
            }
        }
    }
}