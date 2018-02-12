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
    public class PerTipoSoporte : Persistencia
    {
        public List<tipo_soporte> ObtenerTodos()
        {
            List<tipo_soporte> lista = new List<tipo_soporte>();
            tipo_soporte entidad;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Tipo_Soporte";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new tipo_soporte();
                        entidad.id_tipo_soporte = int.Parse(dr["id_tipo_soporte"].ToString());
                        entidad.descripcion = dr["descripcion"].ToString();
                        lista.Add(entidad);
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tipo_soporte";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tipo_soporte";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return lista;
        }
        public tipo_soporte Obtener(int id)
        {
            tipo_soporte entidad = new tipo_soporte(); ;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Tipo_Soporte";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                comandoSelect.Parameters.AddWithValue("@Idtipo_soporte", id);
                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {                        
                        entidad.id_tipo_soporte = int.Parse(dr["id_tipo_soporte"].ToString());
                        entidad.descripcion = dr["descripcion"].ToString();
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tipo_soporte";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tipo_soporte";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;
        }
        public bool Insertar(tipo_soporte entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Tipo_Soporte";
                cmd.Parameters.AddWithValue("@Sentencia", "Insert");
                cmd.Parameters.AddWithValue("@Idtipo_soporte", entidad.id_tipo_soporte);
                cmd.Parameters.AddWithValue("@descripcion", entidad.descripcion);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tipo_soporte";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tipo_soporte";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
                cmd = null;
            }
            return respuesta;
        }
        public bool Update(tipo_soporte entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Tipo_Soporte";
                cmd.Parameters.AddWithValue("@Sentencia", "Update");
                cmd.Parameters.AddWithValue("@Idtipo_soporte", entidad.id_tipo_soporte);
                cmd.Parameters.AddWithValue("@descripcion", entidad.descripcion);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tipo_soporte";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar tipo_soporte";
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
                cmd.CommandText = "DML_Tipo_Soporte";
                cmd.Parameters.AddWithValue("@Sentencia", "Delete");
                cmd.Parameters.AddWithValue("@Idtipo_soporte", id);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete tipo_soporte";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete tipo_soporte";
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
