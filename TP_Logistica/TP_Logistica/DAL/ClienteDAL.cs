using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TP_Logistica.BLL;
using System.Windows.Forms;

namespace TP_Logistica.DAL
{
    class ClienteDAL
    {
        conexionDAL conexion;


        //Constructor de la clase
        public ClienteDAL()
        {
            conexion = new conexionDAL();
        }

        //Metodo CRUD CREATE
        public bool Agregar(ClienteBLL clienteBLL)
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Cliente(Empresa, Direccion, RFC, Contacto, Giro) VALUES(@Empresa,@Direccion,@RFC,@Contacto,@Giro) ");//Creamos el comando
            sqlCommand.Parameters.Add("@Empresa", SqlDbType.VarChar).Value = clienteBLL.Empresa;//Agregamos los parametros
            sqlCommand.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = clienteBLL.Direccion;
            sqlCommand.Parameters.Add("@RFC", SqlDbType.VarChar).Value = clienteBLL.RFC;
            sqlCommand.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = clienteBLL.Contacto;
            sqlCommand.Parameters.Add("@Giro", SqlDbType.VarChar).Value = clienteBLL.Giro;
            return conexion.EjecutarComandoSinRetornoDatos(sqlCommand);//Ejecutamos el comando
            //return conexion.EjecutarComandoSinRetornoDatos("INSERT INTO Cliente(Empresa, Direccion, RFC, Contacto, Giro) VALUES('"+clienteBLL.Empresa+ "', '" + clienteBLL.Direccion + "', '" + clienteBLL.RFC + "', '" + clienteBLL.Contacto + "', '" + clienteBLL.Giro + "')");
        }


        //Metodo CRUD DELETE
        public bool Eliminar(ClienteBLL clienteBLL)
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Cliente WHERE ID = @ID");//Creamos el comando
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = clienteBLL.ID;//Agregamos los parametros
            return conexion.EjecutarComandoSinRetornoDatos(sqlCommand);  //Ejecutamos el comando
        }


        //Metodo CRUD UPDATE 
        public bool Modificar(ClienteBLL clienteBLL)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE Cliente SET Empresa=@Empresa, Direccion=@Direccion, RFC=@RFC, Contacto=@Contacto, Giro=@Giro WHERE ID=@ID");//Creamos el comando
            sqlCommand.Parameters.Add("@Empresa", SqlDbType.VarChar).Value = clienteBLL.Empresa;//Agregamos los parametros
            sqlCommand.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = clienteBLL.Direccion;
            sqlCommand.Parameters.Add("@RFC", SqlDbType.VarChar).Value = clienteBLL.RFC;
            sqlCommand.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = clienteBLL.Contacto;
            sqlCommand.Parameters.Add("@Giro", SqlDbType.VarChar).Value = clienteBLL.Giro;
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = clienteBLL.ID;

            //MessageBox.Show(" "+clienteBLL.ID +clienteBLL.Empresa+clienteBLL.Direccion);
            return conexion.EjecutarComandoSinRetornoDatos(sqlCommand);//Ejecutamos el comando

        }


        //Metodo CRUD READ

        public DataSet MostrarClientes()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Cliente");//Se crea el comanto
            return conexion.EjecutarSentencia(sentencia);//Se ejecuta la sentencia
        }



    }
}
