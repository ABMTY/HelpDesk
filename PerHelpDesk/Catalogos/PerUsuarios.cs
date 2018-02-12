using EntHelpDesk.Entidad;
using PerHelpDesk.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerHelpDesk.Catalogos
{
    public class PerUsuarios : Persistencia
    {
        public List<usuarios> ObtenerTodos()
        {
            List<usuarios> lista = new List<usuarios>();
            usuarios entidad;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Usuarios";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                 using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new usuarios();
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        entidad.nombre = dr["nombre"].ToString();
                        entidad.apellidos = dr["apellidos"].ToString();
                        entidad.correo = dr["correo"].ToString();
                        entidad.telefono = int.Parse(dr["telefono"].ToString());
                        entidad.ext = int.Parse(dr["ext"].ToString());
                        entidad.foto = dr["foto"].ToString();
                        entidad.id_area = int.Parse(dr["id_area"].ToString());
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.id_tipo_usuario = int.Parse(dr["id_tipo_usuario"].ToString());
                        lista.Add(entidad);
                    }
                }

            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar usuarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar usuarios";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return lista;
        }
        public usuarios Obtener(int id)
        {
            usuarios entidad = new usuarios();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Usuarios";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                comandoSelect.Parameters.AddWithValue("@IdUsuario", id);
                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        entidad.nombre = dr["nombre"].ToString();
                        entidad.apellidos = dr["apellidos"].ToString();
                        entidad.correo = dr["correo"].ToString();
                        entidad.telefono = int.Parse(dr["telefono"].ToString());
                        entidad.ext = int.Parse(dr["ext"].ToString());
                        entidad.foto = dr["foto"].ToString();
                        entidad.id_area = int.Parse(dr["id_area"].ToString());
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.id_tipo_usuario = int.Parse(dr["id_tipo_usuario"].ToString());
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar usuarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar usuarios";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;
        }
        public bool Insertar(usuarios entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Usuarios";
                cmd.Parameters.AddWithValue("@Sentencia", "Insert");
                cmd.Parameters.AddWithValue("@IdUsuario", entidad.id_usuario);
                cmd.Parameters.AddWithValue("@nombre", entidad.nombre);
                cmd.Parameters.AddWithValue("@apellidos", entidad.apellidos);                
                cmd.Parameters.AddWithValue("@correo", entidad.correo);
                cmd.Parameters.AddWithValue("@telefono", entidad.telefono);
                cmd.Parameters.AddWithValue("@ext", entidad.ext);
                cmd.Parameters.AddWithValue("@foto", entidad.foto);
                cmd.Parameters.AddWithValue("@id_area", entidad.id_area);
                cmd.Parameters.AddWithValue("@id_sucursal", entidad.id_sucursal);
                cmd.Parameters.AddWithValue("@id_tipo_usuario", entidad.id_tipo_usuario);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar usuarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar usuarios";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
                cmd = null;
            }
            return respuesta;
        }
        public bool Update(usuarios entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Usuarios";
                cmd.Parameters.AddWithValue("@Sentencia", "Update");
                cmd.Parameters.AddWithValue("@IdUsuario", entidad.id_usuario);
                cmd.Parameters.AddWithValue("@nombre", entidad.nombre);
                cmd.Parameters.AddWithValue("@apellidos", entidad.apellidos);
                cmd.Parameters.AddWithValue("@correo", entidad.correo);
                cmd.Parameters.AddWithValue("@telefono", entidad.telefono);
                cmd.Parameters.AddWithValue("@ext", entidad.ext);
                cmd.Parameters.AddWithValue("@foto", entidad.foto);
                cmd.Parameters.AddWithValue("@id_area", entidad.id_area);
                cmd.Parameters.AddWithValue("@id_sucursal", entidad.id_sucursal);
                cmd.Parameters.AddWithValue("@id_tipo_usuario", entidad.id_tipo_usuario);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar usuarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar usuarios";
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
                cmd.CommandText = "DML_Usuarios";
                cmd.Parameters.AddWithValue("@Sentencia", "Delete");
                cmd.Parameters.AddWithValue("@IdUsuario", id);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete usuarios";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete usuarios";
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
