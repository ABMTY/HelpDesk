using EntHelpDesk.Entidad;
using PerHelpDesk.Sevicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Servicios
{
    public class CtrlTickets
    {
        PerTickets PerTickets;

        public List<tickets> Lista;

        public CtrlTickets()
        {
            PerTickets = new PerTickets();
        }
        public List<tickets> ObtenerTodos()
        {
            return (List<tickets>)new PerTickets().ObtenerTodos();
        }
        public tickets Obtener(int id_tickets)
        {
            return (tickets)new PerTickets().Obtener(id_tickets);
        }

        public bool Insertar(tickets Entidad)
        {
            return PerTickets.Insertar(Entidad);
        }

        public bool Actualizar(tickets Entidad)
        {
            return PerTickets.Update(Entidad);
        }

        public bool Eliminar(int id_tickets)
        {
            return PerTickets.Delete(id_tickets);
        }
    }
}
