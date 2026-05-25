namespace Plataforma_Educativa
{
    partial class FormRegistro
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox comboBoxRol;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnVolver;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            comboBoxRol = new ComboBox();
            btnRegistrar = new Button();
            btnVolver = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 70);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 110);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 2;
            label3.Text = "Rol:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(120, 27);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(180, 23);
            txtUsuario.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(120, 67);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(180, 23);
            txtPassword.TabIndex = 4;
            // 
            // comboBoxRol
            // 
            comboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRol.Items.AddRange(new object[] { "jugador", "administrador" });
            comboBoxRol.Location = new Point(120, 107);
            comboBoxRol.Name = "comboBoxRol";
            comboBoxRol.Size = new Size(180, 23);
            comboBoxRol.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(120, 150);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(85, 30);
            btnRegistrar.TabIndex = 6;
            btnRegistrar.Text = "Crear cuenta";
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(215, 150);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(85, 30);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver al login";
            btnVolver.Click += btnVolver_Click;
            // 
            // FormRegistro
            // 
            ClientSize = new Size(822, 452);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(txtUsuario);
            Controls.Add(txtPassword);
            Controls.Add(comboBoxRol);
            Controls.Add(btnRegistrar);
            Controls.Add(btnVolver);
            Name = "FormRegistro";
            Text = "Registro de usuario";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
