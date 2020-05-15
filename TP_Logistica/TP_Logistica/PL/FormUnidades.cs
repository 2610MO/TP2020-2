using System;
using System.Windows.Forms;
using TP_Logistica.BLL;
using TP_Logistica.DAL;

namespace Proyecto_Logistica
{
    public partial class FormUnidades : Form
    {
        UnidadBLL unidadBLL;
        UnidadDAL unidadDAL;

        public FormUnidades()
        {
            unidadDAL = new UnidadDAL();//Se crean el cliente para la base
            unidadBLL = new UnidadBLL();//Se crea el molde para uso y llenado

            InitializeComponent();
            btnEditar.Visible = false;
            buttoneliminar.Visible = false;
            LlenarGrid();
            //dataGridView1.Rows.Insert(0, "1", "AEO-159-54", "Volador", "3.5", "417029762", "El águila 564564161");
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormAgregarUnidad frm = new FormAgregarUnidad(true, false);
            AddOwnedForm(frm);
            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            FormAgregarUnidad frm = new FormAgregarUnidad(false, true);//Se crea el objeto del formulario Aux 
            AddOwnedForm(frm);//Se direcciona del form padre al hijo
            if (dataGridView1.SelectedRows.Count > 0)
            {
                frm.txtPlacas.Text = unidadBLL.Placa;
                frm.txtModelo.Text = unidadBLL.Modelo;
                frm.txtcapacidad.Text = unidadBLL.Capacidad;
                frm.txtnoserie.Text = unidadBLL.numeroDeSerie;
                frm.txtseguro.Text = unidadBLL.Seguro;
                frm.txtOperador.Text = unidadBLL.Operador;
                frm.txtTelefono.Text = unidadBLL.Telefono;
                frm.IDAux = unidadBLL.ID;

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
                unidadDAL.Eliminar(unidadBLL);
                LlenarGrid();
                //dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
        }

        public void LlenarGrid()
        {
            

            dataGridView1.DataSource = unidadDAL.MostrarUnidades().Tables[0];
            dataGridView1.Columns[0].HeaderText = "#";
            dataGridView1.Columns[1].HeaderText = "Placas";
            dataGridView1.Columns[2].HeaderText = "Modelo";
            dataGridView1.Columns[3].HeaderText = "Seguro";
            dataGridView1.Columns[4].HeaderText = "Capacidad";
            dataGridView1.Columns[5].HeaderText = "No. de Serie";
            dataGridView1.Columns[5].HeaderText = "Operador";
            dataGridView1.Columns[5].HeaderText = "Teléfono";


        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;//Indice para saber en que fila estamos

            //dataGridView1.ClearSelection();
            //Para al hacer click fuera de las filas, que no rompa por una sobrecarga del indice
            if (indice >= 0)
            {
                unidadBLL.ID = int.Parse(dataGridView1.Rows[indice].Cells[0].Value.ToString());
                unidadBLL.Placa = dataGridView1.Rows[indice].Cells[1].Value.ToString();
                unidadBLL.Modelo = dataGridView1.Rows[indice].Cells[2].Value.ToString();
                unidadBLL.Seguro = dataGridView1.Rows[indice].Cells[3].Value.ToString();
                unidadBLL.Capacidad = dataGridView1.Rows[indice].Cells[4].Value.ToString();
                unidadBLL.numeroDeSerie = dataGridView1.Rows[indice].Cells[5].Value.ToString();
                unidadBLL.Operador = dataGridView1.Rows[indice].Cells[6].Value.ToString();
                unidadBLL.Telefono = dataGridView1.Rows[indice].Cells[7].Value.ToString();
            }
        }
    }
}
