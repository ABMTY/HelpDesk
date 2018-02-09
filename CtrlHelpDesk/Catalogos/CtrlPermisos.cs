using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlPermisos
    {
        PerPermisos PerPermisos;

        public List<permisos> Lista;

        public CtrlPermisos()
        {
            PerPermisos = new PerPermisos();
        }
        public List<permisos> ObtenerTodos()
        {
            return (List<permisos>)new PerPermisos().ObtenerTodos();
        }
        public permisos Obtener(int id_permiso)
        {
            return (permisos)new PerPermisos().Obtener(id_permiso);
        }

        public bool Insertar(permisos Entidad)
        {
            return PerPermisos.Insertar(Entidad);
        }

        public bool Actualizar(permisos Entidad)
        {
            return PerPermisos.Update(Entidad);
        }

        public bool Eliminar(int id_permiso)
        {
            return PerPermisos.Delete(id_permiso);
        }
    }
}
