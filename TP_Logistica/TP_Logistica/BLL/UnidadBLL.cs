using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Logistica.BLL
{

    //Molde Unidad
    class UnidadBLL
    {
        public int ID { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Seguro { get; set; }
        public string Capacidad { get; set; }
        public string numeroDeSerie { get; set; }
        public string Operador { get; set; }
        public string Telefono { get; set; }
        //placa modelo seguro, capacidad, numero de serie, operador telefono 
    }
}
