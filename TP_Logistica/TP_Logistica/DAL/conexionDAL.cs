using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace TP_Logistica.DAL
{
    class conexionDAL
    {

        //Cadena de conexion, datos de la base y servidor al que nos conectaremos, configuracion de la base
        private string CadenaConexion = "Data Source=LUISMORELOS9E74\\SQLEXPRESS; Initial Catalog =db_tp2020; Integrated Security =True";
        SqlConnection conexion;

        //Metodo que establece la conecion con la base y devuelve un sqlConnection
        public SqlConnection EstablecerConexion()
        {
            this.conexion = new SqlConnection(this.CadenaConexion);
            return this.conexion;

        }


        //Metodo para comandos de consola SQL con string para la creacion del CRUD, devuelve un booleano
        public bool EjecutarComandoSinRetornoDatos(string strComando)
        {
            try
            {
                
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;     
                Comando.Connection = this.EstablecerConexion();
                conexion.Open();
                Comando.ExecuteNonQuery();
                conexion.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }
        //Sobrecarga del metodo para aceptar datos tipo SqlCommand
        public bool EjecutarComandoSinRetornoDatos(SqlCommand SQLComando)
        {
            try
            {

                SqlCommand Comando = SQLComando;
                Comando.Connection = this.EstablecerConexion();
                conexion.Open();
                Comando.ExecuteNonQuery();
                conexion.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }









        //Metodo para comandos de SQL.Componente para retorno de una DATASET que despues se usara para pintar el datagridView con la informacion de la base
        public DataSet EjecutarSentencia(SqlCommand sqlCommando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlCommando;
                Comando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = Comando;
                conexion.Open();
                Adaptador.Fill(DS);
                conexion.Close();
                return DS;

            }
            catch
            {
                return DS;
            }
        }
    }
}
