using EntHelpDesk.Entidad;
using PerHelpDesk.Sevicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public int ObtenerMax()
        {
            return (int)new PerTickets().ObtenerMax();
        }
        public tickets Obtener(int id_tickets)
        {
            return (tickets)new PerTickets().Obtener(id_tickets);
        }
        public List<tickets> ObtenerPorUsuario(int id_usuario)
        {
            return (List<tickets>)new PerTickets().ObtenerPorUsuario(id_usuario);
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

        public SqlCommand ObtenerCommand()
        {
            return PerTickets.ObtenerCommand();
        }
    }
}
