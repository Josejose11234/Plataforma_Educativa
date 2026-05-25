namespace Plataforma_Educativa
{
    partial class FormAdministrador
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabAdmin;
        private System.Windows.Forms.TabPage tabUsuarios;
        private System.Windows.Forms.TabPage tabContenido;

        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Button btnActualizarRol;
        private System.Windows.Forms.DataGridView dgvUsuarios;

        private System.Windows.Forms.GroupBox gbModulos;
        private System.Windows.Forms.DataGridView dgvModulos;
        private System.Windows.Forms.Button btnAgregarModulo;
        private System.Windows.Forms.Button btnEditarModulo;
        private System.Windows.Forms.Button btnEliminarModulo;

        private System.Windows.Forms.GroupBox gbPreguntas;
        private System.Windows.Forms.Label lblModPregunta;
        private System.Windows.Forms.ComboBox cmbModuloPregunta;
        private System.Windows.Forms.DataGridView dgvPreguntas;
        private System.Windows.Forms.Button btnAgregarPregunta;
        private System.Windows.Forms.Button btnEditarPregunta;
        private System.Windows.Forms.Button btnEliminarPregunta;

        private System.Windows.Forms.GroupBox gbOpciones;
        private System.Windows.Forms.DataGridView dgvOpciones;
        private System.Windows.Forms.CheckBox chkCorrecta;
        private System.Windows.Forms.Button btnAgregarOpcion;
        private System.Windows.Forms.Button btnEliminarOpcion;

        private System.Windows.Forms.Button btnCerrarSesion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabAdmin = new System.Windows.Forms.TabControl();
            this.tabUsuarios = new System.Windows.Forms.TabPage();
            this.tabContenido = new System.Windows.Forms.TabPage();

            this.lblUsuarios = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.btnActualizarRol = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();

            this.gbModulos = new System.Windows.Forms.GroupBox();
            this.dgvModulos = new System.Windows.Forms.DataGridView();
            this.btnAgregarModulo = new System.Windows.Forms.Button();
            this.btnEditarModulo = new System.Windows.Forms.Button();
            this.btnEliminarModulo = new System.Windows.Forms.Button();

            this.gbPreguntas = new System.Windows.Forms.GroupBox();
            this.lblModPregunta = new System.Windows.Forms.Label();
            this.cmbModuloPregunta = new System.Windows.Forms.ComboBox();
            this.dgvPreguntas = new System.Windows.Forms.DataGridView();
            this.btnAgregarPregunta = new System.Windows.Forms.Button();
            this.btnEditarPregunta = new System.Windows.Forms.Button();
            this.btnEliminarPregunta = new System.Windows.Forms.Button();

            this.gbOpciones = new System.Windows.Forms.GroupBox();
            this.dgvOpciones = new System.Windows.Forms.DataGridView();
            this.chkCorrecta = new System.Windows.Forms.CheckBox();
            this.btnAgregarOpcion = new System.Windows.Forms.Button();
            this.btnEliminarOpcion = new System.Windows.Forms.Button();

            this.btnCerrarSesion = new System.Windows.Forms.Button();

            this.tabAdmin.SuspendLayout();
            this.tabUsuarios.SuspendLayout();
            this.tabContenido.SuspendLayout();
            this.gbModulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).BeginInit();
            this.gbPreguntas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).BeginInit();
            this.gbOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            this.tabAdmin.Controls.Add(this.tabUsuarios);
            this.tabAdmin.Controls.Add(this.tabContenido);
            this.tabAdmin.Location = new System.Drawing.Point(10, 10);
            this.tabAdmin.Size = new System.Drawing.Size(880, 600);

            this.tabUsuarios.Controls.Add(this.lblUsuarios);
            this.tabUsuarios.Controls.Add(this.btnCargar);
            this.tabUsuarios.Controls.Add(this.btnEliminar);
            this.tabUsuarios.Controls.Add(this.cmbRol);
            this.tabUsuarios.Controls.Add(this.btnActualizarRol);
            this.tabUsuarios.Controls.Add(this.dgvUsuarios);
            this.tabUsuarios.Text = "Usuarios";

            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.lblUsuarios.Location = new System.Drawing.Point(20, 20);
            this.lblUsuarios.Text = "Gestión de usuarios";

            this.btnCargar.Location = new System.Drawing.Point(20, 60);
            this.btnCargar.Size = new System.Drawing.Size(110, 30);
            this.btnCargar.Text = "Cargar todos";
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);

            // btnEliminar
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(140, 60);
            this.btnEliminar.Size = new System.Drawing.Size(80, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            // cmbRol
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.Enabled = false;
            this.cmbRol.Items.AddRange(new object[] { "jugador", "administrador" });
            this.cmbRol.Location = new System.Drawing.Point(240, 60);
            this.cmbRol.Size = new System.Drawing.Size(110, 23);

            // btnActualizarRol
            this.btnActualizarRol.Enabled = false;
            this.btnActualizarRol.Location = new System.Drawing.Point(360, 60);
            this.btnActualizarRol.Size = new System.Drawing.Size(100, 30);
            this.btnActualizarRol.Text = "Cambiar rol";
            this.btnActualizarRol.Click += new System.EventHandler(this.btnActualizarRol_Click);

            // dgvUsuarios
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.Location = new System.Drawing.Point(20, 110);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(840, 450);
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);

            // tabContenido
            this.tabContenido.Controls.Add(this.gbModulos);
            this.tabContenido.Controls.Add(this.gbPreguntas);
            this.tabContenido.Controls.Add(this.gbOpciones);
            this.tabContenido.Text = "Contenido educativo";

            // gbModulos
            this.gbModulos.Controls.Add(this.dgvModulos);
            this.gbModulos.Controls.Add(this.btnAgregarModulo);
            this.gbModulos.Controls.Add(this.btnEditarModulo);
            this.gbModulos.Controls.Add(this.btnEliminarModulo);
            this.gbModulos.Location = new System.Drawing.Point(10, 10);
            this.gbModulos.Size = new System.Drawing.Size(380, 250);
            this.gbModulos.Text = "Módulos";

            // dgvModulos
            this.dgvModulos.AllowUserToAddRows = false;
            this.dgvModulos.Location = new System.Drawing.Point(10, 20);
            this.dgvModulos.ReadOnly = true;
            this.dgvModulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModulos.Size = new System.Drawing.Size(360, 170);

            // btnAgregarModulo
            this.btnAgregarModulo.Location = new System.Drawing.Point(10, 200);
            this.btnAgregarModulo.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarModulo.Text = "Agregar";
            this.btnAgregarModulo.Click += new System.EventHandler(this.btnAgregarModulo_Click);

            // btnEditarModulo
            this.btnEditarModulo.Location = new System.Drawing.Point(120, 200);
            this.btnEditarModulo.Size = new System.Drawing.Size(100, 30);
            this.btnEditarModulo.Text = "Editar";
            this.btnEditarModulo.Click += new System.EventHandler(this.btnEditarModulo_Click);

            // btnEliminarModulo
            this.btnEliminarModulo.Location = new System.Drawing.Point(230, 200);
            this.btnEliminarModulo.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarModulo.Text = "Eliminar";
            this.btnEliminarModulo.Click += new System.EventHandler(this.btnEliminarModulo_Click);

            // gbPreguntas
            this.gbPreguntas.Controls.Add(this.lblModPregunta);
            this.gbPreguntas.Controls.Add(this.cmbModuloPregunta);
            this.gbPreguntas.Controls.Add(this.dgvPreguntas);
            this.gbPreguntas.Controls.Add(this.btnAgregarPregunta);
            this.gbPreguntas.Controls.Add(this.btnEditarPregunta);
            this.gbPreguntas.Controls.Add(this.btnEliminarPregunta);
            this.gbPreguntas.Location = new System.Drawing.Point(400, 10);
            this.gbPreguntas.Size = new System.Drawing.Size(470, 250);
            this.gbPreguntas.Text = "Preguntas";

            // lblModPregunta
            this.lblModPregunta.AutoSize = true;
            this.lblModPregunta.Location = new System.Drawing.Point(10, 20);
            this.lblModPregunta.Text = "Módulo:";

            // cmbModuloPregunta
            this.cmbModuloPregunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModuloPregunta.Location = new System.Drawing.Point(70, 17);
            this.cmbModuloPregunta.Size = new System.Drawing.Size(200, 23);
            this.cmbModuloPregunta.SelectedIndexChanged += new System.EventHandler(this.cmbModuloPregunta_SelectedIndexChanged);

            // dgvPreguntas
            this.dgvPreguntas.AllowUserToAddRows = false;
            this.dgvPreguntas.Location = new System.Drawing.Point(10, 55);
            this.dgvPreguntas.ReadOnly = true;
            this.dgvPreguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreguntas.Size = new System.Drawing.Size(450, 130);
            this.dgvPreguntas.SelectionChanged += new System.EventHandler(this.dgvPreguntas_SelectionChanged);

            // btnAgregarPregunta
            this.btnAgregarPregunta.Location = new System.Drawing.Point(10, 195);
            this.btnAgregarPregunta.Size = new System.Drawing.Size(100, 30);
            this.btnAgregarPregunta.Text = "Agregar";
            this.btnAgregarPregunta.Click += new System.EventHandler(this.btnAgregarPregunta_Click);

            // btnEditarPregunta
            this.btnEditarPregunta.Location = new System.Drawing.Point(120, 195);
            this.btnEditarPregunta.Size = new System.Drawing.Size(100, 30);
            this.btnEditarPregunta.Text = "Editar";
            this.btnEditarPregunta.Click += new System.EventHandler(this.btnEditarPregunta_Click);

            // btnEliminarPregunta
            this.btnEliminarPregunta.Location = new System.Drawing.Point(230, 195);
            this.btnEliminarPregunta.Size = new System.Drawing.Size(100, 30);
            this.btnEliminarPregunta.Text = "Eliminar";
            this.btnEliminarPregunta.Click += new System.EventHandler(this.btnEliminarPregunta_Click);

            // gbOpciones
            this.gbOpciones.Controls.Add(this.dgvOpciones);
            this.gbOpciones.Controls.Add(this.chkCorrecta);
            this.gbOpciones.Controls.Add(this.btnAgregarOpcion);
            this.gbOpciones.Controls.Add(this.btnEliminarOpcion);
            this.gbOpciones.Location = new System.Drawing.Point(10, 270);
            this.gbOpciones.Size = new System.Drawing.Size(860, 290);
            this.gbOpciones.Text = "Opciones de la pregunta seleccionada";

            // dgvOpciones
            this.dgvOpciones.AllowUserToAddRows = false;
            this.dgvOpciones.Location = new System.Drawing.Point(10, 20);
            this.dgvOpciones.ReadOnly = true;
            this.dgvOpciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOpciones.Size = new System.Drawing.Size(840, 200);

            // chkCorrecta
            this.chkCorrecta.AutoSize = true;
            this.chkCorrecta.Location = new System.Drawing.Point(10, 230);
            this.chkCorrecta.Text = "Es correcta";

            // btnAgregarOpcion
            this.btnAgregarOpcion.Location = new System.Drawing.Point(130, 225);
            this.btnAgregarOpcion.Size = new System.Drawing.Size(120, 30);
            this.btnAgregarOpcion.Text = "Agregar opción";
            this.btnAgregarOpcion.Click += new System.EventHandler(this.btnAgregarOpcion_Click);

            // btnEliminarOpcion
            this.btnEliminarOpcion.Location = new System.Drawing.Point(260, 225);
            this.btnEliminarOpcion.Size = new System.Drawing.Size(120, 30);
            this.btnEliminarOpcion.Text = "Eliminar opción";
            this.btnEliminarOpcion.Click += new System.EventHandler(this.btnEliminarOpcion_Click);

            // btnCerrarSesion
            this.btnCerrarSesion.Location = new System.Drawing.Point(20, 620);
            this.btnCerrarSesion.Size = new System.Drawing.Size(120, 30);
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // FormAdministrador
            this.ClientSize = new System.Drawing.Size(920, 680);
            this.Text = "Panel de Administrador";
            this.Controls.Add(this.tabAdmin);
            this.Controls.Add(this.btnCerrarSesion);  // agregamos el botón fuera del TabControl
            this.tabAdmin.ResumeLayout(false);
            this.tabUsuarios.ResumeLayout(false);
            this.tabUsuarios.PerformLayout();
            this.tabContenido.ResumeLayout(false);
            this.gbModulos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulos)).EndInit();
            this.gbPreguntas.ResumeLayout(false);
            this.gbPreguntas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).EndInit();
            this.gbOpciones.ResumeLayout(false);
            this.gbOpciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
        }
    }
}