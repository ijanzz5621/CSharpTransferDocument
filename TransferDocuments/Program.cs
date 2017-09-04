using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace TransferDocuments
{
    class Program
    {
        static string ConnectionString = "Data Source=mygbynbyn1ms038; Failover Partner=mygbynbyn1vw025;Initial Catalog=dbTestEngineering;User ID=bluedbadmin;Password=BGR$3efv;Connection Timeout=60;";
        static void Main(string[] args)
        {
            DataSet dsResult = new DataSet();

            dsResult = ExecuteSQL("select * from xxx_socket_master_attach;");

            if (dsResult.Tables.Count > 0 && dsResult.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsResult.Tables[0].Rows)
                {
                    Process(row);
                }

            }

        }

        private static DataSet ExecuteSQL(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            DataSet dsResult = new DataSet();
            try
            {

                conn.Open();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter(sql, conn);
                MyDataAdapter.SelectCommand.CommandTimeout = 300;
                MyDataAdapter.SelectCommand.CommandType = CommandType.Text;
                MyDataAdapter.Fill(dsResult);
                conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return dsResult;
        }

        public static void Process(DataRow row)
        {
            string mainPathFolder = @"\\mygbynbyn1ms037\pteportalv2\Upload\eSocket\Master\";
            string databasePath = @"/Upload/\eSocket\Master";

            ////Drawing
            //if (row["Drawing"].ToString().Trim() != "")
            //{
            //    FileInfo fi = new FileInfo(row["Drawing"].ToString());
            //    if (fi.Exists)
            //    {
            //        //Check destination folder
            //        //If not exist, then create it
            //        string destFolder = mainPathFolder + @"\Drawing\" + row["Model"].ToString() + @"\" + row["SocketID"].ToString();
            //        DirectoryInfo di = new DirectoryInfo(destFolder);
            //        if (!di.Exists)
            //        {
            //            di.Create();
            //        }
            //        fi.CopyTo(destFolder + @"\" + fi.Name, true);

            //        string dbFileName = databasePath + @"\Drawing\" + row["Model"].ToString() + @"\" + row["SocketID"].ToString() + @"\" + fi.Name;
            //        //Update database
            //        string sqlUpd = "update tbl_eSocket_Master set AttachDrawingNo = '" + dbFileName + "' where SocketID = '" + row["SocketID"].ToString() + "';";
            //        ExecuteSQL(sqlUpd);
            //    }
                
            //}

        //    //Image
        //    if (row["Image"].ToString().Trim() != "")
        //    {
        //        FileInfo fi = new FileInfo(row["Image"].ToString());
        //        if (fi.Exists)
        //        {
        //            //Check destination folder
        //            //If not exist, then create it
        //            string destFolder = mainPathFolder + @"\Images\" + row["Model"].ToString().Trim() + @"\" + row["SocketID"].ToString().Trim();
        //            DirectoryInfo di = new DirectoryInfo(destFolder);
        //            if (!di.Exists)
        //            {
        //                di.Create();
        //            }
        //            fi.CopyTo(destFolder + @"\" + fi.Name, true);

        //            string dbFileName = databasePath + @"\Images\" + row["Model"].ToString().Trim() + @"\" + row["SocketID"].ToString().Trim() + @"\" + fi.Name;
        //            //Update database
        //            string sqlUpd = "update tbl_eSocket_Master set AttachImage = '" + dbFileName + "' where SocketID = '" + row["SocketID"].ToString().Trim() + "';";
        //            ExecuteSQL(sqlUpd);
        //        }

        //    }
        //}

            //GRRReport
            if (row["GRR"].ToString().Trim() != "")
            {
                FileInfo fi = new FileInfo(row["GRR"].ToString());
                if (fi.Exists)
                {
                    //Check destination folder
                    //If not exist, then create it
                    string destFolder = mainPathFolder + @"\GRRReport\" + row["Model"].ToString().Trim() + @"\" + row["SocketID"].ToString().Trim();
                    DirectoryInfo di = new DirectoryInfo(destFolder);
                    if (!di.Exists)
                    {
                        di.Create();
                    }
                    fi.CopyTo(destFolder + @"\" + fi.Name, true);

                    string dbFileName = databasePath + @"\GRRReport\" + row["Model"].ToString().Trim() + @"\" + row["SocketID"].ToString().Trim() + @"\" + fi.Name;
                    //Update database
                    string sqlUpd = "update tbl_eSocket_Master set AttachGRRReport = '" + dbFileName + "' where SocketID = '" + row["SocketID"].ToString().Trim() + "';";
                    ExecuteSQL(sqlUpd);
                }

            }
        }

    }
}
