namespace Plataforma_Educativa
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegistrar;

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
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegistrar = new Button();
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
            // txtUsuario
            // 
            txtUsuario.Location = new Point(120, 27);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(180, 23);
            txtUsuario.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(120, 67);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(180, 23);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(120, 110);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(85, 30);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(215, 110);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(85, 30);
            btnRegistrar.TabIndex = 5;
            btnRegistrar.Text = "Registrarse";
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // FormLogin
            // 
            ClientSize = new Size(881, 454);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtUsuario);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(btnRegistrar);
            Name = "FormLogin";
            Text = "Inicio de sesión";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}