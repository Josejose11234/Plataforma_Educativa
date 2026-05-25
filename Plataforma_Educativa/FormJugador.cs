using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Plataforma_Educativa
{
    public partial class FormJugador : Form
    {
        ConexionBD conexion = new ConexionBD();
        private int preguntaActual = 0, aciertos = 0, puntuacion = 0;
        private DataTable? preguntas;

        public FormJugador()
        {
            InitializeComponent();
            CargarModulos();
            // Llenar ComboBox de idiomas
            cmbIdioma.Items.Add("español");
            cmbIdioma.Items.Add("inglés");
            cmbIdioma.SelectedIndex = 0; // español por defecto
        }

        private void CargarModulos()
        {
            DataTable dt = new DataTable();
            using (var conn = conexion.ObtenerConexion())
            {
                string query = "SELECT id, nombre FROM modulos ORDER BY id";
                using (var adapter = new MySqlDataAdapter(query, conn))
                    adapter.Fill(dt);
            }
            cmbModulo.DataSource = dt;
            cmbModulo.DisplayMember = "nombre";
            cmbModulo.ValueMember = "id";
        }

        private void btnIniciar_Click(object? sender, EventArgs e)
        {
            if (cmbModulo.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un módulo.");
                return;
            }
            if (cmbIdioma.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un idioma.");
                return;
            }

            int idModulo = (int)cmbModulo.SelectedValue;
            string idioma = cmbIdioma.SelectedItem.ToString()!;

            preguntas = new DataTable();
            using (var conn = conexion.ObtenerConexion())
            {
                // Cargar preguntas SOLO del idioma seleccionado
                string query = $"SELECT id, enunciado FROM preguntas WHERE modulo_id = {idModulo} AND idioma = '{idioma}' ORDER BY id";
                using (var adapter = new MySqlDataAdapter(query, conn))
                    adapter.Fill(preguntas);
            }

            if (preguntas.Rows.Count == 0)
            {
                MessageBox.Show($"No hay preguntas en {idioma} para este módulo.");
                return;
            }

            preguntaActual = 0;
            aciertos = 0;
            puntuacion = 0;
            lblPuntuacion.Text = "Puntuación: 0";
            gbPregunta.Visible = true;
            MostrarPregunta();
        }

        private void MostrarPregunta()
        {
            if (preguntas == null || preguntaActual >= preguntas.Rows.Count)
            {
                FinalizarJuego();
                return;
            }

            DataRow row = preguntas.Rows[preguntaActual];
            lblPregunta.Text = $"{preguntaActual + 1}. {row["enunciado"]}";

            DataTable opciones = new DataTable();
            using (var conn = conexion.ObtenerConexion())
            {
                // Cargar opciones SOLO de la pregunta actual
                string query = $"SELECT id, texto, es_correcta FROM opciones WHERE pregunta_id = {row["id"]} ORDER BY id";
                using (var adapter = new MySqlDataAdapter(query, conn))
                    adapter.Fill(opciones);
            }

            RadioButton[] radios = { radioOpc1, radioOpc2, radioOpc3, radioOpc4 };
            for (int i = 0; i < 4; i++)
            {
                if (i < opciones.Rows.Count)
                {
                    radios[i].Text = opciones.Rows[i]["texto"].ToString()!;
                    radios[i].Tag = opciones.Rows[i]["id"];
                    radios[i].Checked = false;
                    radios[i].Visible = true;
                }
                else
                {
                    radios[i].Text = "";
                    radios[i].Tag = null;
                    radios[i].Checked = false;
                    radios[i].Visible = false;
                }
            }
        }

        private void btnSiguiente_Click(object? sender, EventArgs e)
        {
            RadioButton[] radios = { radioOpc1, radioOpc2, radioOpc3, radioOpc4 };
            RadioButton? seleccionada = null;
            foreach (var rb in radios)
                if (rb.Checked && rb.Visible) { seleccionada = rb; break; }

            if (seleccionada == null)
            {
                MessageBox.Show("Selecciona una respuesta.");
                return;
            }

            int idOpcion = (int)seleccionada.Tag!;
            bool esCorrecta = false;
            using (var conn = conexion.ObtenerConexion())
            {
                var cmd = new MySqlCommand($"SELECT es_correcta FROM opciones WHERE id = {idOpcion}", conn);
                conn.Open();
                object? result = cmd.ExecuteScalar();
                if (result != null && Convert.ToInt32(result) == 1)
                    esCorrecta = true;
            }

            if (esCorrecta)
            {
                aciertos++;
                puntuacion += 10;
            }
            else
            {
                puntuacion -= 5;
                if (puntuacion < 0) puntuacion = 0;
            }
            lblPuntuacion.Text = $"Puntuación: {puntuacion}";

            preguntaActual++;
            if (preguntas != null && preguntaActual < preguntas.Rows.Count)
                MostrarPregunta();
            else
                FinalizarJuego();
        }

        private void FinalizarJuego()
        {
            gbPregunta.Visible = false;
            MessageBox.Show($"Juego terminado.\nAcertaste {aciertos} de {preguntas?.Rows.Count ?? 0} preguntas.\nPuntuación final: {puntuacion}");
        }

        private void btnSalir_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}