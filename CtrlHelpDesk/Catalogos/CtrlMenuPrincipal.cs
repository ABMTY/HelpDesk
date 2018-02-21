using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlMenuPrincipal
    {
        PerMenuPrincipal PerMenuPrincipal;

        public List<menu_principal> Lista;

        public CtrlMenuPrincipal()
        {
            PerMenuPrincipal = new PerMenuPrincipal();
        }
        public List<menu_principal> ObtenerTodos()
        {
            return (List<menu_principal>)new PerMenuPrincipal().ObtenerTodos();
        }
        public menu_principal Obtener(int id_menu_principal)
        {
            return (menu_principal)new PerMenuPrincipal().Obtener(id_menu_principal);
        }

        public bool Insertar(menu_principal Entidad)
        {
            return PerMenuPrincipal.Insertar(Entidad);
        }

        public bool Actualizar(menu_principal Entidad)
        {
            return PerMenuPrincipal.Update(Entidad);
        }

        public bool Eliminar(int id_menu_principal)
        {
            return PerMenuPrincipal.Delete(id_menu_principal);
        }
    }
}
