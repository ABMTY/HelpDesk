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
    public class PerTickets : Persistencia
    {
        public List<tickets> ObtenerTodos()
        {
            List<tickets> lista = new List<tickets>();
            tickets entidad = new tickets();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Tickets";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new tickets();
                        entidad.id_ticket = int.Parse(dr["id_ticket"].ToString());
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        entidad.usuario = dr["usuario"].ToString();
                        if (dr["foto_usuario"].ToString() != string.Empty)
                            entidad.foto_usuario = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["foto_usuario"]);
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.sucursal = dr["sucursal"].ToString();
                        entidad.asunto = dr["asunto"].ToString();
                        entidad.descripcion = dr["descripcion"].ToString();
                        if (dr["imagen"].ToString() != string.Empty)
                            entidad.imagen = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["imagen"]);
                        entidad.fechahora_creacion = dr["fechahora_creacion"].ToString();
                        entidad.estado = dr["estado"].ToString();
                        entidad.agente = dr["agente"].ToString();
                        if (dr["foto_agente"].ToString() != string.Empty)
                            entidad.foto_agente = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["foto_agente"]);
                        entidad.id_detalle_ticket = int.Parse(dr["id_detalle_ticket"].ToString());
                        entidad.id_prioridad = int.Parse(dr["id_prioridad"].ToString());
                        entidad.prioridad = dr["prioridad"].ToString();
                        lista.Add(entidad);
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tickets";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tickets";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return lista;
        }
        public tickets Obtener(int id)
        {
            tickets entidad = new tickets();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Tickets";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                comandoSelect.Parameters.AddWithValue("@IdTicket", id);
                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad.id_ticket = int.Parse(dr["id_ticket"].ToString());
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        entidad.usuario = dr["usuario"].ToString();
                        if (dr["foto_usuario"].ToString() != string.Empty)
                            entidad.foto_usuario = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["foto_usuario"]);
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.sucursal = dr["sucursal"].ToString();
                        entidad.asunto = dr["asunto"].ToString();
                        entidad.descripcion = dr["descripcion"].ToString();
                        if (dr["imagen"].ToString() != string.Empty)
                            entidad.imagen = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["imagen"]);
                        
                        entidad.fechahora_creacion = dr["fechahora_creacion"].ToString();
                        entidad.estado = dr["estado"].ToString();
                        entidad.agente = dr["agente"].ToString();
                        if (dr["foto_agente"].ToString() != string.Empty)
                            entidad.foto_agente = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["foto_agente"]);
                        entidad.id_detalle_ticket = int.Parse(dr["id_detalle_ticket"].ToString());
                        entidad.id_prioridad = int.Parse(dr["id_prioridad"].ToString());
                        entidad.prioridad = dr["prioridad"].ToString();
                        
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tickets";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tickets";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;
        }
        public tickets ObtenerPorUsuario(int id)
        {
            tickets entidad = new tickets();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Tickets";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                comandoSelect.Parameters.AddWithValue("@IdUsuario", id);
                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad.id_ticket = int.Parse(dr["id_ticket"].ToString());
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        entidad.usuario = dr["usuario"].ToString();
                        if (dr["foto_usuario"].ToString() != string.Empty)
                            entidad.foto_usuario = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["foto_usuario"]);
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.sucursal = dr["sucursal"].ToString();
                        entidad.asunto = dr["asunto"].ToString();
                        entidad.descripcion = dr["descripcion"].ToString();
                        if (dr["imagen"].ToString() != string.Empty)
                            entidad.imagen = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["imagen"]);

                        entidad.fechahora_creacion = dr["fechahora_creacion"].ToString();
                        entidad.estado = dr["estado"].ToString();
                        entidad.agente = dr["agente"].ToString();
                        if (dr["foto_agente"].ToString() != string.Empty)
                            entidad.foto_agente = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["foto_agente"]);
                        entidad.id_detalle_ticket = int.Parse(dr["id_detalle_ticket"].ToString());
                        entidad.id_prioridad = int.Parse(dr["id_prioridad"].ToString());
                        entidad.prioridad = dr["prioridad"].ToString();
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tickets";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tickets";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;
        }
        public bool Insertar(tickets entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Tickets";
                cmd.Parameters.AddWithValue("@Sentencia", "Insert");
                cmd.Parameters.AddWithValue("@IdTicket", entidad.id_ticket);
                cmd.Parameters.AddWithValue("@IdUsuario", entidad.id_usuario);
                cmd.Parameters.AddWithValue("@IdSucursal", entidad.id_sucursal);
                cmd.Parameters.AddWithValue("@asunto", entidad.asunto);
                cmd.Parameters.AddWithValue("@descripcion", entidad.descripcion);
                cmd.Parameters.AddWithValue("@imagen", entidad.imagen);                
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tickets";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tickets";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
                cmd = null;
            }
            return respuesta;
        }        
        public bool Update(tickets entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Tickets";
                cmd.Parameters.AddWithValue("@Sentencia", "Update");
                cmd.Parameters.AddWithValue("@IdTicket", entidad.id_ticket);
                cmd.Parameters.AddWithValue("@IdUsuario", entidad.id_usuario);
                cmd.Parameters.AddWithValue("@IdSucursal", entidad.id_sucursal);
                cmd.Parameters.AddWithValue("@asunto", entidad.asunto);
                cmd.Parameters.AddWithValue("@descripcion", entidad.descripcion);
                cmd.Parameters.AddWithValue("@imagen", entidad.imagen);                
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tickets";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tickets";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
                cmd = null;
            }
            return respuesta;
        }
        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Tickets";
                cmd.Parameters.AddWithValue("@Sentencia", "Delete");
                cmd.Parameters.AddWithValue("@IdTicket", id);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete tickets";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete tickets";
                return respuesta;
            }
            finally
            {
                CerrarConexion();
                cmd = null;
            }
            return respuesta;
        }
    }
}
