using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace Intranet.ModuloAdmin.View
{
    public partial class downloader : System.Web.UI.Page
    {
        string conex = @"Data Source=192.168.1.228;Initial Catalog=Intranet2;User ID=cons_intranet;Password=cons_qgchile13;";
        protected void Page_Load(object sender, EventArgs e)
        {
            string guid = Request.QueryString["guid"];

            if (String.IsNullOrEmpty(guid))
            {

            }
            else
            {
                                DataTable dt = document_attachment_GetByGuid(guid);

                if (dt.Rows.Count != 0)
                {

                    string OriginalFileName = dt.Rows[0]["filename"].ToString();

                    DownloadFile(Server.MapPath("./Uploads/") + guid, dt.Rows[0]["filename"].ToString());
                }
            }
        }
        public void DownloadFile(string FilePath, string OriginalFileName)
        {
            FileStream fs = null;
            fs = File.Open(FilePath,FileMode.Open,FileAccess.Read);
            byte[] byteBuffer = new byte[Convert.ToInt64(fs.Length - 1 + 1)];
            fs.Read(byteBuffer, 0, Convert.ToInt32(fs.Length));
            fs.Close();

            MemoryStream ms = new MemoryStream(byteBuffer);
            Response.AddHeader("Content-Disposition", "attachment;filename=" + OriginalFileName);
            ms.WriteTo(Response.OutputStream);
        }
        public DataTable document_attachment_GetByGuid(string guid)
        {

            SqlConnection connexion = new SqlConnection(conex);
            SqlDataAdapter command = new SqlDataAdapter("document_attachment_GetByGuid", connexion);
            command.SelectCommand.CommandType = CommandType.StoredProcedure;
            command.SelectCommand.Parameters.AddWithValue("@guid", guid);
            DataTable dt = new DataTable();
            command.Fill(dt);
            return dt;

        }

    }
}