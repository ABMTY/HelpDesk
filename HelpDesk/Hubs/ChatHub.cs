using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using EntHelpDesk.Entidad;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;

namespace HelpDesk.Hubs
{
    public class ChatHub : Hub
    {
        static List<usuarios> ConnectedUsers = new List<usuarios>();
        static List<conversaciones> CurrentMessage = new List<conversaciones>();        

        public string Fecha_Hora()
        {      
            DateTime Fecha = DateTime.Now;
            Fecha.ToString("tt", CultureInfo.InvariantCulture);
            string Fecha_Hora = Fecha.ToString("d MMMM hh:mm:ss tt", CultureInfo.CreateSpecificCulture("es-MX"));   
            return Fecha_Hora;
        }       

        public void Connect(string userName, string password)
        {
            var id = Context.ConnectionId;

            usuarios usuario = new usuarios();
            string conStr = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            string sqlCommand = @"SELECT [id_usuario],[user_name],[codigo_admin],[foto],[nombre] FROM [dbo].[usuarios] WHERE [user_name]=@userName AND [password]=@password";
            using (SqlConnection conexion = new SqlConnection(conStr))
            {
                SqlCommand comandoSelect = new SqlCommand(sqlCommand, conexion);
                comandoSelect.Parameters.AddWithValue("@userName", userName);
                comandoSelect.Parameters.AddWithValue("@password", password);
                if (conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }

                using (var dr = comandoSelect.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        usuario.id_usuario = int.Parse(dr["id_usuario"].ToString());
                        usuario.user_name = dr["user_name"].ToString();
                        usuario.codigo_admin = int.Parse(dr["codigo_admin"].ToString());
                        usuario.foto = Convert.ToBase64String((byte[])dr["foto"]);
                        usuario.nombre = dr["nombre"].ToString();
                    }
                }

                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                    conexion.Dispose();
                }
            }

            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new usuarios { ConnectionId = id, id_usuario = usuario.id_usuario, user_name = userName, foto = usuario.foto, nombre = usuario.nombre });


                // send to caller
                Clients.Caller.onConnected(id, userName, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, userName);

            }

        }

        public void SendMessageToAll(string userName, string message)
        {
            var usuario = (from s in ConnectedUsers where (s.user_name == userName) select s).First();
            string fecha_hrs = Fecha_Hora();

            // store last 100 messages in cache
            AddMessageinCache(userName, message, usuario.foto, fecha_hrs);

            // Broad cast message
            Clients.All.messageReceived(userName, message, usuario.foto, fecha_hrs);
        }

        public void SendPrivateMessage(string toUserId, string message)
        {

            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

            string fecha_hrs = Fecha_Hora();

            if (toUser != null && fromUser != null)
            {
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.user_name, message, fromUser.foto, fecha_hrs);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.user_name, message, fromUser.foto, fecha_hrs);
            }

        }


        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                ConnectedUsers.Remove(item);

                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.user_name);

            }

            return base.OnDisconnected(stopCalled);
        }


        #region private Messages

        private void AddMessageinCache(string userName, string message, string foto, string fechahora)
        {
            CurrentMessage.Add(new conversaciones { UserName = userName, Message = message, foto_usuario=foto,fecha_Mensaje=fechahora });

            if (CurrentMessage.Count > 100)
                CurrentMessage.RemoveAt(0);
        }

        #endregion

        
    }
}