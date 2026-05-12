using MySql.Data.MySqlClient;
using Plataforma_Educativa;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Plataforma_Educativa
{
    public partial class FormAdministrador : Form
    {
        ConexionBD conexion = new ConexionBD();
        private DataGridView dgvUsuarios;
        private Button btnCargar;
        private Button btnEliminar;

        public FormAdministrador()
        {
            InitializeComponent();
            this.Text = "Panel de Administrador";
            this.Size = new Size(650, 450);

            // Etiqueta de bienvenida
            Label lblBienvenido = new Label
            {
                Text = "Bienvenido Administrador!",
                AutoSize = true,
                Location = new Point(20, 20),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblBienvenido);

            // Botón: Cargar usuarios
            btnCargar = new Button
            {
                Text = "Cargar usuarios",
                Location = new Point(20, 60),
                Size = new Size(120, 30)
            };
            btnCargar.Click += BtnCargar_Click;
            this.Controls.Add(btnCargar);

            // Botón: Eliminar usuario seleccionado
            btnEliminar = new Button
            {
                Text = "Eliminar usuario",
                Location = new Point(150, 60),
                Size = new Size(120, 30)
            };
            btnEliminar.Click += BtnEliminar_Click;
            this.Controls.Add(btnEliminar);

            // DataGridView para mostrar usuarios
            dgvUsuarios = new DataGridView
            {
                Location = new Point(20, 110),
                Size = new Size(600, 250),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };
            this.Controls.Add(dgvUsuarios);

            // Botón: Cerrar sesión (vuelve al login)
            Button btnSalir = new Button
            {
                Text = "Cerrar sesión",
                Location = new Point(20, 370),
                Size = new Size(120, 30)
            };
            btnSalir.Click += (sender, e) => { this.Close(); };
            this.Controls.Add(btnSalir);
        }

        // Evento del botón "Cargar usuarios"
        private void BtnCargar_Click(object? sender, EventArgs e)
        {
            CargarUsuarios();
        }

        // Evento del botón "Eliminar usuario"
        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario de la tabla para eliminar.");
                return;
            }

            // Obtener datos de la fila seleccionada
            var selectedRow = dgvUsuarios.SelectedRows[0];
            object idValue = selectedRow.Cells["id"].Value ?? 0;
            int id = Convert.ToInt32(idValue);
            string nombre = selectedRow.Cells["nombre"].Value?.ToString() ?? string.Empty;

            // Confirmación
            DialogResult resultado = MessageBox.Show(
                $"¿Está seguro de eliminar al usuario '{nombre}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.Yes)
            {
                if (EliminarUsuario(id))
                {
                    MessageBox.Show("Usuario eliminado correctamente.");
                    CargarUsuarios(); // Refrescar tabla
                }
            }
        }

        // Método que carga los usuarios desde la base de datos
        private void CargarUsuarios()
        {
            string query = "SELECT id, nombre, rol FROM usuarios ORDER BY id";
            DataTable tabla = new DataTable();

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(tabla);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar usuarios: " + ex.Message);
                    return;
                }
            }
            dgvUsuarios.DataSource = tabla;
        }

        // Método que elimina un usuario por ID
        private bool EliminarUsuario(int id)
        {
            string query = "DELETE FROM usuarios WHERE id = @id";
            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar usuario: " + ex.Message);
                    return false;
                }
            }
        }
    }
}