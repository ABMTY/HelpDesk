using EntHelpDesk.Entidad;
using PerHelpDesk.Sevicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Servicios
{
    public class CtrlDetalleTicket
    {
        PerDetalleTicket PerDetalleTicket;

        public List<detalle_ticket> Lista;

        public CtrlDetalleTicket()
        {
            PerDetalleTicket = new PerDetalleTicket();
        }
        public List<detalle_ticket> ObtenerTodos()
        {
            return (List<detalle_ticket>)new PerDetalleTicket().ObtenerTodos();
        }
        public detalle_ticket Obtener(int id_detalle_ticket)
        {
            return (detalle_ticket)new PerDetalleTicket().Obtener(id_detalle_ticket);
        }

        public bool Insertar(detalle_ticket Entidad)
        {
            return PerDetalleTicket.Insertar(Entidad);
        }

        public bool Actualizar(detalle_ticket Entidad)
        {
            return PerDetalleTicket.Update(Entidad);
        }

        public bool Eliminar(int id_detalle_ticket)
        {
            return PerDetalleTicket.Delete(id_detalle_ticket);
        }
    }
}
