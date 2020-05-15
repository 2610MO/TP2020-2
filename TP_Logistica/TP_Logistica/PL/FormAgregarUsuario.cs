using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TP_Logistica.DAL;
using TP_Logistica.BLL;

namespace TP_Logistica.PL
{
    public partial class FormAgregarUsuario : Form
    {
        UsuarioDAL usuarioDAL;
        public int IDAux;
        public Image Aux;
        public int IDCBX;
        public byte[] pictureSet;
        public string IDPERMISOS;
        public FormAgregarUsuario(bool agregar, bool editar)
        {
            usuarioDAL = new UsuarioDAL();
            InitializeComponent();
            labelagregarcliente.Visible = agregar;
            labeleditarunidad.Visible = editar;
            btnguardarUsuarionuevo.Visible = agregar;
            btnguardarUsuarioeditar.Visible = editar;
        }

        private void btnCancelaragregarUsuario_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnguardarUsuarionuevo_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                usuarioDAL.Agregar(RecuperarInformacion());
                FormUsuario frm = Owner as FormUsuario;
                frm.LlenarGrid();
                Close();
            }
        }

        private void btnguardarUsuarioeditar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                usuarioDAL.Modificar(RecuperarInformacion());
                FormUsuario frm = Owner as FormUsuario;
                frm.LlenarGrid();
                Close();
            }
        }

        private UsuarioBLL RecuperarInformacion()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            UsuarioBLL usuarioBLL = new UsuarioBLL();
            usuarioBLL.NombreUsuario = txtNombreUsuario.Text;
            usuarioBLL.Nombre = txtnombre.Text;
            usuarioBLL.Apellido = txtApellido.Text;
            usuarioBLL.Cargo = txtCargo.Text;
            usuarioBLL.Foto = ms.GetBuffer();
            usuarioBLL.Password = txtPassword.Text;
            usuarioBLL.Permisos =int.Parse(cbxPermisos.SelectedValue.ToString());
            usuarioBLL.ID = IDAux;//Aqui se usa la variable auxiliar para asignarla al ClietneBLL y poder pasar al metodo de editar un objeto completo


            return usuarioBLL;
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(fd.FileName);

            }
        }

        private void ListarPermisos()
        {
            PermisosDAL permisosDAL = new PermisosDAL();
            cbxPermisos.DataSource = permisosDAL.MostrarPermisos().Tables[0];
            cbxPermisos.DisplayMember = "Tipo";
            cbxPermisos.ValueMember = "ID";
            //pictureBox1.Image = 
            
        }

        private void FormAgregarUsuario_Load(object sender, EventArgs e)
        {
            
            ListarPermisos();
            cbxPermisos.SelectedIndex = cbxPermisos.FindStringExact(IDPERMISOS);
            if (txtApellido.Text != "")
            {
                //MessageBox.Show("Editar");
                System.IO.MemoryStream ms = new System.IO.MemoryStream(pictureSet);
                pictureBox1.Image = Image.FromStream(ms);

            }
            else
            {
                //MessageBox.Show("Nuevo");

            }

        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtnombre.Text)||string.IsNullOrWhiteSpace(txtnombre.Text) || txtnombre.Text.Count() < 3|| string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || txtApellido.Text.Count() < 3 || string.IsNullOrEmpty(txtCargo.Text) || string.IsNullOrWhiteSpace(txtCargo.Text) || txtCargo.Text.Count() < 3 || string.IsNullOrEmpty(txtNombreUsuario.Text) || string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || txtNombreUsuario.Text.Count() < 3 || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Count() < 3)
            {
                MessageBox.Show("Por favor, llena todos los campos correctamente para continuar");
                return false;
            }else if (cbxPermisos.SelectedIndex == -1 || string.IsNullOrEmpty(cbxPermisos.Text)||string.IsNullOrWhiteSpace(cbxPermisos.Text))
            {
                MessageBox.Show("Solo puedes añadir los permisos previamente establecidos");
                return false;
            }else if (pictureBox1.Image==null)
            {
                MessageBox.Show("La foto del usuario a registrar es necesaria para continuar");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtNombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbxPermisos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
