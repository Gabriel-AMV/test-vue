using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_vue.Models
{
    public class Permisos
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public DateTime Fecha { get; set; }

        public int TipoPermisoId { get; set; }
        public TipoPermiso TipoPermiso { get; set; }
    }
}
