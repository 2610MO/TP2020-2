using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Logistica.BLL
{

    //Molde Cliente
    class ClienteBLL
    {
        public int ID { get; set; }
        public string Empresa { get; set; }
        public string Direccion { get; set; }
        public string RFC { get; set; }
        public string Contacto { get; set; }
        public string Giro { get; set; }

        //id empresa direccion rfc contacto giro
    }
}
