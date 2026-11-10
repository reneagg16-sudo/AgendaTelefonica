using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaTelefonica
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
   
        }

        private void lblContraseña_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkRegistrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegistro ventanaRegistro = new FrmRegistro();
            ventanaRegistro.Show();
            this.Hide();
        }
    }
}
