using MySql.Data.MySqlClient;
using Plataforma_Educativa;
using System;
using System.Windows.Forms;

namespace Plataforma_Educativa
{
    public partial class FormLogin : Form
    {
        ConexionBD conexion = new ConexionBD();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            string? rol = AutenticarUsuario(usuario, pass);

            if (rol != null)
            {
                this.Hide();

                if (rol == "administrador")
                {
                    FormAdministrador frmAdmin = new FormAdministrador();
                    frmAdmin.FormClosed += (s, args) => this.Show();
                    frmAdmin.Show();
                }
                else if (rol == "jugador")
                {
                    FormJugador frmJugador = new FormJugador();
                    frmJugador.FormClosed += (s, args) => this.Show();
                    frmJugador.Show();
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private string? AutenticarUsuario(string usuario, string pass)
        {
            string? rol = null;
            string query = "SELECT rol FROM usuarios WHERE nombre = @usuario AND contraseña = @pass";

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@pass", pass);

                try
                {
                    conn.Open();
                    object? resultado = cmd.ExecuteScalar();
                    if (resultado != null)
                        rol = resultado.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la BD: " + ex.Message);
                }
            }
            return rol;
        }

        private void btnRegistrar_Click(object? sender, EventArgs e)
        {
            FormRegistro frmRegistro = new FormRegistro();
            frmRegistro.ShowDialog();
        }
    }
}