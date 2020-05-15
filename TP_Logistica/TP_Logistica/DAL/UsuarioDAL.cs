using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Logistica.BLL;
using System.Data;
using System.Data.SqlClient;

namespace TP_Logistica.DAL
{

    class UsuarioDAL
    {
        conexionDAL conexion;
        public UsuarioDAL()
        {
            conexion = new conexionDAL();
        }

        public bool Agregar(UsuarioBLL usuarioBLL)
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Usuario(NombreUsuario, Nombre, Apellido, Cargo, Foto, Password, Permisos) VALUES(@NombreUsuario,@Nombre,@Apellido,@Cargo,@Foto,@Password,@Permisos) ");//Creamos el comando
            sqlCommand.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = usuarioBLL.NombreUsuario;//Agregamos los parametros
            sqlCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = usuarioBLL.Nombre;
            sqlCommand.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = usuarioBLL.Apellido;
            sqlCommand.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = usuarioBLL.Cargo;
            sqlCommand.Parameters.Add("@Foto", SqlDbType.Image).Value = usuarioBLL.Foto;
            sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = usuarioBLL.Password;
            sqlCommand.Parameters.Add("@Permisos", SqlDbType.Int).Value = usuarioBLL.Permisos;
            return conexion.EjecutarComandoSinRetornoDatos(sqlCommand);//Ejecutamos el comando
            //return conexion.EjecutarComandoSinRetornoDatos("INSERT INTO Cliente(Empresa, Direccion, RFC, Contacto, Giro) VALUES('"+clienteBLL.Empresa+ "', '" + clienteBLL.Direccion + "', '" + clienteBLL.RFC + "', '" + clienteBLL.Contacto + "', '" + clienteBLL.Giro + "')");
        }

        public bool Eliminar(UsuarioBLL usuarioBLL)
        {
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM Usuario WHERE ID = @ID");//Creamos el comando
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = usuarioBLL.ID;//Agregamos los parametros
            return conexion.EjecutarComandoSinRetornoDatos(sqlCommand);  //Ejecutamos el comando
        }

        public bool Modificar(UsuarioBLL usuarioBLL)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE Usuario SET NombreUsuario=@NombreUsuario, Nombre=@Nombre, Apellido=@Apellido, Cargo=@Cargo, Foto=@Foto, Password=@Password, Permisos=@Permisos WHERE ID=@ID");//Creamos el comando
            sqlCommand.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = usuarioBLL.NombreUsuario;//Agregamos los parametros
            sqlCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = usuarioBLL.Nombre;
            sqlCommand.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = usuarioBLL.Apellido;
            sqlCommand.Parameters.Add("@Cargo", SqlDbType.VarChar).Value = usuarioBLL.Cargo;
            sqlCommand.Parameters.Add("@Foto", SqlDbType.Image).Value = usuarioBLL.Foto;
            sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = usuarioBLL.Password;
            sqlCommand.Parameters.Add("@Permisos", SqlDbType.Int).Value = usuarioBLL.Permisos;
            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = usuarioBLL.ID;

            //MessageBox.Show(" "+clienteBLL.ID +clienteBLL.Empresa+clienteBLL.Direccion);
            return conexion.EjecutarComandoSinRetornoDatos(sqlCommand);//Ejecutamos el comando

        }

        public DataSet MostrarUsuarios()
        {
            SqlCommand sentencia = new SqlCommand("SELECT Usuario.ID,NombreUsuario,Nombre,Apellido,Cargo,Foto,Permisos.Tipo,Password FROM Usuario inner join Permisos ON Usuario.Permisos = Permisos.ID");//Se crea el comanto
            return conexion.EjecutarSentencia(sentencia);//Se ejecuta la sentencia
        }





    }
}
