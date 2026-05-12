using System;
using System.Drawing;
using System.Windows.Forms;

namespace Plataforma_Educativa
{
    public partial class FormJugador : Form
    {
        public FormJugador()
        {
            InitializeComponent();
            this.Text = "Panel de Jugador";
            this.Size = new Size(300, 200);

            Label lblBienvenido = new Label
            {
                Text = "Bienvenido Jugador!",
                AutoSize = true,
                Location = new Point(30, 30),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblBienvenido);

            Button btnSalir = new Button
            {
                Text = "Cerrar sesión",
                Location = new Point(30, 80),
                Size = new Size(120, 30)
            };
            btnSalir.Click += (sender, e) => { this.Close(); };
            this.Controls.Add(btnSalir);
        }
    }
}