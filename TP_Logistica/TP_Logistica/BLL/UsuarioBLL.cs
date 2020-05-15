using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace TP_Logistica.BLL
{
    class UsuarioBLL
    {
        public int ID { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cargo { get; set; }
        public byte[] Foto { get; set; }
        public string Password { get; set; }
        public int Permisos { get; set; }
    }
}
