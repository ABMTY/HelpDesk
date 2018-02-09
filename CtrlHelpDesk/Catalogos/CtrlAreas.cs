using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlAreas
    {
        PerAreas PerAreas;

        public List<areas> Lista;

        public CtrlAreas()
        {
            PerAreas = new PerAreas();
        }
        public List<areas> ObtenerTodos()
        {
            return (List<areas>)new PerAreas().ObtenerTodos();
        }
        public areas Obtener(int id_area)
        {
            return (areas)new PerAreas().Obtener(id_area);
        }

        public bool Insertar(areas Entidad)
        {
            return PerAreas.Insertar(Entidad);
        }

        public bool Actualizar(areas Entidad)
        {
            return PerAreas.Update(Entidad);
        }

        public bool Eliminar(int id_area)
        {
            return PerAreas.Delete(id_area);
        }
    }
}
