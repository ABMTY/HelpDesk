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
    public class PerAreas : Persistencia 
    {
        public List<areas> ObtenerTodos()
        {
            List<areas> lista = new List<areas>();
            areas entidad = new areas();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Areas";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad.id_area = int.Parse(dr["id_area"].ToString());
                        entidad.nombre = dr["nombre"].ToString();
                        lista.Add(entidad);
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar areas";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar areas";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return lista;
        }
        public areas Obtener()
        {
            areas entidad = new areas();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Areas";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad.id_area = int.Parse(dr["id_area"].ToString());
                        entidad.nombre = dr["nombre"].ToString();
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar areas";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar areas";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;
        }
        public bool Insertar(areas entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Areas";
                cmd.Parameters.AddWithValue("@Sentencia", "Insert");
                cmd.Parameters.AddWithValue("@IdArea", entidad.id_area);
                cmd.Parameters.AddWithValue("@nombre", entidad.nombre);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar areas";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar areas";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
                cmd = null;
            }
            return respuesta;
        }
        public bool Update(areas entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Areas";
                cmd.Parameters.AddWithValue("@Sentencia", "Update");
                cmd.Parameters.AddWithValue("@IdArea", entidad.id_area);
                cmd.Parameters.AddWithValue("@nombre", entidad.nombre);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar areas";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar areas";
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
                cmd.CommandText = "DML_Areas";
                cmd.Parameters.AddWithValue("@Sentencia", "Delete");
                cmd.Parameters.AddWithValue("@IdArea", id);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete areas";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete areas";
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
