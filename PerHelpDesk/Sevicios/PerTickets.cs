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
                        entidad.id_estado = int.Parse(dr["id_estado"].ToString());
                        entidad.estado = dr["estado"].ToString();
                        if (dr["id_detalle_ticket"].ToString() != string.Empty)
                        {
                            entidad.id_detalle_ticket = int.Parse(dr["id_detalle_ticket"].ToString());                            
                            entidad.id_prioridad = int.Parse(dr["id_prioridad"].ToString());
                            entidad.prioridad = dr["prioridad"].ToString();
                            entidad.id_agente = dr["id_agente"].ToString() == string.Empty ? 0 : int.Parse(dr["id_agente"].ToString());
                            entidad.agente = dr["agente"].ToString() == "" ? "Sin Asignar" : dr["agente"].ToString();
                            if (dr["foto_agente"].ToString() != string.Empty)
                                entidad.foto_agente = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["foto_agente"]);
                            entidad.id_area = dr["id_area"].ToString() == string.Empty ? 0 : int.Parse(dr["id_area"].ToString());
                            entidad.area = dr["area"].ToString();
                            entidad.id_tipo_soporte = dr["id_tipo_soporte"].ToString() == string.Empty ? 0 : int.Parse(dr["id_tipo_soporte"].ToString());
                            entidad.tipo_soporte = dr["tipo_soporte"].ToString();
                        }
                        
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
        public int ObtenerMax()
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
            return lista.Max(p => p.id_ticket); ;
        }
        public SqlCommand ObtenerCommand()
        {
            SqlCommand comandoSelect = new SqlCommand();
            try
            {                
                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Tickets";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
            }
            catch (Exception)
            {

                throw;
            }
            return comandoSelect;
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
                            entidad.imagen = Convert.ToBase64String((byte[])dr["imagen"]);
                        
                        entidad.fechahora_creacion = dr["fechahora_creacion"].ToString();
                        entidad.id_estado = int.Parse(dr["id_estado"].ToString());
                        entidad.estado = dr["estado"].ToString();
                        if (dr["id_detalle_ticket"].ToString() != string.Empty)
                        {
                            entidad.id_detalle_ticket = int.Parse(dr["id_detalle_ticket"].ToString());
                            entidad.id_prioridad = int.Parse(dr["id_prioridad"].ToString());
                            entidad.prioridad = dr["prioridad"].ToString();
                            entidad.id_agente = dr["id_agente"].ToString() == string.Empty ? 0 : int.Parse(dr["id_agente"].ToString());
                            entidad.agente = dr["agente"].ToString() == "" ? "Sin Asignar" : dr["agente"].ToString();
                            if (dr["foto_agente"].ToString() != string.Empty)
                                entidad.foto_agente = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["foto_agente"]);
                            entidad.id_area = dr["id_area"].ToString() == string.Empty ? 0 : int.Parse(dr["id_area"].ToString());
                            entidad.area = dr["area"].ToString();
                            entidad.id_tipo_soporte = dr["id_tipo_soporte"].ToString() == string.Empty ? 0 : int.Parse(dr["id_tipo_soporte"].ToString());
                            entidad.tipo_soporte = dr["tipo_soporte"].ToString();
                        }

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
        public tickets ObtenerEstados(usuarios usuario)
        {
            tickets entidad = new tickets();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Count_Tickets";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");

                if (usuario!=null && usuario.tipo_usuario=="Supervisor")
                    comandoSelect.Parameters.AddWithValue("@IdUsuario", usuario.id_usuario);
                if (usuario != null && usuario.tipo_usuario == "Agente")
                    comandoSelect.Parameters.AddWithValue("@IdAgente", usuario.id_usuario);

                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad.vencidos = int.Parse(dr["Vencidos"].ToString());
                        entidad.abiertos = int.Parse(dr["Abierto"].ToString());
                        entidad.en_espera = int.Parse(dr["En_Espera"].ToString());
                        entidad.en_proceso = int.Parse(dr["En_Proceso"].ToString());
                        entidad.vence_hoy = int.Parse(dr["Vence_Hoy"].ToString());
                        entidad.sin_asignar = int.Parse(dr["Sin_Asignar"].ToString());
                        entidad.otros = int.Parse(dr["Otros"].ToString());
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
        public List<tickets> ObtenerPrioridad()
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
                comandoSelect.CommandText = "DML_Count_Tickets";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Prioridad");
                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new tickets();                        
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        entidad.usuario = dr["usuario"].ToString();                       
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.sucursal = dr["sucursal"].ToString();                       
                        entidad.prioridad = dr["prioridad"].ToString();
                        entidad.no_tickets = int.Parse(dr["tickets"].ToString());

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
        public List<tickets> ObtenerPorUsuario(int id)
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
                comandoSelect.Parameters.AddWithValue("@IdUsuario", id);
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
                        entidad.id_estado = int.Parse(dr["id_estado"].ToString());
                        entidad.estado = dr["estado"].ToString();
                        if (dr["id_detalle_ticket"].ToString() != string.Empty)
                        {
                            entidad.id_detalle_ticket = int.Parse(dr["id_detalle_ticket"].ToString());
                            entidad.id_prioridad = int.Parse(dr["id_prioridad"].ToString());
                            entidad.prioridad = dr["prioridad"].ToString();
                            entidad.id_agente = dr["id_agente"].ToString() == string.Empty ? 0 : int.Parse(dr["id_agente"].ToString());
                            entidad.agente = dr["agente"].ToString() == "" ? "Sin Asignar" : dr["agente"].ToString();
                            if (dr["foto_agente"].ToString() != string.Empty)
                                entidad.foto_agente = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["foto_agente"]);
                            entidad.id_area = dr["id_area"].ToString() == string.Empty ? 0 : int.Parse(dr["id_area"].ToString());
                            entidad.area = dr["area"].ToString();
                            entidad.id_tipo_soporte = dr["id_tipo_soporte"].ToString() == string.Empty ? 0 : int.Parse(dr["id_tipo_soporte"].ToString());
                            entidad.tipo_soporte = dr["tipo_soporte"].ToString();
                        }
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
                if(entidad.imagen!=string.Empty)
                    cmd.Parameters.AddWithValue("@imagen", Convert.FromBase64String(entidad.imagen));                
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
                cmd.Parameters.AddWithValue("@imagen", Convert.FromBase64String(entidad.imagen));                
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
