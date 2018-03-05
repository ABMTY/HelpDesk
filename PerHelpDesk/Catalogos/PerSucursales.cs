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
    public class PerSucursales : Persistencia
    {
        public List<sucursales> ObtenerTodos()
        {
            List<sucursales> lista = new List<sucursales>();
            sucursales entidad;
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_sucursales";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                using (var dr = comandoSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        entidad = new sucursales();
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.nombre = dr["nombre"].ToString();
                        entidad.direccion = dr["direccion"].ToString();
                        entidad.id_zona = int.Parse(dr["id_zona"].ToString());
                        entidad.zona = dr["zona"].ToString();
                        entidad.id_politica = int.Parse(dr["id_politica"].ToString());
                        entidad.politica = dr["politica"].ToString();
                        if (dr["imagen"].ToString() != string.Empty)
                            entidad.imagen = Convert.ToBase64String((byte[])dr["imagen"]);
                        lista.Add(entidad);
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar sucursales";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar sucursales";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return lista;
        }
        public sucursales Obtener(int id)
        {
            sucursales entidad = new sucursales();
            try
            {
                AbrirConexion();
                StringBuilder CadenaSql = new StringBuilder();

                SqlCommand comandoSelect = new SqlCommand();

                comandoSelect.Connection = Conexion;
                comandoSelect.CommandType = CommandType.StoredProcedure;
                comandoSelect.CommandText = "DML_sucursales";
                comandoSelect.Parameters.AddWithValue("@Sentencia", "Select");
                comandoSelect.Parameters.AddWithValue("@IdSucursales", id);
                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        entidad.id_sucursal = int.Parse(dr["id_sucursal"].ToString());
                        entidad.nombre = dr["nombre"].ToString();
                        entidad.direccion = dr["direccion"].ToString();
                        entidad.id_zona = int.Parse(dr["id_zona"].ToString());
                        entidad.zona = dr["zona"].ToString();
                        entidad.id_politica = int.Parse(dr["id_politica"].ToString());
                        entidad.politica = dr["politica"].ToString();
                        if (dr["imagen"].ToString() != string.Empty)
                            entidad.imagen = Convert.ToBase64String((byte[])dr["imagen"]);
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar sucursales";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar sucursales";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
            }
            return entidad;
        }
        public bool Insertar(sucursales entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                if (validar(entidad))
                {
                    AbrirConexion();
                    cmd.Connection = Conexion;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DML_sucursales";
                    cmd.Parameters.AddWithValue("@Sentencia", "Insert");
                    cmd.Parameters.AddWithValue("@IdSucursales", entidad.id_sucursal);
                    cmd.Parameters.AddWithValue("@nombre", entidad.nombre);
                    cmd.Parameters.AddWithValue("@direccion", entidad.direccion);
                    cmd.Parameters.AddWithValue("@IdZona", entidad.id_zona);
                    cmd.Parameters.AddWithValue("@IdPolitica", entidad.id_politica);
                    cmd.Parameters.AddWithValue("@imagen", Convert.FromBase64String(entidad.imagen));
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar sucursales";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar sucursales";
                throw excepcion;
            }
            finally
            {
                CerrarConexion();
                cmd = null;
            }
            return respuesta;
        }

        private bool validar(sucursales entidad)
        {
            bool valido = false;

            if (entidad.nombre != String.Empty && entidad.direccion != String.Empty)
                valido = true;

            return valido;
        }

        public bool Update(sucursales entidad)
        {
            SqlCommand cmd = new SqlCommand();
            bool respuesta = false;
            try
            {
                AbrirConexion();
                cmd.Connection = Conexion;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DML_sucursales";
                cmd.Parameters.AddWithValue("@Sentencia", "Update");
                cmd.Parameters.AddWithValue("@IdSucursales", entidad.id_sucursal);
                cmd.Parameters.AddWithValue("@nombre", entidad.nombre);
                cmd.Parameters.AddWithValue("@direccion", entidad.direccion);
                cmd.Parameters.AddWithValue("@IdZona", entidad.id_zona);
                cmd.Parameters.AddWithValue("@IdPolitica", entidad.id_politica);
                cmd.Parameters.AddWithValue("@imagen", Convert.FromBase64String(entidad.imagen));
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar sucursales";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Insertar sucursales";
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
                cmd.CommandText = "DML_sucursales";
                cmd.Parameters.AddWithValue("@Sentencia", "Delete");
                cmd.Parameters.AddWithValue("@IdSucursales", id);
                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (InvalidCastException ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de conversión de tipos con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete sucursales";
                throw excepcion;
            }
            catch (Exception ex)
            {
                ApplicationException excepcion = new ApplicationException("Se genero un error de aplicación con el siguiente mensaje: " + ex.Message, ex);
                excepcion.Source = "Delete sucursales";
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
