using System;
using System.Windows.Forms;
using TP_Logistica.BLL;
using TP_Logistica.DAL;


namespace Proyecto_Logistica
{
    public partial class FormClientes : Form
    {

        ClienteDAL clienteDAL;
        ClienteBLL clienteBLL;
        public FormClientes()
        {
            clienteDAL = new ClienteDAL();//Se crean el cliente para la base
            clienteBLL = new ClienteBLL();//Se crea el molde para uso y llenado
            InitializeComponent();
            btnEditar.Visible = false;
            btnEliminarCliente.Visible = false;
            LlenarGrid(); //Traemos los datos de la base para llenar el grid

            //esta parte ya no se usa dado que la base llena el grid 
            //dataGridView1.Rows.Insert(0,"1", "Ricolino", "México", "RICO983749823", "018004569874","Chuche");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormAgregarCliente frm = new FormAgregarCliente(false,true);//Se crea el objeto del formulario Aux 
            AddOwnedForm(frm);//Se direcciona del form padre al hijo
            if (dataGridView1.SelectedRows.Count > 0)
            {
                frm.txtempresacliente.Text = clienteBLL.Empresa;
                frm.txtdireccioncliente.Text = clienteBLL.Direccion;
                frm.txtRFCcliente.Text = clienteBLL.RFC;
                frm.txtcontactocliente.Text = clienteBLL.Contacto;
                frm.txtgirocliente.Text = clienteBLL.Giro;
                frm.IDAux = clienteBLL.ID; //Se usa una variable para pasar el ID debido a que en editar no se puede (ni debe) de editarse el id
                frm.ShowDialog();             
            }
            else
                MessageBox.Show("Seleccione una fila.");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        { 
            FormAgregarCliente frm = new FormAgregarCliente(true,false);
            AddOwnedForm(frm);
            frm.ShowDialog();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEditar.Visible = true;
            btnEliminarCliente.Visible = true;
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            btnEditar.Visible = false;
            btnEliminarCliente.Visible = false;   
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            btnEditar.Visible = false;
            btnEliminarCliente.Visible = false;
            
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quiere eliminar esta fila?", "Eliminar fila.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                clienteDAL.Eliminar(clienteBLL);//Se usa el metodo eliminar de la clase ClienteDAL. Recibe de parametro el objeto de tipo ClienteBLL que contiene el ID para eliminar
                LlenarGrid();//Una vez eliminado se actualiza el grid

                //dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
        }

        //Accion que nos devuelve el objeto seleccionado de tipo ClienteBLL
        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;//Indice para saber en que fila estamos

            //dataGridView1.ClearSelection();
            //Para al hacer click fuera de las filas, que no rompa por una sobrecarga del indice
            if (indice >= 0)
            {
                clienteBLL.ID = int.Parse(dataGridView1.Rows[indice].Cells[0].Value.ToString());
                clienteBLL.Empresa = dataGridView1.Rows[indice].Cells[1].Value.ToString();
                clienteBLL.Direccion = dataGridView1.Rows[indice].Cells[2].Value.ToString();
                clienteBLL.RFC = dataGridView1.Rows[indice].Cells[3].Value.ToString();
                clienteBLL.Contacto = dataGridView1.Rows[indice].Cells[4].Value.ToString();
                clienteBLL.Giro = dataGridView1.Rows[indice].Cells[5].Value.ToString();
            }
        }

        //Metodo para llenar y/o actualizar el grid segun corresponda. Trae los datos de la base, al mismo tiempo cambia los nombres de los Headers de las columnas para que no se muestren los nombres de las variables de la base.
        public void LlenarGrid()
        {
            dataGridView1.DataSource = clienteDAL.MostrarClientes().Tables[0];
            dataGridView1.Columns[0].HeaderText = "#";
            dataGridView1.Columns[1].HeaderText = "Empresa";
            dataGridView1.Columns[2].HeaderText = "Dirección";
            dataGridView1.Columns[3].HeaderText = "RFC";
            dataGridView1.Columns[4].HeaderText = "Contacto";
            dataGridView1.Columns[5].HeaderText = "Giro";
        }
    }
}
