using CtrlHelpDesk.Catalogos;
using EntHelpDesk.Entidad;
using HelpDesk;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HelpDesk
{
    public class NotificationComponent
    {
        CtrlZonas control = new CtrlZonas();
        public void RegisterNotification(DateTime currentTime)
        {

            string conStr = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            string sqlCommand = @"SELECT [ContactID],[ContactName],[ContactNo] from [dbo].[Contacts] where [AddedOn] > @AddedOn";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.Parameters.AddWithValue("@AddedOn", currentTime);
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Notification = null;
                SqlDependency sqlDep = new SqlDependency(cmd);
                sqlDep.OnChange += sqlDep_OnChange;
                /*----------------------------------------*/

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //
                }
            }
                      
        }
        private void sqlDep_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency sqlDep = sender as SqlDependency;
                sqlDep.OnChange -= sqlDep_OnChange;

                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                notificationHub.Clients.All.notify("added");
                RegisterNotification(DateTime.Now);
            }
        }

        public List<Contacts> GetContacts(DateTime afterDate)
        {
            using (db_ticketsEntities dc = new db_ticketsEntities())
            {
                return dc.Contacts.Where(a => a.AddedOn > afterDate).OrderByDescending(a => a.AddedOn).ToList();
            }

        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                SqlDependency sqlDep = sender as SqlDependency;
                sqlDep.OnChange -= dependency_OnChange;

                var notificationHub = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
                notificationHub.Clients.All.notify("added");
                RegisterComments(DateTime.Now);
            }
        }

        public void RegisterComments(DateTime currentTime)
        {

            string conStr = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            string sqlCommand = @"SELECT  [id_comentario],[comentario],[fechahora_comentario],[id_detalle_ticket],[imagen],[id_usuario] FROM [dbo].[comentarios] where [fechahora_comentario] > @Fecha";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand(sqlCommand, con);
                cmd.Parameters.AddWithValue("@Fecha", currentTime);
                if (con.State != System.Data.ConnectionState.Open)
                {
                    con.Open();
                }
                cmd.Notification = null;
                SqlDependency sqlDep = new SqlDependency(cmd);
                sqlDep.OnChange += dependency_OnChange;
                /*----------------------------------------*/

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    //
                }
            }

        }
    }
}