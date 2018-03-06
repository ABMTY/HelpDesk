using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using EntHelpDesk.Entidad;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace HelpDesk.Conversaiones
{
    public class ConversacionHub : Hub
    {
        static List<usuarios> UsersList = new List<usuarios>();
        static List<conversaciones> MessageList = new List<conversaciones>();

        //-->>>>> ***** Receive Request From Client [  Connect  ] *****
        public void Connect(string userName, string password)
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

            string sqlCommand = @"SELECT [id_usuario],[user_name],[codigo_admin] FROM [dbo].[usuarios] WHERE [user_name]=@userName AND [password]=@password";
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
                    }
                }

                //using (SqlDataReader reader = cmd.ExecuteReader())
                //{
                //    //
                //}

                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                    conexion.Dispose();
                }
            }



            //var ctx = new TestEntities();

            //var userInfo =
            //     (from m in ctx.tbl_User
            //      where m.UserName == userName && m.Password == password
            //      select new { m.UserID, m.UserName, m.AdminCode }).FirstOrDefault();


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
                    UsersList.Add(new usuarios { ConnectionId = id, id_usuario = usuario.id_usuario, user_name = userName, UserGroup = userGroup, freeflag = "0", tpflag = "0", });
                    //whether it is Admin or User now both of them has userGroup and I Join this user or admin to specific group 
                    Groups.Add(Context.ConnectionId, userGroup);
                    Clients.Caller.onConnected(id, userName, usuario.id_usuario, userGroup);

                }
                else
                {
                    //If user has admin code so admin code is same userGroup
                    //now add ADMIN to UsersList
                    UsersList.Add(new usuarios { ConnectionId = id, AdminID = usuario.id_usuario, user_name = userName, UserGroup = usuario.codigo_admin.ToString(), freeflag = "1", tpflag = "1" });
                    //whether it is Admin or User now both of them has userGroup and I Join this user or admin to specific group 
                    Groups.Add(Context.ConnectionId, usuario.codigo_admin.ToString());
                    Clients.Caller.onConnected(id, userName, usuario.id_usuario, usuario.codigo_admin.ToString());

                }

            }

            catch
            {
                string msg = "All Administrators are busy, please be patient and try again";
                //***** Return to Client *****
                Clients.Caller.NoExistAdmin();

            }
        }
        // <<<<<-- ***** Return to Client [  NoExist  ] *****



        //--group ***** Receive Request From Client [  SendMessageToGroup  ] *****
        public void SendMessageToGroup(string userName, string message)
        {

            if (UsersList.Count != 0)
            {
                var strg = (from s in UsersList where (s.user_name == userName) select s).First();

                MessageList.Add(new conversaciones { nombre_usuario = userName, mensaje = message, grupo_usuarios = strg.UserGroup });
                string strgroup = strg.UserGroup;
                // If you want to Broadcast message to all UsersList use below line
                // Clients.All.getMessages(userName, message);

                //If you want to establish peer to peer connection use below line so message will be send just for user and admin who are in same group
                //***** Return to Client *****
                Clients.Group(strgroup).getMessages(userName, message);
            }

        }
        // <<<<<-- ***** Return to Client [  getMessages  ] *****


        //--group ***** Receive Request From Client ***** { Whenever User close session then OnDisconneced will be occurs }
        //public override System.Threading.Tasks.Task OnDisconnected()
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

        //    return base.OnDisconnected();
        //}
    }
    
}