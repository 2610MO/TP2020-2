using System;
using System.Text;
using System.Windows.Forms;
using TP_Logistica.BLL;
using TP_Logistica.DAL;

namespace TP_Logistica.PL
{
    public partial class FormUsuario : Form
    {
        UsuarioBLL usuarioBLL;
        UsuarioDAL usuarioDAL;
        string IDPERMISOS;
        public FormUsuario()
        {
            usuarioDAL = new UsuarioDAL();
            usuarioBLL = new UsuarioBLL();
            InitializeComponent();
            btnEditar.Visible = false;
            buttoneliminar.Visible = false;
            LlenarGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormAgregarUsuario frm = new FormAgregarUsuario(true, false);
            AddOwnedForm(frm);
            frm.ShowDialog();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormAgregarUsuario frm = new FormAgregarUsuario(false, true);
            AddOwnedForm(frm);
            if (dataGridView1.SelectedRows.Count > 0)
            {
                frm.txtNombreUsuario.Text = usuarioBLL.NombreUsuario;
                frm.txtCargo.Text = usuarioBLL.Cargo;
                frm.txtApellido.Text = usuarioBLL.Apellido;
                frm.txtnombre.Text = usuarioBLL.Nombre;

                frm.pictureSet = usuarioBLL.Foto;
                frm.IDPERMISOS = IDPERMISOS;
                frm.IDAux = usuarioBLL.ID;
                frm.txtPassword.Text = usuarioBLL.Password;
                frm.IDCBX = usuarioBLL.Permisos;
                frm.ShowDialog();


            }
            else
                MessageBox.Show("Seleccione una fila.");
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEditar.Visible = true;
            buttoneliminar.Visible = true;
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            btnEditar.Visible = false;
            buttoneliminar.Visible = false;
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            btnEditar.Visible = false;
            buttoneliminar.Visible = false;
        }

        private void buttoneliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quiere eliminar esta fila?", "Eliminar fila.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                usuarioDAL.Eliminar(usuarioBLL);//Se usa el metodo eliminar de la clase ClienteDAL. Recibe de parametro el objeto de tipo ClienteBLL que contiene el ID para eliminar
                LlenarGrid();//Una vez eliminado se actualiza el grid

                //dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;//Indice para saber en que fila estamos

            //dataGridView1.ClearSelection();
            //Para al hacer click fuera de las filas, que no rompa por una sobrecarga del indice
            if (indice >= 0)
            {
                usuarioBLL.ID = int.Parse(dataGridView1.Rows[indice].Cells[0].Value.ToString());
                usuarioBLL.NombreUsuario = dataGridView1.Rows[indice].Cells[1].Value.ToString();
                usuarioBLL.Nombre = dataGridView1.Rows[indice].Cells[2].Value.ToString();
                usuarioBLL.Apellido = dataGridView1.Rows[indice].Cells[3].Value.ToString();
                usuarioBLL.Cargo = dataGridView1.Rows[indice].Cells[4].Value.ToString();
                usuarioBLL.Foto = (byte[])dataGridView1.Rows[indice].Cells[5].Value;
                usuarioBLL.Password = dataGridView1.Rows[indice].Cells[7].Value.ToString();
                IDPERMISOS = dataGridView1.Rows[indice].Cells[6].Value.ToString();
               
            }

        }
        public void LlenarGrid()
        {
            //dataGridView1.Columns[5].
            dataGridView1.DataSource = usuarioDAL.MostrarUsuarios().Tables[0];
            //dataGridView1.RowTemplate.Height = 50;
            /*dataGridView1.Columns[0].HeaderText = "#";
            dataGridView1.Columns[1].HeaderText = "Nombre de Usuario";
            dataGridView1.Columns[2].HeaderText = "Nombre";
            dataGridView1.Columns[3].HeaderText = "Apellido";
            dataGridView1.Columns[4].HeaderText = "Cargo";
            dataGridView1.Columns[5].HeaderText = "Foto";
            dataGridView1.Columns[6].HeaderText = "Password";
            dataGridView1.Columns[7].HeaderText = "Permisos";
            */
        }
    }
}
