using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlEstado
    {
        PerEstado PerEstado;

        public List<estado> Lista;

        public CtrlEstado()
        {
            PerEstado = new PerEstado();
        }
        public List<estado> ObtenerTodos()
        {
            return (List<estado>)new PerEstado().ObtenerTodos();
        }
        public List<estado> ObtenerFiltro(int id)
        {
            return (List<estado>)new PerEstado().ObtenerSig(id);
        }
        public estado Obtener(int id_estado)
        {
            return (estado)new PerEstado().Obtener(id_estado);
        }

        public bool Insertar(estado Entidad)
        {
            return PerEstado.Insertar(Entidad);
        }

        public bool Actualizar(estado Entidad)
        {
            return PerEstado.Update(Entidad);
        }

        public bool Eliminar(int id_estado)
        {
            return PerEstado.Delete(id_estado);
        }
    }
}
