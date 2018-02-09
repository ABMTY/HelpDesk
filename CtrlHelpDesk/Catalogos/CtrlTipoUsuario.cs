using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlTipoUsuario
    {
        PerTipoUsuario PerTipoUsuario;

        public List<tipo_usuario> Lista;

        public CtrlTipoUsuario()
        {
            PerTipoUsuario = new PerTipoUsuario();
        }
        public List<tipo_usuario> ObtenerTodos()
        {
            return (List<tipo_usuario>)new PerTipoUsuario().ObtenerTodos();
        }
        public tipo_usuario Obtener(int id_tipo_usuario)
        {
            return (tipo_usuario)new PerTipoUsuario().Obtener(id_tipo_usuario);
        }

        public bool Insertar(tipo_usuario Entidad)
        {
            return PerTipoUsuario.Insertar(Entidad);
        }

        public bool Actualizar(tipo_usuario Entidad)
        {
            return PerTipoUsuario.Update(Entidad);
        }

        public bool Eliminar(int id_tipo_usuario)
        {
            return PerTipoUsuario.Delete(id_tipo_usuario);
        }
    }
}
