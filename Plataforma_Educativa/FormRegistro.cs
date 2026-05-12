using MySql.Data.MySqlClient;
using Plataforma_Educativa;
using System;
using System.Windows.Forms;

namespace Plataforma_Educativa
{
    public partial class FormRegistro : Form
    {
        ConexionBD conexion = new ConexionBD();

        public FormRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object? sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string pass = txtPassword.Text.Trim();
            string? rol = comboBoxRol.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(rol))
            {
                MessageBox.Show("Llene todos los campos.");
                return;
            }

            if (RegistrarUsuario(usuario, pass, rol))
            {
                MessageBox.Show("Usuario registrado exitosamente.");
                this.Close();
            }
        }

        private bool RegistrarUsuario(string usuario, string pass, string rol)
        {
            string query = "INSERT INTO usuarios (nombre, contraseña, rol) VALUES (@usuario, @pass, @rol)";
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Parameters.AddWithValue("@rol", rol);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062) // Duplicado
                        MessageBox.Show("El nombre de usuario ya existe.");
                    else
                        MessageBox.Show("Error al registrar: " + ex.Message);
                    return false;
                }
            }
        }

        private void btnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}