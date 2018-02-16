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
    public class PerComentarios : Persistencia
    {
        public List<comentarios> ObtenerTodos()
        {
            List<comentarios> lista = new List<comentarios>();
            comentarios entidad = new comentarios();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Comentarios";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad.id_comentario = int.Parse(dr["id_comentario"].ToString());
                        entidad.comentario = dr["comentario"].ToString();
                        if (dr["imagen"].ToString() != string.Empty)
                            entidad.imagen = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["imagen"]);
                        entidad.fechahora_comentario = DateTime.Parse(dr["fechahora_comentario"].ToString());                        
                        entidad.id_detalle_ticket = int.Parse(dr["id_detalle_ticket"].ToString());
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        entidad.usuario = dr["usuario"].ToString();
                        lista.Add(entidad);
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar comentarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar comentarios";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return lista;
        }
        public comentarios Obtener(int id)
        {
            comentarios entidad = new comentarios();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Comentarios";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                comandoSelect.Parameters.AddWithValue("@IdComentario", id);
                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad.id_comentario = int.Parse(dr["id_comentario"].ToString());
                        entidad.comentario = dr["comentario"].ToString();
                        if (dr["imagen"].ToString() != string.Empty)
                            entidad.imagen = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["imagen"]);
                        entidad.fechahora_comentario = DateTime.Parse(dr["fechahora_comentario"].ToString());                        
                        entidad.id_detalle_ticket = int.Parse(dr["id_detalle_ticket"].ToString());
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        entidad.usuario = dr["usuario"].ToString();
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar comentarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar comentarios";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;
        }
        public comentarios ObtenerPorDetalle(int id)
        {
            comentarios entidad = new comentarios();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Comentarios";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                comandoSelect.Parameters.AddWithValue("@id_detalle_ticket", id);
                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad.id_comentario = int.Parse(dr["id_comentario"].ToString());
                        entidad.comentario = dr["comentario"].ToString();
                        if (dr["imagen"].ToString() != string.Empty)
                            entidad.imagen = "data:image/png;base64," + Convert.ToBase64String((byte[])dr["imagen"]);
                        entidad.fechahora_comentario = DateTime.Parse(dr["fechahora_comentario"].ToString());
                        entidad.id_detalle_ticket = int.Parse(dr["id_detalle_ticket"].ToString());
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        entidad.usuario = dr["usuario"].ToString();
                        entidad.id_tipo_usuario = int.Parse(dr["id_tipo_usuario"].ToString());
                        entidad.tipo_usuario = dr["tipo_usuario"].ToString();
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar comentarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar comentarios";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;
        }
        public bool Insertar(comentarios entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Comentarios";
                cmd.Parameters.AddWithValue("@Sentencia", "Insert");
                cmd.Parameters.AddWithValue("@IdComentario", entidad.id_comentario);
                cmd.Parameters.AddWithValue("@comentario", entidad.comentario);
                cmd.Parameters.AddWithValue("@imagen", Convert.FromBase64String(entidad.imagen));
                cmd.Parameters.AddWithValue("@fechahora_comentario", entidad.fechahora_comentario);                
                cmd.Parameters.AddWithValue("@id_detalle_ticket", entidad.id_detalle_ticket);
                cmd.Parameters.AddWithValue("@id_usuario", entidad.id_usuario);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar comentarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar comentarios";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
                cmd = null;
            }
            return respuesta;
        }
        public bool Update(comentarios entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Comentarios";
                cmd.Parameters.AddWithValue("@Sentencia", "Update");
                cmd.Parameters.AddWithValue("@IdComentario", entidad.id_comentario);
                cmd.Parameters.AddWithValue("@comentario", entidad.comentario);
                cmd.Parameters.AddWithValue("@imagen", Convert.FromBase64String(entidad.imagen));
                cmd.Parameters.AddWithValue("@fechahora_comentario", entidad.fechahora_comentario);                
                cmd.Parameters.AddWithValue("@id_detalle_ticket", entidad.id_detalle_ticket);
                cmd.Parameters.AddWithValue("@id_usuario", entidad.id_usuario);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar comentarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar comentarios";
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
                cmd.CommandText = "DML_Comentarios";
                cmd.Parameters.AddWithValue("@Sentencia", "Delete");
                cmd.Parameters.AddWithValue("@IdComentario", id);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete comentarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete comentarios";
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
