using System;
using System.Windows.Forms;
using TP_Logistica.DAL;
using TP_Logistica.BLL;
using System.Linq;

namespace Proyecto_Logistica
{
    public partial class FormAgregarCliente : Form
    {
        ClienteDAL clienteDAL;
        public int IDAux;//Variable para al modificar obtener el indice a modificar 

        public FormAgregarCliente(bool agregar, bool editar)
        {
            
            clienteDAL = new ClienteDAL();
            InitializeComponent();
            labelagregarcliente.Visible = agregar;
            labeleditarunidad.Visible = editar;
            btnguardarclientenuevo.Visible = agregar;
            btnguardarclienteeditar.Visible = editar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnguardarcliente_Click(object sender, EventArgs e)//nuevo
        {
            if (ValidarCampos())
            {
                //MessageBox.Show("Agregando");
                //conexionDAL conexion = new conexionDAL();
                //conexion.PruebaConectar();
                //Recuperamos la informacion y ejecutamos el metodo agregar de la clase ClienteDAL
                clienteDAL.Agregar(RecuperarInformacion());//Se agrega al cliente a la base, se usa el metodo recuperar informacion que devuelve un ClienteBLL con la informacion a cargar
                //Success, no hace nada en particular
                //MessageBox.Show("Conectado");
                FormClientes frm = Owner as FormClientes;//Se direcciona del formulario hijo al padre,el objeto ya existe, solo se hace referencia
                frm.LlenarGrid();//Actualiza el grid
                //frm.dataGridView1.DataSource = clienteDAL.MostrarClientes().Tables[0];//Actualizacion de la datagridview para desplegar la ultima version de la base de datos
                //Ya no necesitamos esto debido a que la insercion se hace en la base, solo se actualiza el data grid view con lo que hay en base
                //frm.dataGridView1.Rows.Insert(0,"1",txtempresacliente.Text, txtdireccioncliente.Text, txtRFCcliente.Text, txtcontactocliente.Text, txtgirocliente.Text);
                Close();
            }
        }

        //Metodo que recupera la informacion de los textbox y devuelve un objeto de tipo ClienteBLL
        private ClienteBLL RecuperarInformacion()
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            clienteBLL.Empresa = txtempresacliente.Text;
            clienteBLL.Direccion =txtdireccioncliente.Text;
            clienteBLL.RFC =txtRFCcliente.Text;
            clienteBLL.Contacto =txtcontactocliente.Text;
            clienteBLL.Giro =txtgirocliente.Text;
            clienteBLL.ID = IDAux;//Aqui se usa la variable auxiliar para asignarla al ClietneBLL y poder pasar al metodo de editar un objeto completo


            return clienteBLL;
        }

        private void btnguardarclienteeditar_Click(object sender, EventArgs e)//editar
        {
            if (ValidarCampos())
            {
                //Console.WriteLine("Estamos en el boton guardar de editaaaaaar");
                FormClientes frm = Owner as FormClientes;
                //Funcion de Clase que define el metodo Modificar, se le pasa 
                clienteDAL.Modificar(RecuperarInformacion());
                //Actualizamos el dataGridView para que despliegue la tabla modificada
                frm.LlenarGrid();
                //frm.dataGridView1.DataSource = clienteDAL.MostrarClientes().Tables[0];
                //Ya no se necesita esto debido a que no modificamos el dataGridView, se modifican los datos en la base y la dataGridView solo se actualiza
                /*frm.dataGridView1.CurrentRow.Cells[1].Value = txtempresacliente.Text;
                frm.dataGridView1.CurrentRow.Cells[2].Value = txtdireccioncliente.Text;
                frm.dataGridView1.CurrentRow.Cells[3].Value = txtRFCcliente.Text;
                frm.dataGridView1.CurrentRow.Cells[4].Value = txtcontactocliente.Text;
                frm.dataGridView1.CurrentRow.Cells[5].Value = txtgirocliente.Text;*/
                Close();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtempresacliente.Text) || string.IsNullOrWhiteSpace(txtempresacliente.Text) || txtempresacliente.Text.Count() < 3 || string.IsNullOrEmpty(txtdireccioncliente.Text) || string.IsNullOrWhiteSpace(txtdireccioncliente.Text) || txtdireccioncliente.Text.Count() < 3 || string.IsNullOrEmpty(txtRFCcliente.Text) || string.IsNullOrWhiteSpace(txtRFCcliente.Text) || txtRFCcliente.Text.Count() < 3 || string.IsNullOrEmpty(txtcontactocliente.Text) || string.IsNullOrWhiteSpace(txtcontactocliente.Text) || txtcontactocliente.Text.Count() < 3 || string.IsNullOrEmpty(txtgirocliente.Text) || string.IsNullOrWhiteSpace(txtgirocliente.Text) || txtgirocliente.Text.Count() < 3)
            {
                MessageBox.Show("Por favor, llena todos los campos correctamente para continuar");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtcontactocliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }

}
