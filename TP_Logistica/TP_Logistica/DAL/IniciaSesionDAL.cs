using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TP_Logistica.BLL;
using System.Windows.Forms;
using TP_Logistica.PL;
using System.Security.Cryptography.X509Certificates;
using Proyecto_Logistica;

namespace TP_Logistica.DAL
{
    class IniciaSesionDAL
    {

        conexionDAL conexion;
        UsuarioBLL usuarioBLL;
        
        public IniciaSesionDAL()
        {
            usuarioBLL = new UsuarioBLL();
            conexion = new conexionDAL();
        }
        public UsuarioBLL ValidarUsuario(string usuario, string pass)
        {

            conexion.EstablecerConexion().Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario=@NombreUsuario AND Password=@Password",conexion.EstablecerConexion());     
            //Se crea el comanto            
            sqlCommand.Parameters.Add("@NombreUsuario", SqlDbType.VarChar).Value = usuario;           
            sqlCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = pass;
            SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count==1)
            {
                
                usuarioBLL.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                usuarioBLL.NombreUsuario = dt.Rows[0]["NombreUsuario"].ToString();
                usuarioBLL.Nombre = dt.Rows[0]["Nombre"].ToString();
                usuarioBLL.Apellido = dt.Rows[0]["Apellido"].ToString();
                usuarioBLL.Cargo = dt.Rows[0]["Cargo"].ToString();
                usuarioBLL.Foto = (byte[])dt.Rows[0]["Foto"];
                usuarioBLL.Permisos = int.Parse(dt.Rows[0]["Permisos"].ToString());

                return usuarioBLL;   
            }

            return usuarioBLL;

             //Se ejecuta la sentencia
        }



    }
}
