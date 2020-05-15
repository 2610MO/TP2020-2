using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TP_Logistica.DAL
{
    class PermisosDAL
    {

        public PermisosDAL()
        {
            conexion = new conexionDAL();
        }
        conexionDAL conexion;
        public DataSet MostrarPermisos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Permisos");//Se crea el comanto
            return conexion.EjecutarSentencia(sentencia);//Se ejecuta la sentencia
        }
    }
}
