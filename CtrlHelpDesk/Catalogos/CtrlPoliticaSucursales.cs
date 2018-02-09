using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlPoliticaSucursales
    {
        PerPoliticaSucursales PerPoliticaSucursales;

        public List<politica_sucursales> Lista;

        public CtrlPoliticaSucursales()
        {
            PerPoliticaSucursales = new PerPoliticaSucursales();
        }
        public List<politica_sucursales> ObtenerTodos()
        {
            return (List<politica_sucursales>)new PerPoliticaSucursales().ObtenerTodos();
        }
        public politica_sucursales Obtener(int id_politica_sucursale)
        {
            return (politica_sucursales)new PerPoliticaSucursales().Obtener(id_politica_sucursale);
        }

        public bool Insertar(politica_sucursales Entidad)
        {
            return PerPoliticaSucursales.Insertar(Entidad);
        }

        public bool Actualizar(politica_sucursales Entidad)
        {
            return PerPoliticaSucursales.Update(Entidad);
        }

        public bool Eliminar(int id_politica_sucursale)
        {
            return PerPoliticaSucursales.Delete(id_politica_sucursale);
        }
    }
}
