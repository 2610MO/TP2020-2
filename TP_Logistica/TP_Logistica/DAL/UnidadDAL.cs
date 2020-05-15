using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TP_Logistica.BLL;

namespace TP_Logistica.DAL
{
    class UnidadDAL
    {
        conexionDAL conexion;


        //Constructor de la clase
        public UnidadDAL()
        {
            conexion = new conexionDAL();
        }

        //Metodo CRUD CREATE
        public bool Agregar(UnidadBLL unidadBLL)
        {

            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Unidad(placa, modelo, seguro, capacidad, numero_serie, operador, telefono) VALUES(@placa,@modelo,@seguro,@capacidad,@numero_serie,@operador,@telefono) ");//Creamos el comando
            sqlCommand.Parameters.Add("@placa", SqlDbType.VarChar).Value = unidadBLL.Placa;//Agregamos los parametros
            sqlCommand.Parameters.Add("@modelo", SqlDbType.VarChar).Value = unidadBLL.Modelo;
            sqlCommand.Parameters.Add("@seguro", SqlDbType.VarChar).Value = unidadBLL.Seguro;
            sqlCommand.Parameters.Add("@capacidad", SqlDbType.VarChar).Value = unidadBLL.Capacidad;
            sqlCommand.Parameters.Add("@numero_serie", SqlDbType.VarChar).Value = unidadBLL.numeroDeSerie;
            sqlCommand.Parameters.Add("@operador", SqlDbType.VarChar).Value = unidadBLL.Operador;
            sqlCommand.Parameters.Add("@telefono", SqlDbType.VarChar).Value = unidadBLL.Telefono;
            return conexion.EjecutarComandoSinRetornoDatos(sqlCommand);//Ejecutamos el comando

            //return conexion.EjecutarComandoSinRetornoDatos("INSERT INTO Cliente(Empresa, Direccion, RFC, Contacto, Giro) VALUES('"+clienteBLL.Empresa+ "', '" + clienteBLL.Direccion + "', '" + clienteBLL.RFC + "', '" + clienteBLL.Contacto + "', '" + clienteBLL.Giro + "')");
        }


        //Metodo CRUD DELETE
        public bool Eliminar(UnidadBLL unidadBLL)
        {

            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Unidad WHERE ID = @ID");//Creamos el comando
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = unidadBLL.ID;//Agregamos los parametros
            return conexion.EjecutarComandoSinRetornoDatos(sqlCommand);  //Ejecutamos el comando

        }

    


        //Metodo CRUD UPDATE 
        public bool Modificar(UnidadBLL unidadBLL)
        {
            
            SqlCommand sqlCommand = new SqlCommand("UPDATE Unidad SET placa=@placa, seguro=@seguro, capacidad=@capacidad, numero_serie=@numero_serie, operador=@operador, telefono=@telefono WHERE ID=@ID");//Creamos el comando
            sqlCommand.Parameters.Add("@placa", SqlDbType.VarChar).Value = unidadBLL.Placa;//Agregamos los parametros
            sqlCommand.Parameters.Add("@seguro", SqlDbType.VarChar).Value = unidadBLL.Seguro;
            sqlCommand.Parameters.Add("@capacidad", SqlDbType.VarChar).Value = unidadBLL.Capacidad;
            sqlCommand.Parameters.Add("@numero_serie", SqlDbType.VarChar).Value = unidadBLL.numeroDeSerie;
            sqlCommand.Parameters.Add("@operador", SqlDbType.VarChar).Value = unidadBLL.Operador;
            sqlCommand.Parameters.Add("@modelo", SqlDbType.VarChar).Value = unidadBLL.Modelo;
            sqlCommand.Parameters.Add("@telefono", SqlDbType.VarChar).Value = unidadBLL.Telefono;
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = unidadBLL.ID;

            //MessageBox.Show(" "+clienteBLL.ID +clienteBLL.Empresa+clienteBLL.Direccion);
            
            return conexion.EjecutarComandoSinRetornoDatos(sqlCommand);//Ejecutamos el comando
            

        }


        //Metodo CRUD READ

        public DataSet MostrarUnidades()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Unidad");//Se crea el comanto
            return conexion.EjecutarSentencia(sentencia);//Se ejecuta la sentencia
        }



    }

}

