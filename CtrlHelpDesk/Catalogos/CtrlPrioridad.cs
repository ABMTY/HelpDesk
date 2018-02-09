using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlPrioridad
    {
        PerPrioridad PerPrioridad;

        public List<prioridad> Lista;

        public CtrlPrioridad()
        {
            PerPrioridad = new PerPrioridad();
        }
        public List<prioridad> ObtenerTodos()
        {
            return (List<prioridad>)new PerPrioridad().ObtenerTodos();
        }
        public prioridad Obtener(int id_prioridad)
        {
            return (prioridad)new PerPrioridad().Obtener(id_prioridad);
        }

        public bool Insertar(prioridad Entidad)
        {
            return PerPrioridad.Insertar(Entidad);
        }

        public bool Actualizar(prioridad Entidad)
        {
            return PerPrioridad.Update(Entidad);
        }

        public bool Eliminar(int id_prioridad)
        {
            return PerPrioridad.Delete(id_prioridad);
        }
    }
}
