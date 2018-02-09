using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlZonas
    {
        PerZonas PerZonas;

        public List<zonas> Lista;

        public CtrlZonas()
        {
            PerZonas = new PerZonas();
        }
        public List<zonas> ObtenerTodos()
        {
            return (List<zonas>)new PerZonas().ObtenerTodos();
        }
        public zonas Obtener(int id_zona)
        {
            return (zonas)new PerZonas().Obtener(id_zona);
        }

        public bool Insertar(zonas Entidad)
        {
            return PerZonas.Insertar(Entidad);
        }

        public bool Actualizar(zonas Entidad)
        {
            return PerZonas.Update(Entidad);
        }

        public bool Eliminar(int id_zona)
        {
            return PerZonas.Delete(id_zona);
        }
    }
}
