namespace Plataforma_Educativa
{
    partial class FormRegistro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUsuarioRegistro = new Label();
            lblContraseñaRegistro = new Label();
            lblRol = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            comboBoxRol = new ComboBox();
            btnRegistrar = new Button();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // lblUsuarioRegistro
            // 
            lblUsuarioRegistro.AutoSize = true;
            lblUsuarioRegistro.Location = new Point(48, 39);
            lblUsuarioRegistro.Name = "lblUsuarioRegistro";
            lblUsuarioRegistro.Size = new Size(50, 15);
            lblUsuarioRegistro.TabIndex = 0;
            lblUsuarioRegistro.Text = "Usuario:";
            // 
            // lblContraseñaRegistro
            // 
            lblContraseñaRegistro.AutoSize = true;
            lblContraseñaRegistro.Location = new Point(48, 99);
            lblContraseñaRegistro.Name = "lblContraseñaRegistro";
            lblContraseñaRegistro.Size = new Size(70, 15);
            lblContraseñaRegistro.TabIndex = 1;
            lblContraseñaRegistro.Text = "Contraseña:";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Location = new Point(48, 159);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(27, 15);
            lblRol.TabIndex = 2;
            lblRol.Text = "Rol:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(153, 39);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(153, 99);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 4;
            // 
            // comboBoxRol
            // 
            comboBoxRol.FormattingEnabled = true;
            comboBoxRol.Items.AddRange(new object[] { "Jugador", "Administrador" });
            comboBoxRol.Location = new Point(154, 159);
            comboBoxRol.Name = "comboBoxRol";
            comboBoxRol.Size = new Size(99, 23);
            comboBoxRol.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(48, 383);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(87, 23);
            btnRegistrar.TabIndex = 6;
            btnRegistrar.Text = "Crear Cuenta";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(170, 383);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 23);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver al Login";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrar);
            Controls.Add(comboBoxRol);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblRol);
            Controls.Add(lblContraseñaRegistro);
            Controls.Add(lblUsuarioRegistro);
            Name = "FormRegistro";
            Text = "FormRegistro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuarioRegistro;
        private Label lblContraseñaRegistro;
        private Label lblRol;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private ComboBox comboBoxRol;
        private Button btnRegistrar;
        private Button btnVolver;
    }
}