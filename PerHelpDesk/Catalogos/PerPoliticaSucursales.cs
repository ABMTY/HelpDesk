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
   public  class PerPoliticaSucursales : Persistencia
    {
        public List<politica_sucursales> ObtenerTodos()
        {
            List<politica_sucursales> lista = new List<politica_sucursales>();
            politica_sucursales entidad = new politica_sucursales();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Politica_Sucursales";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad.id_politica_sucursale = int.Parse(dr["id_politica_sucursale"].ToString());
                        entidad.id_politica = int.Parse(dr["id_politica"].ToString());
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        lista.Add(entidad);
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar politica_sucursales";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar politica_sucursales";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return lista;
        }
        public politica_sucursales Obtener(int id)
        {
            politica_sucursales entidad = new politica_sucursales(); ;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_Politica_Sucursales";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                comandoSelect.Parameters.AddWithValue("@IdPoliticaSucursales", id);
                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad = new politica_sucursales();
                        entidad.id_politica_sucursale = int.Parse(dr["id_politica_sucursale"].ToString());
                        entidad.id_politica = int.Parse(dr["id_politica"].ToString());
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar politica_sucursales";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar politica_sucursales";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;
        }
        public bool Insertar(politica_sucursales entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Politica_Sucursales";
                cmd.Parameters.AddWithValue("@Sentencia", "Insert");
                cmd.Parameters.AddWithValue("@IdPoliticaSucursales", entidad.id_politica_sucursale);
                cmd.Parameters.AddWithValue("@id_politica", entidad.id_politica);
                cmd.Parameters.AddWithValue("@id_sucursal", entidad.id_sucursal);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar politica_sucursales";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar politica_sucursales";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
                cmd = null;
            }
            return respuesta;
        }
        public bool Update(politica_sucursales entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_Politica_Sucursales";
                cmd.Parameters.AddWithValue("@Sentencia", "Update");
                cmd.Parameters.AddWithValue("@IdPoliticaSucursales", entidad.id_politica_sucursale);
                cmd.Parameters.AddWithValue("@id_politica", entidad.id_politica);
                cmd.Parameters.AddWithValue("@id_sucursal", entidad.id_sucursal);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar politica_sucursales";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar politica_sucursales";
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
                cmd.CommandText = "DML_Politica_Sucursales";
                cmd.Parameters.AddWithValue("@Sentencia", "Delete");
                cmd.Parameters.AddWithValue("@IdPoliticaSucursales", id);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete politica_sucursales";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete politica_sucursales";
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
