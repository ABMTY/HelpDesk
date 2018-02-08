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
    public class PerEstado : Persistencia
    {
        public List<estado> ObtenerTodos()
        {
            List<estado> lista = new List<estado>();
            estado entidad = new estado();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Estado";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad.id_estado = int.Parse(dr["id_estado"].ToString());
                        entidad.nombre = dr["nombre"].ToString();
                        lista.Add(entidad);
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar estado";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar estado";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return lista;
        }
        public estado Obtener()
        {
            estado entidad = new estado();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Estado";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad.id_estado = int.Parse(dr["id_estado"].ToString());
                        entidad.nombre = dr["nombre"].ToString();
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar estado";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar estado";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;
        }
        public bool Insertar(estado entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Estado";
                cmd.Parameters.AddWithValue("@Sentencia", "Insert");
                cmd.Parameters.AddWithValue("@IdEstado", entidad.id_estado);
                cmd.Parameters.AddWithValue("@nombre", entidad.nombre);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar estado";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar estado";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
                cmd = null;
            }
            return respuesta;
        }
        public bool Update(estado entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Estado";
                cmd.Parameters.AddWithValue("@Sentencia", "Update");
                cmd.Parameters.AddWithValue("@IdEstado", entidad.id_estado);
                cmd.Parameters.AddWithValue("@nombre", entidad.nombre);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar estado";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar estado";
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
                cmd.CommandText = "DML_Estado";
                cmd.Parameters.AddWithValue("@Sentencia", "Delete");
                cmd.Parameters.AddWithValue("@IdEstado", id);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete estado";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete estado";
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
