using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlTipoSoporte
    {
        PerTipoSoporte PerTipoSoporte;

        public List<tipo_soporte> Lista;

        public CtrlTipoSoporte()
        {
            PerTipoSoporte = new PerTipoSoporte();
        }
        public List<tipo_soporte> ObtenerTodos()
        {
            return (List<tipo_soporte>)new PerTipoSoporte().ObtenerTodos();
        }
        public tipo_soporte Obtener(int id_tipo_soporte)
        {
            return (tipo_soporte)new PerTipoSoporte().Obtener(id_tipo_soporte);
        }

        public bool Insertar(tipo_soporte Entidad)
        {
            return PerTipoSoporte.Insertar(Entidad);
        }

        public bool Actualizar(tipo_soporte Entidad)
        {
            return PerTipoSoporte.Update(Entidad);
        }

        public bool Eliminar(int id_tipo_soporte)
        {
            return PerTipoSoporte.Delete(id_tipo_soporte);
        }
    }
}
