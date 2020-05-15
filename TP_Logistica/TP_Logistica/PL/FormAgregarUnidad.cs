using System;
using System.Windows.Forms;
using TP_Logistica.DAL;
using TP_Logistica.BLL;
using System.Linq;

namespace Proyecto_Logistica
{
    public partial class FormAgregarUnidad : Form
    {
        UnidadDAL unidadDAL;
        public int IDAux;
        public FormAgregarUnidad(bool agregar, bool editar)
        {
            unidadDAL = new UnidadDAL();
            InitializeComponent();
            labelagregarunidad.Visible = agregar;
            label7.Visible = editar;//label editar unidad
            btnagregarunidad.Visible = agregar;
            btneditarunidad.Visible = editar;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)//agregar unidad
        {
            if (ValidarCampos())
            {
                unidadDAL.Agregar(RecuperarInformacion());
                FormUnidades frm = Owner as FormUnidades;//Se direcciona del formulario hijo al padre,el objeto ya existe, solo se hace referencia
                frm.LlenarGrid();
                //frm.dataGridView1.Rows.Insert(0, "1", txtPlacas.Text, txtModelo.Text, txtcapacidad.Text, txtnoserie.Text, txtseguro.Text);
                Close();
            }
        }

        private UnidadBLL RecuperarInformacion()
        {
            UnidadBLL unidadBLL = new UnidadBLL();
            unidadBLL.Placa = txtPlacas.Text;
            unidadBLL.Modelo = txtModelo.Text;
            unidadBLL.Seguro = txtseguro.Text;
            unidadBLL.Capacidad = txtcapacidad.Text;
            unidadBLL.numeroDeSerie = txtnoserie.Text;
            unidadBLL.Operador = txtOperador.Text;
            unidadBLL.Telefono = txtTelefono.Text;
            unidadBLL.ID = IDAux;
            return unidadBLL;
        }

        private void btneditarunidad_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                FormUnidades frm = Owner as FormUnidades;
                unidadDAL.Modificar(RecuperarInformacion());
                frm.LlenarGrid();
                Close();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtPlacas.Text) || string.IsNullOrWhiteSpace(txtPlacas.Text) || txtPlacas.Text.Count() < 3 || string.IsNullOrEmpty(txtModelo.Text) || string.IsNullOrWhiteSpace(txtModelo.Text) || txtModelo.Text.Count() < 3 || string.IsNullOrEmpty(txtcapacidad.Text) || string.IsNullOrWhiteSpace(txtcapacidad.Text) || txtcapacidad.Text.Count() < 3 || string.IsNullOrEmpty(txtnoserie.Text) || string.IsNullOrWhiteSpace(txtnoserie.Text) || txtnoserie.Text.Count() < 3 || string.IsNullOrEmpty(txtseguro.Text) || string.IsNullOrWhiteSpace(txtseguro.Text) || txtseguro.Text.Count() < 3 || string.IsNullOrEmpty(txtOperador.Text) || string.IsNullOrWhiteSpace(txtOperador.Text) || txtOperador.Text.Count() < 3 || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || txtTelefono.Text.Count() < 3)
            {
                MessageBox.Show("Por favor, llena todos los campos correctamente para continuar");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
