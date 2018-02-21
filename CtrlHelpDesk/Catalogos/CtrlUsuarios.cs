using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlUsuarios
    {
        PerUsuarios PerUsuarios;
        PerTipoUsuario PerTipoUsuario;

        public List<usuarios> Lista;

        public CtrlUsuarios()
        {
            PerUsuarios = new PerUsuarios();
        }
        public List<usuarios> ObtenerTodos()
        {
            return (List<usuarios>)new PerUsuarios().ObtenerTodos();
        }
        public usuarios Obtener(int id_usuario)
        {
            usuarios entidad = new usuarios();
            entidad = (usuarios)new PerUsuarios().Obtener(id_usuario);
            PerTipoUsuario = new PerTipoUsuario();
            entidad.ent_tipo_usuario = PerTipoUsuario.Obtener(entidad.id_tipo_usuario);
                        
            return entidad;
        }

        public bool Insertar(usuarios Entidad)
        {
            return PerUsuarios.Insertar(Entidad);
        }

        public bool Actualizar(usuarios Entidad)
        {
            return PerUsuarios.Update(Entidad);
        }

        public bool Eliminar(int id_usuario)
        {
            return PerUsuarios.Delete(id_usuario);
        }
    }
}
