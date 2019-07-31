using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
//using Oracle.ManagedDataAccess.Client;
using System.Data.OracleClient;

namespace SocketServer
{
    /// <summary>
    /// OracleOperation 的摘要说明
    /// </summary>
    public class OracleOperation
    {

        public string ConnectionString { get; set; }
        public OracleOperation(string cnnString)
        {
            //
            // TODO: Add constructor logic here
            //
            this.ConnectionString = cnnString;
        }
        public OracleConnection Connect()
        {
            OracleConnection cnn = new OracleConnection(ConnectionString);
            return cnn;
        }

        public void Disconnect(OracleConnection cnn)
        {
            if (cnn.State != ConnectionState.Closed)
            {
                cnn.Close();
            }
        }

        public void ExecuteNonQuery(string sql)
        {
            OracleConnection cnn = Connect();
            cnn.Open();
            OracleCommand cmd = new OracleCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public DataTable ExecuteQuery(string sql)
        {
            OracleConnection cnn = Connect();
            cnn.Open();
            OracleDataAdapter da = new OracleDataAdapter(sql, cnn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            cnn.Close();
            return ds;
        }

    }
}




