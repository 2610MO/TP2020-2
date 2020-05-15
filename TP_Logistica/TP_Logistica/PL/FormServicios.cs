using System;
using System.Windows.Forms;
using TP_Logistica.BLL;
using TP_Logistica.DAL;

namespace Proyecto_Logistica
{
    public partial class FormServicios : Form
    {

        ServicioBLL servicioBLL;
        ServicioDAL servicioDAL;
        public string IDClienteDataGrid;
        public string IDUnidadDataGrid;
        public FormServicios()
        {
            servicioBLL = new ServicioBLL();
            servicioDAL = new ServicioDAL();

            InitializeComponent();
            btnEditar.Visible = false;
            button2.Visible = false;//es el boton de eliminar
            LlenarGrid();
            //dataGridView1.Rows.Insert(0,"1", "2013081242", "AEC-234-23", "México", "Veracruz", "Pancho", "5574419398");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormAgregarServicio frm = new FormAgregarServicio(true, false);
            AddOwnedForm(frm);
            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)//Aqui estoy experimentando.....
        {
            FormAgregarServicio frm = new FormAgregarServicio(false, true);//Se crea el objeto del formulario Aux 
            AddOwnedForm(frm);//Se direcciona del form padre al hijo
            if (dataGridView1.SelectedRows.Count > 0)
            {
                frm.txtCV.Text = servicioBLL.CV;
                frm.IDCliente = IDClienteDataGrid;
                frm.IDUnidad = IDUnidadDataGrid;
               
                //frm.IDCliente = servicioBLL.IDCliente;
                frm.txtOrigen.Text = servicioBLL.Origen;
                //frm.IDUnidad = servicioBLL.IDUnidad;
                frm.IDAux = servicioBLL.ID;
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Seleccione una fila.");
            #region for para ver si están vacias filas y celdas 

            /////////////////////////////////////////////
            ///
            /*if (dataGridView1.RowCount > 0)
            {
                bool bCampoVacio = false;
                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell dc in dr.Cells)
                    {
                        if (dc.Value == null || string.IsNullOrEmpty(dc.Value.ToString()))
                        {
                            bCampoVacio = true;
                        }
                    }
                }
                if (bCampoVacio)
                    MessageBox.Show("Hay algún campo vacío!. Crear nuevo Servicio.");
            }*/
            ///////////////////////////
            #endregion

        }

        private void button2_Click(object sender, EventArgs e)//boton de borrado
        {
            if (MessageBox.Show("¿Quiere eliminar esta fila?", "Eliminar fila.", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                servicioDAL.Eliminar(servicioBLL);
                LlenarGrid();
                //dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            btnEditar.Visible = false;
            button2.Visible = false;//es el boton de eliminar
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            btnEditar.Visible = false;
            button2.Visible = false;//es el boton de eliminar
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnEditar.Visible = true;
            button2.Visible = true;//es el boton de eliminar
        }

        public void LlenarGrid()
        {
            dataGridView1.DataSource = servicioDAL.MostrarServicios().Tables[0];
            dataGridView1.Columns[0].HeaderText = "#";
            dataGridView1.Columns[1].HeaderText = "CV";
            dataGridView1.Columns[2].HeaderText = "Placas";
            dataGridView1.Columns[3].HeaderText = "Empresa";
            dataGridView1.Columns[4].HeaderText = "Origen";
            dataGridView1.Columns[5].HeaderText = "Destino";
            dataGridView1.Columns[6].HeaderText = "Operador";
            dataGridView1.Columns[7].HeaderText = "Teléfono";
            
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;//Indice para saber en que fila estamos

            //dataGridView1.ClearSelection();
            //Para al hacer click fuera de las filas, que no rompa por una sobrecarga del indice
            if (indice >= 0)
            {

                servicioBLL.ID = int.Parse(dataGridView1.Rows[indice].Cells[0].Value.ToString());
                servicioBLL.CV = dataGridView1.Rows[indice].Cells[1].Value.ToString();
                IDUnidadDataGrid = dataGridView1.Rows[indice].Cells[2].Value.ToString();
                IDClienteDataGrid = dataGridView1.Rows[indice].Cells[3].Value.ToString();
                servicioBLL.Origen = dataGridView1.Rows[indice].Cells[4].Value.ToString();
                
                
            }
        }
    }
}
