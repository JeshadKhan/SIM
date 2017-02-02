/*
 * Author               : Quaint Park
 * Copyright            : © 2017 Quaint Park.
 * Official Website     : www.quaintpark.com
 * ------------------------------------------------------------------------------
 * Developed By         : Jeshad Khan
 * Profile              : www.jeshadkhan.com
 * ------------------------------------------------------------------------------
 * Title                : Simple Institute Management (SIM)
 * Version              : 1.0
 * License              : Licensed under MIT <http://opensource.org/licenses/MIT>
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace SIM.DAL
{
    public class DBPlayer
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["SIM"].ConnectionString;
        private SqlConnection SqlConnection;
        public SqlCommand command;
        public string cmdText { get; set; }

        public DBPlayer()
        {
            SqlConnection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Parameters.Clear();
        }

        public void Open()
        {
            this.command.CommandText = this.cmdText;
            this.command.Connection = this.SqlConnection;
            this.SqlConnection.Open();
        }

        public void Close()
        {
            this.SqlConnection.Close();
        }
    }
}