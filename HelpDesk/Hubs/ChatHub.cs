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
        static List<usuarios> UsersList = new List<usuarios>();
        static List<conversaciones> MessageList = new List<conversaciones>();

        static List<usuarios> ConnectedUsers = new List<usuarios>();
        static List<conversaciones> CurrentMessage = new List<conversaciones>();
        

        //-->>>>> ***** Receive Request From Client [  Connect  ] *****
        public void Connect_old(string userName, string password)
        {

            
            var id = Context.ConnectionId;
            string userGroup = "";
            //Manage Hub Class
            //if freeflag==0 ==> Busy
            //if freeflag==1 ==> Free

            //if tpflag==0 ==> User
            //if tpflag==1 ==> Admin
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
            

            try
            {
                //You can check if user or admin did not login before by below line which is an if condition
                //if (UsersList.Count(x => x.ConnectionId == id) == 0)

                //Here you check if there is no userGroup which is same DepID --> this is User otherwise this is Admin
                //userGroup = DepID


                if (usuario.codigo_admin == 0)
                {
                    //now we encounter ordinary user which needs userGroup and at this step, system assigns the first of free Admin among UsersList
                    var strg = (from s in UsersList where (s.tpflag == "1") && (s.freeflag == "1") select s).First();
                    userGroup = strg.UserGroup;

                    //Admin becomes busy so we assign zero to freeflag which is shown admin is busy
                    strg.freeflag = "0";

                    //now add USER to UsersList
                    UsersList.Add(new usuarios { ConnectionId = id, id_usuario = usuario.id_usuario, user_name = userName, UserGroup = userGroup, freeflag = "0", tpflag = "0", foto=usuario.foto, nombre=usuario.nombre});
                    //whether it is Admin or User now both of them has userGroup and I Join this user or admin to specific group 
                    Groups.Add(Context.ConnectionId, userGroup);
                    Clients.Caller.onConnected(id, userName, usuario.id_usuario, userGroup);

                }
                else
                {
                    //If user has admin code so admin code is same userGroup
                    //now add ADMIN to UsersList
                    UsersList.Add(new usuarios { ConnectionId = id, AdminID = usuario.id_usuario, user_name = userName, UserGroup = usuario.codigo_admin.ToString(), freeflag = "1", tpflag = "1", foto = usuario.foto, nombre=usuario.nombre });
                    //whether it is Admin or User now both of them has userGroup and I Join this user or admin to specific group 
                    Groups.Add(Context.ConnectionId, usuario.codigo_admin.ToString());
                    Clients.Caller.onConnected(id, userName, usuario.id_usuario, usuario.codigo_admin.ToString());

                }

                Clients.All.updateUsers(UsersList.Count(), UsersList.Select(u => u.nombre));

            }

            catch
            {
                string msg = "All Administrators are busy, please be patient and try again";
                //***** Return to Client *****
                Clients.Caller.NoExistAdmin();

            }
        }
        // <<<<<-- ***** Return to Client [  NoExist  ] *****

      


        public string Fecha_Hora()
        {      
            DateTime Fecha = DateTime.Now;
            Fecha.ToString("tt", CultureInfo.InvariantCulture);
            string Fecha_Hora = Fecha.ToString("d MMMM hh:mm:ss tt", CultureInfo.CreateSpecificCulture("es-MX"));   
            return Fecha_Hora;
        }

        //--group ***** Receive Request From Client [  SendMessageToGroup  ] *****
        public void SendMessageToGroup(string userName, string message)
        {

            if (UsersList.Count != 0)
            {
                var strg = (from s in UsersList where (s.user_name == userName) select s).First();

                MessageList.Add(new conversaciones { nombre_usuario = userName, mensaje = message, grupo_usuarios = strg.UserGroup, foto_usuario= strg.foto });
                string strgroup = strg.UserGroup;
                string fecha_hrs = Fecha_Hora();
                // If you want to Broadcast message to all UsersList use below line
                // Clients.All.getMessages(userName, message,strg.foto, fecha_hrs);

                //If you want to establish peer to peer connection use below line so message will be send just for user and admin who are in same group
                //***** Return to Client *****
                Clients.Group(strgroup).getMessages(userName, message,strg.foto, fecha_hrs);
            }

        }


        // <<<<<-- ***** Return to Client [  getMessages  ] *****


        //--group ***** Receive Request From Client ***** { Whenever User close session then OnDisconneced will be occurs }
        //public override Task OnDisconnected(bool stopCalled)
        ////public void OnDisconnected()
        //{

        //    var item = UsersList.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
        //    if (item != null)
        //    {
        //        UsersList.Remove(item);

        //        var id = Context.ConnectionId;

        //        if (item.tpflag == "0")
        //        {
        //            //user logged off == user
        //            try
        //            {
        //                var stradmin = (from s in UsersList where (s.UserGroup == item.UserGroup) && (s.tpflag == "1") select s).First();
        //                //become free
        //                stradmin.freeflag = "1";
        //            }
        //            catch
        //            {
        //                //***** Return to Client *****
        //                Clients.Caller.NoExistAdmin();
        //            }

        //        }

        //        //save conversation to dat abase

        //    }
        //    return base.OnDisconnected(stopCalled);
        //}

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

            if (toUser != null && fromUser != null)
            {
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.user_name, message);

                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.user_name, message);
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