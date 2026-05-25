using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Plataforma_Educativa
{
    public partial class FormAdministrador : Form
    {
        ConexionBD conexion = new ConexionBD();

        public FormAdministrador()
        {
            InitializeComponent();
            CargarModulos();
        }

        // ==================== USUARIOS (sin cambios) ====================
        private void btnCargar_Click(object? sender, EventArgs e) => CargarUsuarios();

        private void dgvUsuarios_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                btnEliminar.Enabled = cmbRol.Enabled = btnActualizarRol.Enabled = false;
                return;
            }
            var fila = dgvUsuarios.SelectedRows[0];
            var celdaRol = fila.Cells["rol"];
            if (celdaRol?.Value != null)
                cmbRol.SelectedItem = celdaRol.Value.ToString();
            btnEliminar.Enabled = cmbRol.Enabled = btnActualizarRol.Enabled = true;
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0) return;
            var f = dgvUsuarios.SelectedRows[0];
            var idObj = f.Cells["id"].Value;
            if (idObj == null || !int.TryParse(idObj.ToString(), out int id))
            {
                MessageBox.Show("Id de usuario inválido.");
                return;
            }
            string nom = f.Cells["nombre"].Value?.ToString() ?? "?";
            if (MessageBox.Show($"¿Eliminar al usuario '{nom}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (EliminarUsuario(id))
                {
                    MessageBox.Show("Usuario eliminado.");
                    CargarUsuarios();
                }
            }
        }

        private void btnActualizarRol_Click(object? sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0 || cmbRol.SelectedItem == null) return;
            var f = dgvUsuarios.SelectedRows[0];
            var idObj = f.Cells["id"].Value;
            if (idObj == null || !int.TryParse(idObj.ToString(), out int id))
            {
                MessageBox.Show("Id de usuario inválido.");
                return;
            }
            string rol = cmbRol.SelectedItem.ToString()!;
            if (ActualizarRol(id, rol))
            {
                MessageBox.Show("Rol actualizado.");
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            DataTable dt = new DataTable();
            using (var conn = conexion.ObtenerConexion())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT id, nombre, contraseña, rol FROM usuarios ORDER BY id", conn);
                try
                {
                    conn.Open();
                    new MySqlDataAdapter(cmd).Fill(dt);
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); return; }
            }
            dgvUsuarios.DataSource = dt;
            btnEliminar.Enabled = cmbRol.Enabled = btnActualizarRol.Enabled = false;
        }

        private bool EliminarUsuario(int id)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("DELETE FROM usuarios WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                try { conn.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
            }
        }

        private bool ActualizarRol(int id, string rol)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("UPDATE usuarios SET rol=@rol WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@rol", rol);
                cmd.Parameters.AddWithValue("@id", id);
                try { conn.Open(); return cmd.ExecuteNonQuery() > 0; }
                catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
            }
        }

        // ==================== CONTENIDO ====================
        private void CargarModulos()
        {
            DataTable dt = new DataTable();
            using (var conn = conexion.ObtenerConexion())
            {
                new MySqlDataAdapter("SELECT id, nombre FROM modulos ORDER BY id", conn).Fill(dt);
            }
            dgvModulos.DataSource = dt;

            DataTable dtCombo = dt.Copy();
            cmbModuloPregunta.DataSource = dtCombo;
            cmbModuloPregunta.DisplayMember = "nombre";
            cmbModuloPregunta.ValueMember = "id";
        }

        private void cmbModuloPregunta_SelectedIndexChanged(object? sender, EventArgs e) => CargarPreguntas();

        private void CargarPreguntas()
        {
            if (cmbModuloPregunta.SelectedValue == null)
            {
                dgvPreguntas.DataSource = null;
                return;
            }
            if (!int.TryParse(cmbModuloPregunta.SelectedValue.ToString(), out int idMod))
            {
                dgvPreguntas.DataSource = null;
                return;
            }
            DataTable dt = new DataTable();
            using (var conn = conexion.ObtenerConexion())
            {
                new MySqlDataAdapter($"SELECT id, enunciado, idioma FROM preguntas WHERE modulo_id={idMod} ORDER BY id", conn).Fill(dt);
            }
            dgvPreguntas.DataSource = dt;
        }

        private void dgvPreguntas_SelectionChanged(object? sender, EventArgs e) => CargarOpciones();

        private void CargarOpciones()
        {
            if (dgvPreguntas.SelectedRows.Count == 0)
            {
                dgvOpciones.DataSource = null;
                return;
            }
            var row = dgvPreguntas.SelectedRows[0];
            var idObj = row.Cells["id"].Value;
            if (idObj == null || !int.TryParse(idObj.ToString(), out int idPreg))
            {
                dgvOpciones.DataSource = null;
                return;
            }

            // Mostrar el idioma de la pregunta seleccionada
            string idiomaPregunta = row.Cells["idioma"].Value?.ToString() ?? "español";
            gbOpciones.Text = $"Opciones de la pregunta seleccionada (Idioma: {idiomaPregunta})";

            DataTable dt = new DataTable();
            using (var conn = conexion.ObtenerConexion())
            {
                new MySqlDataAdapter($"SELECT id, texto, idioma, es_correcta FROM opciones WHERE pregunta_id={idPreg} ORDER BY id", conn).Fill(dt);
            }
            dgvOpciones.DataSource = dt;
        }

        // ==================== EVENTOS DE MÓDULOS ====================
        private void btnAgregarModulo_Click(object? sender, EventArgs e) => FormularioModulo("Agregar módulo");

        private void btnEditarModulo_Click(object? sender, EventArgs e)
        {
            if (dgvModulos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un módulo para editar.");
                return;
            }
            var row = dgvModulos.SelectedRows[0];
            string nombre = row.Cells["nombre"].Value?.ToString() ?? "";
            FormularioModulo("Editar módulo", nombre);
        }

        private void btnEliminarModulo_Click(object? sender, EventArgs e)
        {
            if (dgvModulos.SelectedRows.Count == 0) return;
            var idObj = dgvModulos.SelectedRows[0].Cells["id"].Value;
            if (idObj == null || !int.TryParse(idObj.ToString(), out int id))
            {
                MessageBox.Show("Id de módulo inválido.");
                return;
            }
            if (MessageBox.Show("¿Eliminar el módulo y todas sus preguntas?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                EliminarModulo(id);
                CargarModulos();
                CargarPreguntas();
            }
        }

        // ==================== EVENTOS DE PREGUNTAS ====================
        private void btnAgregarPregunta_Click(object? sender, EventArgs e) => FormularioPregunta("Agregar pregunta");

        private void btnEditarPregunta_Click(object? sender, EventArgs e)
        {
            if (dgvPreguntas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una pregunta para editar.");
                return;
            }
            var row = dgvPreguntas.SelectedRows[0];
            string enunciado = row.Cells["enunciado"].Value?.ToString() ?? "";
            string idioma = row.Cells["idioma"].Value?.ToString() ?? "español";
            FormularioPregunta("Editar pregunta", enunciado, idioma);
        }

        private void btnEliminarPregunta_Click(object? sender, EventArgs e)
        {
            if (dgvPreguntas.SelectedRows.Count == 0) return;
            var idObj = dgvPreguntas.SelectedRows[0].Cells["id"].Value;
            if (idObj == null || !int.TryParse(idObj.ToString(), out int id))
            {
                MessageBox.Show("Id de pregunta inválido.");
                return;
            }
            if (MessageBox.Show("¿Eliminar la pregunta y todas sus opciones?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                EliminarPregunta(id);
                CargarPreguntas();
            }
        }

        // ==================== EVENTOS DE OPCIONES ====================
        private void btnAgregarOpcion_Click(object? sender, EventArgs e) => FormularioOpcion("Agregar opción");

        private void btnEliminarOpcion_Click(object? sender, EventArgs e)
        {
            if (dgvOpciones.SelectedRows.Count == 0) return;
            var idObj = dgvOpciones.SelectedRows[0].Cells["id"].Value;
            if (idObj == null || !int.TryParse(idObj.ToString(), out int id))
            {
                MessageBox.Show("Id de opción inválido.");
                return;
            }
            if (MessageBox.Show("¿Eliminar esta opción?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                EliminarOpcion(id);
                CargarOpciones();
            }
        }

        // ==================== FORMULARIOS MODALES ====================
        private void FormularioModulo(string titulo, string nombre = "")
        {
            Form f = new Form
            {
                Text = titulo,
                Width = 350,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblNombre = new Label { Text = "Nombre:", Location = new Point(20, 20), AutoSize = true };
            TextBox txtNombre = new TextBox { Location = new Point(100, 17), Width = 200, Text = nombre };

            Button btnGuardar = new Button { Text = "Guardar", Location = new Point(100, 60), Size = new Size(100, 30) };
            Button btnCancelar = new Button { Text = "Cancelar", Location = new Point(210, 60), Size = new Size(100, 30) };

            btnGuardar.Click += (s, e) =>
            {
                string n = txtNombre.Text.Trim();
                if (string.IsNullOrEmpty(n))
                {
                    MessageBox.Show("El nombre del módulo es obligatorio.");
                    return;
                }
                if (titulo == "Agregar módulo")
                    InsertarModulo(n);
                else
                {
                    if (dgvModulos.SelectedRows.Count == 0) return;
                    var idObj = dgvModulos.SelectedRows[0].Cells["id"].Value;
                    if (idObj == null || !int.TryParse(idObj.ToString(), out int id))
                    {
                        MessageBox.Show("Id de módulo inválido.");
                        return;
                    }
                    ActualizarModulo(id, n);
                }
                CargarModulos();
                f.Close();
            };
            btnCancelar.Click += (s, e) => f.Close();

            f.Controls.AddRange(new Control[] { lblNombre, txtNombre, btnGuardar, btnCancelar });
            f.ShowDialog();
        }

        private void FormularioPregunta(string titulo, string enunciado = "", string idiomaActual = "español")
        {
            if (cmbModuloPregunta.SelectedValue == null)
            {
                MessageBox.Show("Primero seleccione un módulo en la lista de preguntas.");
                return;
            }

            Form f = new Form
            {
                Text = titulo,
                Width = 520,
                Height = 240,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblEnun = new Label { Text = "Enunciado:", Location = new Point(20, 20), AutoSize = true };
            TextBox txtEnun = new TextBox { Location = new Point(20, 45), Width = 460, Height = 60, Multiline = true, Text = enunciado };

            Label lblIdioma = new Label { Text = "Idioma:", Location = new Point(20, 115), AutoSize = true };
            ComboBox cmbIdioma = new ComboBox
            {
                Location = new Point(80, 112),
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbIdioma.Items.Add("español");
            cmbIdioma.Items.Add("inglés");
            cmbIdioma.SelectedItem = idiomaActual;

            Button btnGuardar = new Button { Text = "Guardar", Location = new Point(150, 150), Size = new Size(100, 30) };
            Button btnCancelar = new Button { Text = "Cancelar", Location = new Point(260, 150), Size = new Size(100, 30) };

            btnGuardar.Click += (s, e) =>
            {
                string enun = txtEnun.Text.Trim();
                if (string.IsNullOrEmpty(enun))
                {
                    MessageBox.Show("El enunciado no puede estar vacío.");
                    return;
                }
                string idioma = cmbIdioma.SelectedItem?.ToString() ?? "español";
                if (!int.TryParse(cmbModuloPregunta.SelectedValue?.ToString(), out int idModulo))
                {
                    MessageBox.Show("Módulo inválido.");
                    return;
                }
                if (titulo == "Agregar pregunta")
                    InsertarPregunta(idModulo, enun, idioma);
                else
                {
                    if (dgvPreguntas.SelectedRows.Count == 0) return;
                    var idObj = dgvPreguntas.SelectedRows[0].Cells["id"].Value;
                    if (idObj == null || !int.TryParse(idObj.ToString(), out int idPreg))
                    {
                        MessageBox.Show("Id de pregunta inválido.");
                        return;
                    }
                    ActualizarPregunta(idPreg, enun, idioma);
                }
                CargarPreguntas();
                f.Close();
            };
            btnCancelar.Click += (s, e) => f.Close();

            f.Controls.AddRange(new Control[] { lblEnun, txtEnun, lblIdioma, cmbIdioma, btnGuardar, btnCancelar });
            f.ShowDialog();
        }

        private void FormularioOpcion(string titulo, string texto = "")
        {
            if (dgvPreguntas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una pregunta para añadirle opciones.");
                return;
            }

            // Obtener el idioma de la pregunta seleccionada
            string idiomaPregunta = dgvPreguntas.SelectedRows[0].Cells["idioma"].Value?.ToString() ?? "español";

            Form f = new Form
            {
                Text = titulo + $" (Idioma: {idiomaPregunta})",
                Width = 450,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblTexto = new Label { Text = "Texto de la opción:", Location = new Point(20, 20), AutoSize = true };
            TextBox txtOpcion = new TextBox { Location = new Point(20, 45), Width = 400, Text = texto };

            CheckBox chkCorr = new CheckBox { Text = "Es la respuesta correcta", Location = new Point(20, 80), AutoSize = true };

            Button btnGuardar = new Button { Text = "Guardar", Location = new Point(120, 115), Size = new Size(100, 30) };
            Button btnCancelar = new Button { Text = "Cancelar", Location = new Point(230, 115), Size = new Size(100, 30) };

            btnGuardar.Click += (s, e) =>
            {
                string opc = txtOpcion.Text.Trim();
                if (string.IsNullOrEmpty(opc))
                {
                    MessageBox.Show("El texto de la opción no puede estar vacío.");
                    return;
                }
                if (dgvPreguntas.SelectedRows.Count == 0) return;
                var idObj = dgvPreguntas.SelectedRows[0].Cells["id"].Value;
                if (idObj == null || !int.TryParse(idObj.ToString(), out int idPregunta))
                {
                    MessageBox.Show("Id de pregunta inválido.");
                    return;
                }
                // Insertar opción con el mismo idioma de la pregunta
                InsertarOpcion(idPregunta, opc, chkCorr.Checked, idiomaPregunta);
                CargarOpciones();
                f.Close();
            };
            btnCancelar.Click += (s, e) => f.Close();

            f.Controls.AddRange(new Control[] { lblTexto, txtOpcion, chkCorr, btnGuardar, btnCancelar });
            f.ShowDialog();
        }

        // ==================== OPERACIONES SQL ====================
        private void InsertarModulo(string nombre)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("INSERT INTO modulos (nombre, descripcion) VALUES (@n, '')", conn);
                cmd.Parameters.AddWithValue("@n", nombre);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarModulo(int id, string nombre)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("UPDATE modulos SET nombre=@n WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void EliminarModulo(int id)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("DELETE FROM modulos WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void InsertarPregunta(int moduloId, string enunciado, string idioma)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("INSERT INTO preguntas (modulo_id, enunciado, idioma) VALUES (@m, @e, @i)", conn);
                cmd.Parameters.AddWithValue("@m", moduloId);
                cmd.Parameters.AddWithValue("@e", enunciado);
                cmd.Parameters.AddWithValue("@i", idioma);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void ActualizarPregunta(int id, string enunciado, string idioma)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("UPDATE preguntas SET enunciado=@e, idioma=@i WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@e", enunciado);
                cmd.Parameters.AddWithValue("@i", idioma);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void EliminarPregunta(int id)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("DELETE FROM preguntas WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Insertar opción con idioma
        private void InsertarOpcion(int preguntaId, string texto, bool esCorrecta, string idioma)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("INSERT INTO opciones (pregunta_id, texto, idioma, es_correcta) VALUES (@p, @t, @i, @c)", conn);
                cmd.Parameters.AddWithValue("@p", preguntaId);
                cmd.Parameters.AddWithValue("@t", texto);
                cmd.Parameters.AddWithValue("@i", idioma);
                cmd.Parameters.AddWithValue("@c", esCorrecta ? 1 : 0);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void EliminarOpcion(int id)
        {
            using (var conn = conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand("DELETE FROM opciones WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnCerrarSesion_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}