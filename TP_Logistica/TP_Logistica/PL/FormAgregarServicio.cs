using System;
using System.Linq;
using System.Windows.Forms;
using TP_Logistica.BLL;
using TP_Logistica.DAL;

namespace Proyecto_Logistica
{
    public partial class FormAgregarServicio : Form
    {
        ServicioDAL servicioDAL;
        public int IDAux;
        public string IDCliente;
        public string IDUnidad;

        public FormAgregarServicio(bool agregar, bool editar)
        {
            servicioDAL = new ServicioDAL();
            InitializeComponent(); 
            labelagregarservicio.Visible = agregar;
            labeleditarservicio.Visible = editar;
            btnguardarservicionuevo.Visible = agregar;
            btnguardareditarservicio.Visible = editar;

            cbxCliente.SelectedIndex = cbxCliente.FindStringExact(IDCliente);
            cbxUnidad.SelectedIndex = cbxUnidad.FindStringExact(IDUnidad);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)//nuevo
        {
            if (ValidarCampos())
            {
                servicioDAL.Agregar(RecuperarInformacion());
                FormServicios frm = Owner as FormServicios;//Se direcciona del formulario hijo al padre,el objeto ya existe, solo se hace referencia
                frm.LlenarGrid();
                //frm.dataGridView1.Rows.Insert(0, "1", txtCV.Text, txtPlacas.Text, txtOrigen.Text, txtDestino.Text, txtCelular.Text);
                Close();
            }
        }

        private ServicioBLL RecuperarInformacion()
        {
            ServicioBLL servicioBLL = new ServicioBLL();
            servicioBLL.IDCliente = int.Parse(cbxCliente.SelectedValue.ToString());
            servicioBLL.IDUnidad = int.Parse(cbxUnidad.SelectedValue.ToString());
            servicioBLL.Origen = txtOrigen.Text;
            servicioBLL.CV = txtCV.Text;
            servicioBLL.ID = IDAux;
            return servicioBLL;
        }

        private void btnguardareditarservicio_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                FormServicios frm = Owner as FormServicios;
                servicioDAL.Modificar(RecuperarInformacion());
                frm.LlenarGrid();
                Close();
            }
        }

        private void FormAgregarServicio_Load(object sender, EventArgs e)
        {
            ListarClientes();
            ListarUnidades();
            cbxCliente.SelectedIndex = cbxCliente.FindStringExact(IDCliente);
            cbxUnidad.SelectedIndex = cbxUnidad.FindStringExact(IDUnidad);
        }

        private void ListarClientes()
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            cbxCliente.DataSource = clienteDAL.MostrarClientes().Tables[0];
            cbxCliente.DisplayMember = "Empresa";
            cbxCliente.ValueMember = "ID";
        }

        private void ListarUnidades()
        {
            UnidadDAL unidadDAL = new UnidadDAL();
            cbxUnidad.DataSource = unidadDAL.MostrarUnidades().Tables[0];
            cbxUnidad.DisplayMember = "placa";
            cbxUnidad.ValueMember = "id";
        }

        private void cbxCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbxUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtCV.Text) || string.IsNullOrWhiteSpace(txtCV.Text) || txtCV.Text.Count()<3|| string.IsNullOrEmpty(txtOrigen.Text) || string.IsNullOrWhiteSpace(txtOrigen.Text) || txtOrigen.Text.Count() < 3)
            {
                MessageBox.Show("Por favor, llena todos los campos correctamente para continuar");
                return false;
            }
            else if (cbxCliente.SelectedIndex == -1 || string.IsNullOrEmpty(cbxCliente.Text) || string.IsNullOrWhiteSpace(cbxCliente.Text))
            {
                MessageBox.Show("Solo puedes añadir a los Clientes previamente establecidos, para agregar un nuevo cliente, dirigete al apartado correspondiente");
                return false;
            }
            else if (cbxUnidad.SelectedIndex == -1 || string.IsNullOrEmpty(cbxUnidad.Text) || string.IsNullOrWhiteSpace(cbxUnidad.Text))
            {
                MessageBox.Show("Solo puedes añadir la unidad previamente establecida, para agregar una nueva unidad, dirigete al apartado correspondiente");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
