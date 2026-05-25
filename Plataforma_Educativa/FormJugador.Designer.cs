namespace Plataforma_Educativa
{
    partial class FormJugador
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbModulo;
        private System.Windows.Forms.Label lblIdioma;
        private System.Windows.Forms.ComboBox cmbIdioma;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.GroupBox gbPregunta;
        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.RadioButton radioOpc1;
        private System.Windows.Forms.RadioButton radioOpc2;
        private System.Windows.Forms.RadioButton radioOpc3;
        private System.Windows.Forms.RadioButton radioOpc4;
        private System.Windows.Forms.Label lblPuntuacion;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbModulo = new System.Windows.Forms.ComboBox();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.cmbIdioma = new System.Windows.Forms.ComboBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.gbPregunta = new System.Windows.Forms.GroupBox();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.radioOpc1 = new System.Windows.Forms.RadioButton();
            this.radioOpc2 = new System.Windows.Forms.RadioButton();
            this.radioOpc3 = new System.Windows.Forms.RadioButton();
            this.radioOpc4 = new System.Windows.Forms.RadioButton();
            this.lblPuntuacion = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gbPregunta.SuspendLayout();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Text = "Módulo:";

            // cmbModulo
            this.cmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModulo.Location = new System.Drawing.Point(80, 17);
            this.cmbModulo.Size = new System.Drawing.Size(200, 23);

            // lblIdioma
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Location = new System.Drawing.Point(300, 20);
            this.lblIdioma.Text = "Idioma:";

            // cmbIdioma
            this.cmbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdioma.Location = new System.Drawing.Point(360, 17);
            this.cmbIdioma.Size = new System.Drawing.Size(100, 23);

            // btnIniciar
            this.btnIniciar.Location = new System.Drawing.Point(480, 15);
            this.btnIniciar.Size = new System.Drawing.Size(100, 30);
            this.btnIniciar.Text = "Iniciar juego";
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);

            // gbPregunta
            this.gbPregunta.Controls.Add(this.lblPregunta);
            this.gbPregunta.Controls.Add(this.radioOpc1);
            this.gbPregunta.Controls.Add(this.radioOpc2);
            this.gbPregunta.Controls.Add(this.radioOpc3);
            this.gbPregunta.Controls.Add(this.radioOpc4);
            this.gbPregunta.Controls.Add(this.lblPuntuacion);
            this.gbPregunta.Controls.Add(this.btnSiguiente);
            this.gbPregunta.Location = new System.Drawing.Point(20, 60);
            this.gbPregunta.Size = new System.Drawing.Size(560, 250);
            this.gbPregunta.Text = "Pregunta";
            this.gbPregunta.Visible = false;

            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            this.lblPregunta.Location = new System.Drawing.Point(10, 20);

            this.radioOpc1.AutoSize = true;
            this.radioOpc1.Location = new System.Drawing.Point(10, 50);
            this.radioOpc2.AutoSize = true;
            this.radioOpc2.Location = new System.Drawing.Point(10, 80);
            this.radioOpc3.AutoSize = true;
            this.radioOpc3.Location = new System.Drawing.Point(10, 110);
            this.radioOpc4.AutoSize = true;
            this.radioOpc4.Location = new System.Drawing.Point(10, 140);

            this.lblPuntuacion.AutoSize = true;
            this.lblPuntuacion.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.lblPuntuacion.Location = new System.Drawing.Point(10, 180);
            this.lblPuntuacion.Text = "Puntuación: 0";

            this.btnSiguiente.Location = new System.Drawing.Point(200, 200);
            this.btnSiguiente.Size = new System.Drawing.Size(100, 30);
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);

            // btnSalir
            this.btnSalir.Location = new System.Drawing.Point(20, 320);
            this.btnSalir.Size = new System.Drawing.Size(120, 30);
            this.btnSalir.Text = "Cerrar sesión";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // FormJugador
            this.ClientSize = new System.Drawing.Size(610, 370);
            this.Text = "Jugador - Juego de Preguntas";
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbModulo);
            this.Controls.Add(this.lblIdioma);
            this.Controls.Add(this.cmbIdioma);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.gbPregunta);
            this.Controls.Add(this.btnSalir);
            this.gbPregunta.ResumeLayout(false);
            this.gbPregunta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}