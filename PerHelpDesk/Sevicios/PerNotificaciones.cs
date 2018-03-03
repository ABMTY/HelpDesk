using EntHelpDesk.Entidad;
using PerHelpDesk.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerHelpDesk.Sevicios
{
    public class PerNotificaciones : Persistencia
    {
        public List<notificaciones> ObtenerTodos()
        {
            List<notificaciones> lista = new List<notificaciones>();
            notificaciones entidad = new notificaciones();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.Text;
                comandoSelect.CommandText = "  SELECT [id_notificacion],[id_ticket],[fecha],[dbo].[usuarios].[id_usuario],[notificado],[asunto],[estado],[tipo_notificacion],[foto],"
                            + " [dbo].[usuarios].[nombre]  FROM[dbo].[notificaciones] left join[dbo].[usuarios]"
                            + " on[dbo].[notificaciones].id_usuario= [dbo].[usuarios].id_usuario"
                            + " where  notificado is null ";

                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new notificaciones();
                        entidad.id_notificacion = int.Parse(dr["id_notificacion"].ToString());
                        entidad.id_ticket = int.Parse(dr["id_ticket"].ToString());
                        entidad.asunto = dr["asunto"].ToString();
                        entidad.fecha = DateTime.Parse(dr["fecha"].ToString());
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        if(dr["notificado"].ToString()!=string.Empty)
                            entidad.notificado = int.Parse(dr["notificado"].ToString());
                        entidad.estado = dr["estado"].ToString();
                        entidad.tipo_notificacion = dr["tipo_notificacion"].ToString();
                        if (dr["foto"].ToString() != string.Empty)
                            entidad.foto = Convert.ToBase64String((byte[])dr["foto"]);
                        entidad.nombre = dr["nombre"].ToString();
                        lista.Add(entidad);
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar notificaciones";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar notificaciones";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return lista;
        }

        public List<notificaciones> ObtenerPorUsuario(int id)
        {
            List<notificaciones> lista = new List<notificaciones>();
            notificaciones entidad = new notificaciones();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.Text;
                comandoSelect.CommandText = "  SELECT [id_notificacion],[id_ticket],[fecha],[dbo].[usuarios].[id_usuario],[notificado],[asunto],[estado],[tipo_notificacion],[foto],"
                                            + " [dbo].[usuarios].[nombre]  FROM[dbo].[notificaciones] left join[dbo].[usuarios]"
                                            + " on[dbo].[notificaciones].id_usuario= [dbo].[usuarios].id_usuario"
                                            + " where  notificado is null and [dbo].[notificaciones].[id_usuario] =@IdUsuario ";

                comandoSelect.Parameters.AddWithValue("@IdUsuario", id);

                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new notificaciones();
                        entidad.id_notificacion = int.Parse(dr["id_notificacion"].ToString());
                        entidad.id_ticket = int.Parse(dr["id_ticket"].ToString());
                        entidad.asunto = dr["asunto"].ToString();
                        entidad.fecha = DateTime.Parse(dr["fecha"].ToString());
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        if (dr["notificado"].ToString() != string.Empty)
                            entidad.notificado = int.Parse(dr["notificado"].ToString());
                        entidad.estado = dr["estado"].ToString();
                        entidad.tipo_notificacion = dr["tipo_notificacion"].ToString();
                        if (dr["foto"].ToString() != string.Empty)
                            entidad.foto = Convert.ToBase64String((byte[])dr["foto"]);
                        entidad.nombre = dr["nombre"].ToString();
                        lista.Add(entidad);
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar notificaciones";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar notificaciones";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return lista;
        }
    }
}
