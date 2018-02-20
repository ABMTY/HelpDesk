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
    public class PerDetalleTicket : Persistencia
    {
        public List<detalle_ticket> ObtenerTodos()
        {
            List<detalle_ticket> lista = new List<detalle_ticket>();
            detalle_ticket entidad = new detalle_ticket();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_detalle_ticket";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new detalle_ticket();
                        entidad.id_detalle_ticket = int.Parse(dr["id_detalle_ticket"].ToString());
                        entidad.id_ticket = int.Parse(dr["id_ticket"].ToString());
                        entidad.id_area = int.Parse(dr["id_area"].ToString());
                        entidad.area = dr["area"].ToString();
                        entidad.id_prioridad = int.Parse(dr["id_prioridad"].ToString());
                        entidad.prioridad = dr["prioridad"].ToString();
                        entidad.id_estado = int.Parse(dr["id_estado"].ToString());
                        entidad.estado = dr["estado"].ToString();
                        entidad.id_agente = int.Parse(dr["id_agente"].ToString());
                        entidad.fechahora_inicioticket = dr["fechahora_inicioticket"].ToString();
                        entidad.fechahora_cerroticket = dr["fechahora_cerroticket"].ToString();
                        entidad.id_tipo_soporte = int.Parse(dr["id_tipo_soporte"].ToString());
                        lista.Add(entidad);
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar detalle_ticket";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar detalle_ticket";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return lista;
        }
        public detalle_ticket Obtener(int id)
        {
            detalle_ticket entidad = new detalle_ticket();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_detalle_ticket";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                comandoSelect.Parameters.AddWithValue("@IdDetalleTicket", id);
                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad.id_detalle_ticket = int.Parse(dr["id_detalle_ticket"].ToString());
                        entidad.id_ticket = int.Parse(dr["id_ticket"].ToString());
                        entidad.id_area = int.Parse(dr["id_area"].ToString());
                        entidad.area = dr["area"].ToString();
                        entidad.id_prioridad = int.Parse(dr["id_prioridad"].ToString());
                        entidad.prioridad = dr["prioridad"].ToString();
                        entidad.id_estado = int.Parse(dr["id_estado"].ToString());
                        entidad.estado = dr["estado"].ToString();
                        entidad.id_agente = int.Parse(dr["id_agente"].ToString());
                        entidad.fechahora_inicioticket = dr["fechahora_inicioticket"].ToString();
                        entidad.fechahora_cerroticket = dr["fechahora_cerroticket"].ToString();
                        entidad.id_tipo_soporte = int.Parse(dr["id_tipo_soporte"].ToString());
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar detalle_ticket";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar detalle_ticket";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;
        }
        public detalle_ticket ObtenerPorTicket(int id)
        {
            detalle_ticket entidad = new detalle_ticket();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_detalle_ticket";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                comandoSelect.Parameters.AddWithValue("@id_ticket", id);
                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad.id_detalle_ticket = int.Parse(dr["id_detalle_ticket"].ToString());
                        entidad.id_ticket = int.Parse(dr["id_ticket"].ToString());
                        entidad.id_area = int.Parse(dr["id_area"].ToString());
                        entidad.area = dr["area"].ToString();
                        entidad.id_prioridad = int.Parse(dr["id_prioridad"].ToString());
                        entidad.prioridad = dr["prioridad"].ToString();
                        entidad.id_estado = int.Parse(dr["id_estado"].ToString());
                        entidad.estado = dr["estado"].ToString();
                        entidad.id_agente = int.Parse(dr["id_agente"].ToString());
                        entidad.fechahora_inicioticket = dr["fechahora_inicioticket"].ToString();
                        entidad.fechahora_cerroticket = dr["fechahora_cerroticket"].ToString();
                        entidad.id_tipo_soporte = int.Parse(dr["id_tipo_soporte"].ToString());
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar detalle_ticket";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar detalle_ticket";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;
        }
        public bool Insertar(detalle_ticket entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_detalle_ticket";
                cmd.Parameters.AddWithValue("@Sentencia", "Insert");
                cmd.Parameters.AddWithValue("@IdDetalleTicket", entidad.id_detalle_ticket);
                cmd.Parameters.AddWithValue("@id_ticket", entidad.id_ticket);
                cmd.Parameters.AddWithValue("@id_area", entidad.id_area);
                cmd.Parameters.AddWithValue("@id_prioridad", entidad.id_prioridad);
                cmd.Parameters.AddWithValue("@id_estado", entidad.id_estado);
                cmd.Parameters.AddWithValue("@id_agente", entidad.id_agente);
                cmd.Parameters.AddWithValue("@fechahora_inicioticket", System.DateTime.Now);                
                cmd.Parameters.AddWithValue("@id_tipo_soporte", entidad.id_tipo_soporte);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar detalle_ticket";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar detalle_ticket";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
                cmd = null;
            }
            return respuesta;
        }
        public bool InsertarPorSucursal(detalle_ticket entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_detalle_ticket";
                cmd.Parameters.AddWithValue("@Sentencia", "Sucursal");                
                cmd.Parameters.AddWithValue("@id_ticket", entidad.id_ticket);
                cmd.Parameters.AddWithValue("@id_prioridad", entidad.id_prioridad);
                cmd.Parameters.AddWithValue("@id_estado", entidad.id_estado);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar detalle_ticket";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar detalle_ticket";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
                cmd = null;
            }
            return respuesta;
        }
        public bool Update(detalle_ticket entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_detalle_ticket";
                cmd.Parameters.AddWithValue("@Sentencia", "Update");
                cmd.Parameters.AddWithValue("@IdDetalleTicket", entidad.id_detalle_ticket);
                cmd.Parameters.AddWithValue("@id_ticket", entidad.id_ticket);
                cmd.Parameters.AddWithValue("@id_area", entidad.id_area);
                cmd.Parameters.AddWithValue("@id_prioridad", entidad.id_prioridad);
                cmd.Parameters.AddWithValue("@id_estado", entidad.id_estado);
                cmd.Parameters.AddWithValue("@id_agente", entidad.id_agente);                
                cmd.Parameters.AddWithValue("@fechahora_cerroticket", entidad.fechahora_cerroticket);
                cmd.Parameters.AddWithValue("@id_tipo_soporte", entidad.id_tipo_soporte);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar detalle_ticket";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar detalle_ticket";
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
                cmd.CommandText = "DML_detalle_ticket";
                cmd.Parameters.AddWithValue("@Sentencia", "Delete");
                cmd.Parameters.AddWithValue("@IdDetalleTicket", id);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete detalle_ticket";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete detalle_ticket";
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
