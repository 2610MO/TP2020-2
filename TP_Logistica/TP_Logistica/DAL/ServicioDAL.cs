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
    class ServicioDAL
    {

        conexionDAL conexion;


        //Constructor de la clase
        public ServicioDAL()
        {
            conexion = new conexionDAL();
        }

        //Metodo CRUD CREATE
        public bool Agregar(ServicioBLL servicioBLL)
        {
            //MessageBox.Show("AQUIIIIII" + servicioBLL.IDCliente + servicioBLL.IDUnidad + servicioBLL.Origen + servicioBLL.CV);


            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Servicio(id_Cliente, id_Unidad, origen, cv) VALUES(@id_Cliente,@id_Unidad,@origen,@cv)");//Creamos el comando
            //sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = servicioBLL.ID;//Agregamos los parametros
            sqlCommand.Parameters.Add("@id_Cliente", SqlDbType.Int).Value = servicioBLL.IDCliente;
            sqlCommand.Parameters.Add("@id_Unidad", SqlDbType.Int).Value = servicioBLL.IDUnidad;
            sqlCommand.Parameters.Add("@origen", SqlDbType.VarChar).Value = servicioBLL.Origen;
            sqlCommand.Parameters.Add("@cv", SqlDbType.VarChar).Value = servicioBLL.CV;
           
            return conexion.EjecutarComandoSinRetornoDatos(sqlCommand);//Ejecutamos el comando

            //return conexion.EjecutarComandoSinRetornoDatos("INSERT INTO Cliente(Empresa, Direccion, RFC, Contacto, Giro) VALUES('"+clienteBLL.Empresa+ "', '" + clienteBLL.Direccion + "', '" + clienteBLL.RFC + "', '" + clienteBLL.Contacto + "', '" + clienteBLL.Giro + "')");
        }


        //Metodo CRUD DELETE
        public bool Eliminar(ServicioBLL servicioBL)
        {

            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Servicio WHERE id = @ID");//Creamos el comando
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = servicioBL.ID;//Agregamos los parametros
            return conexion.EjecutarComandoSinRetornoDatos(sqlCommand);  //Ejecutamos el comando

        }




        //Metodo CRUD UPDATE 
        public bool Modificar(ServicioBLL servicioBLL)
        {

            SqlCommand sqlCommand = new SqlCommand("UPDATE Servicio SET id_Cliente=@id_Cliente, id_Unidad=@id_Unidad, origen=@origen, cv=@cv WHERE id=@ID");//Creamos el comando
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = servicioBLL.ID;//Agregamos los parametros
            sqlCommand.Parameters.Add("@id_Unidad", SqlDbType.Int).Value = servicioBLL.IDUnidad;
            sqlCommand.Parameters.Add("@id_Cliente", SqlDbType.Int).Value = servicioBLL.IDCliente;
            sqlCommand.Parameters.Add("@origen", SqlDbType.VarChar).Value = servicioBLL.Origen;
            sqlCommand.Parameters.Add("@cv", SqlDbType.VarChar).Value = servicioBLL.CV;
            

            //MessageBox.Show(" "+clienteBLL.ID +clienteBLL.Empresa+clienteBLL.Direccion);

            return conexion.EjecutarComandoSinRetornoDatos(sqlCommand);//Ejecutamos el comando


        }


        //Metodo CRUD READ

        public DataSet MostrarServicios()
        {
            SqlCommand sentencia = new SqlCommand("SELECT  Servicio.id, cv, placa,Empresa,origen,Direccion,operador,Unidad.telefono FROM Servicio inner join Cliente ON Servicio.id_Cliente = Cliente.ID inner join Unidad ON Servicio.id_Unidad = Unidad.id");//Se crea el comanto
            return conexion.EjecutarSentencia(sentencia);//Se ejecuta la sentencia
        }



    }


}
