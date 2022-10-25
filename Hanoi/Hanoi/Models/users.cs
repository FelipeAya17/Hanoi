using System;
using System.Collections.Generic;
using System.Text;

namespace Hanoi.Models
{
    public class Users
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public int idTipo_documento { get; set; }
        public int numero_documento { get; set; }
        public string direccion { get; set; }
        public string password { get; set; }
        public string confirmar_pass { get; set; }
    }

}
