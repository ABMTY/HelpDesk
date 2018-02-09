using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlSucursales
    {
        PerSucursales PerSucursales;

        public List<sucursales> Lista;

        public CtrlSucursales()
        {
            PerSucursales = new PerSucursales();
        }
        public List<sucursales> ObtenerTodos()
        {
            return (List<sucursales>)new PerSucursales().ObtenerTodos();
        }
        public sucursales Obtener(int id_sucursal)
        {
            return (sucursales)new PerSucursales().Obtener(id_sucursal);
        }

        public bool Insertar(sucursales Entidad)
        {
            return PerSucursales.Insertar(Entidad);
        }

        public bool Actualizar(sucursales Entidad)
        {
            return PerSucursales.Update(Entidad);
        }

        public bool Eliminar(int id_sucursal)
        {
            return PerSucursales.Delete(id_sucursal);
        }
    }
}
