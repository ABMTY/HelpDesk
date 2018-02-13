using CtrlHelpDesk.Catalogos;
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
        public void RegisterNotification(DateTime currentTime)
        {

            string conStr = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            string  sqlCommand = @"SELECT OBJECT_NAME(OBJECT_ID)AS DatabaseName, last_user_update" +
                " FROM sys.dm_db_index_usage_stats WHERE database_id = DB_ID('db_tickets') AND OBJECT_ID = OBJECT_ID('zonas') " +
                " AND last_user_update > @AddedOn";
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
        
    }
}