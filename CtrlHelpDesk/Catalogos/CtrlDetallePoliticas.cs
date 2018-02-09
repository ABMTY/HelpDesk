using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlDetallePoliticas
    {
        PerDetallePoliticas PerDetallePoliticas;

        public List<detalle_politicas> Lista;

        public CtrlDetallePoliticas()
        {
            PerDetallePoliticas = new PerDetallePoliticas();
        }
        public List<detalle_politicas> ObtenerTodos()
        {
            return (List<detalle_politicas>)new PerDetallePoliticas().ObtenerTodos();
        }
        public detalle_politicas Obtener(int id_detalle_politica)
        {
            return (detalle_politicas)new PerDetallePoliticas().Obtener(id_detalle_politica);
        }

        public bool Insertar(detalle_politicas Entidad)
        {
            return PerDetallePoliticas.Insertar(Entidad);
        }

        public bool Actualizar(detalle_politicas Entidad)
        {
            return PerDetallePoliticas.Update(Entidad);
        }

        public bool Eliminar(int id_detalle_politica)
        {
            return PerDetallePoliticas.Delete(id_detalle_politica);
        }
    }
}
