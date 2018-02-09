using EntHelpDesk.Entidad;
using PerHelpDesk.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlHelpDesk.Catalogos
{
    public class CtrlPoliticas
    {
        PerPoliticas PerPoliticas;

        public List<politicas> Lista;

        public CtrlPoliticas()
        {
            PerPoliticas = new PerPoliticas();
        }
        public List<politicas> ObtenerTodos()
        {
            return (List<politicas>)new PerPoliticas().ObtenerTodos();
        }
        public politicas Obtener(int id_politica)
        {
            return (politicas)new PerPoliticas().Obtener(id_politica);
        }

        public bool Insertar(politicas Entidad)
        {
            return PerPoliticas.Insertar(Entidad);
        }

        public bool Actualizar(politicas Entidad)
        {
            return PerPoliticas.Update(Entidad);
        }

        public bool Eliminar(int id_politica)
        {
            return PerPoliticas.Delete(id_politica);
        }
    }
}
