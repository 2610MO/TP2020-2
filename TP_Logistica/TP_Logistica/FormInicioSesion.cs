using Proyecto_Logistica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Logistica.BLL;
using TP_Logistica.DAL;

namespace TP_Logistica
{
    public partial class FormInicioSesion : Form
    {
        IniciaSesionDAL iniciaSesionDAL;
        UsuarioBLL usuarioBLL;
        FormMenuPrincipal loged;

        public FormInicioSesion()
        {
            iniciaSesionDAL = new IniciaSesionDAL();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuarioBLL = new UsuarioBLL();
            if (txtNombreUsuario.Text == null || txtNombreUsuario.Text == " " || txtPass.Text == "" || txtPass.Text == null || txtPass.Text == " " || txtPass.Text == "")
            {
                MessageBox.Show("Por favor, llena todos los campos");

            }
            else
            {
                usuarioBLL.NombreUsuario = txtNombreUsuario.Text;
                usuarioBLL.Password = txtPass.Text;

                if (iniciaSesionDAL.ValidarUsuario(txtNombreUsuario.Text,txtPass.Text).Foto != null)
                {

                    loged = new FormMenuPrincipal();
                    loged.auxUserName = iniciaSesionDAL.ValidarUsuario(txtNombreUsuario.Text, txtPass.Text).NombreUsuario;
                    loged.auxNombre = iniciaSesionDAL.ValidarUsuario(txtNombreUsuario.Text, txtPass.Text).Nombre;
                    loged.auxApellido = iniciaSesionDAL.ValidarUsuario(txtNombreUsuario.Text, txtPass.Text).Apellido;
                    loged.auxCargo = iniciaSesionDAL.ValidarUsuario(txtNombreUsuario.Text, txtPass.Text).Cargo;
                    loged.auxPic = iniciaSesionDAL.ValidarUsuario(txtNombreUsuario.Text, txtPass.Text).Foto;
                    loged.Permisos = iniciaSesionDAL.ValidarUsuario(txtNombreUsuario.Text, txtPass.Text).Permisos;

                    loged.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Error: Usuario o contraseña no validos. Corroborar credenciales");
                    txtNombreUsuario.Text = "";
                    txtPass.Text = "";
                }
            }

        }

        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = Location.X;
            ly = Location.Y;
            sw = Size.Width;
            sh = Size.Height;
            Size = Screen.PrimaryScreen.WorkingArea.Size;
            Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;

        }
        private void btnNormal_Click(object sender, EventArgs e)
        {
            Size = new Size(sw, sh);
            Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void txtNombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Cerrar programa.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }



    }
}
