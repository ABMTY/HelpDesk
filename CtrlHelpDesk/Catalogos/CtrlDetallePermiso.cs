using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlDetallePermiso
    {
        PerDetallePermiso PerDetallePermiso;

        public List<detalle_permiso> Lista;

        public CtrlDetallePermiso()
        {
            PerDetallePermiso = new PerDetallePermiso();
        }
        public List<detalle_permiso> ObtenerTodos()
        {
            return (List<detalle_permiso>)new PerDetallePermiso().ObtenerTodos();
        }
        public detalle_permiso Obtener(int id_detalle_permiso)
        {
            return (detalle_permiso)new PerDetallePermiso().Obtener(id_detalle_permiso);
        }

        public bool Insertar(detalle_permiso Entidad)
        {
            return PerDetallePermiso.Insertar(Entidad);
        }

        public bool Actualizar(detalle_permiso Entidad)
        {
            return PerDetallePermiso.Update(Entidad);
        }

        public bool Eliminar(int id_detalle_permiso)
        {
            return PerDetallePermiso.Delete(id_detalle_permiso);
        }
    }
}
