
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServicioWeb.ModuloProduccion.Controller;
using ServicioWeb.ModuloProduccion.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ServicioWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        PapelController pc = new PapelController();
        ProduccionController pcc = new ProduccionController();
        protected void Page_Load(object sender, EventArgs e)
        {
          //  Label1.Text = pc.StockFL(DateTime.Now, DateTime.Now);

            //Label2.Text = pcc.OtLiberadas_ItemsPedido("");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            XMLController xc = new XMLController();
            var json = @"[{'anchorPoint':{'x':17939,'y':5392},'id':'2F178052BF5F004283EDC206F8330A8D','type':3,'item':{'ItemType':0,'ItemState':0,'ItemId':'007AB63D53FBDC4BAE1013C88AA452E6','JobId':'2F3A02A32F3A02A32F3A74313F019AE7','PageId':'2F3A02A32F3A02A32F3A74313F0A4F76','SpeRevisionId':'','VersionId':'','FolderId':null,'TaskId':null,'ElementId':null,'RevisionId':null},'userId':'6593A420A659CE44B8793BD3FB8F7F18','creatorUserName':'Claudia Vivanco (PM Abarrotes)','creationDate':'2020-02-28T16:56:00.452Z','lastModificationDate':'2020-02-28T16:56:19.174Z','lastModifiedBy':'Claudia Vivanco (PM Abarrotes)','color':{'r':0,'g':190,'b':215},'annotationNumber':8,'userComment':'Agregar oferta: PASTA TRADICIONAL LUCCHETTI VARIEDADES 400G 2X$1.099\nSAP\n264982\n265797\n542822\n265549\n265554\n265758\n267569\n267620\n267624\n','userCommentAnchor':null,'approverId':null,'approveStatus':0,'approver':null,'approveDate':'0001-01-01T00:00:00','approveStatusComment':null,'parentAnnotationId':0,'canPostAnnotation':false,'annotCalibrationStatus':false}]";
            List<JsonHistorial_Entrada> entrada = xc.PinergyHistorial();
            JArray jsss = JArray.Parse(json);
            JObject data = JObject.Parse(jsss[0].ToString());
            Label2.Text = data["creatorUserName"].ToString();

            List<JsonHistorial_Salida> lSalidas = new List<JsonHistorial_Salida>();
            List<JsonHistorial_Salida> lista = new List<JsonHistorial_Salida>();
            foreach (var item in entrada)
            {
                JsonHistorial_Salida nbb = new JsonHistorial_Salida();
                nbb.Usuario = item.Usuario;
                nbb.Fecha = item.Fecha;
                nbb.OT = item.OT;
                JArray jaa = JArray.Parse(item.Json);
                try
                {
                    JObject data2 = JObject.Parse(jaa[0].ToString());
                    nbb.Json = data2["userComment"].ToString();
                }
                catch(Exception ex)
                {
                    nbb.IDError = item.Id;
                }
                lista.Add(nbb);
            }
            GridView GridView1 = new GridView();
            GridView1.DataSource = lista;
            GridView1.DataBind();
            ExportToExcel("Prueba","Titulo",GridView1);
        }

        private void ExportToExcel(string nameReport, string Titulo, GridView wControl)
        {
            try
            {
                HttpResponse response = Response;
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                Page pageToRender = new Page();
                HtmlForm form = new HtmlForm();
                Label la = new Label();

                la.Text = "<div align='center'>Informe Estado OT</div><div align='center'>";
                form.Controls.Add(la);
                form.Controls.Add(wControl);
                pageToRender.Controls.Add(form);
                response.Clear();
                response.Buffer = true;
                response.ContentType = "application/vnd.ms-excel";
                response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport + ".xls");
                response.Charset = "UTF-8";
                response.ContentEncoding = Encoding.Default;
                pageToRender.RenderControl(htw);
                response.Write(sw.ToString());
                response.End();
            }
            catch (Exception exx)
            {

            }
        }
    }
}