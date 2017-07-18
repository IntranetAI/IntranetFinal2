using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace Intranet.ModuloDespacho.View
{
    public partial class Devolucion_Prov : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string[] DatosOT(string OT)
        {
            //Presupuesto_Controller pc = new Presupuesto_Controller();
            //PresupuestadorM m = pc.Carga_Paginas_Pliegos(firstName, 0);
            return new[] { "<table id='Table4' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC; margin: 0 auto; margin-top: 0px; width: 350px;'></table>" };//{ m.FormatoPagina, m.PaginasxPliego };
        }
         //<table id='Table4' runat='server' cellspacing='0' cellpadding='0' style='border: 1px solid #CCC;
         //                   margin: 0 auto; margin-top: 0px; width: 350px;'>
         //                   <tbody>
         //                       <tr style='height: 22px; background: #f3f4f9; font: 11px Arial, Helvetica, sans-serif;
         //                           color: #003e7e; text-align: left;'>
         //                           <td style='font-weight: bold; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
         //                               text-align: center;'>
         //                               Nombre OT
         //                           </td>
         //                           <td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
         //                               text-align: center;' class="style16">
         //                               Proceso Externo
         //                           </td>
         //                           <td style='font-weight: normal; padding: 4px 0 0 5px; border-right: 1px solid #ccc;
         //                               text-align: center;'>
         //                               Cantidad
         //                           </td>
         //                       </tr>
         //                       <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
         //                           color: #333; vertical-align: text-top;'>
         //                           <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
         //                               text-align: center;' class="style16">
         //                               <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
         //                           </td>
         //                           <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
         //                               text-align: center;'>
         //                               <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
         //                           </td>
         //                           <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
         //                               text-align: center;'>
         //                               <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
         //                           </td>
         //                       </tr>
         //                       <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
         //                           color: #333; vertical-align: text-top;'>
         //                           <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
         //                               text-align: center;' class="style16">
         //                               <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
         //                           </td>
         //                           <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
         //                               text-align: center;'>
         //                               <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
         //                           </td>
         //                           <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
         //                               text-align: center;'>
         //                               <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
         //                           </td>
         //                       </tr>
         //                       <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
         //                           color: #333; vertical-align: text-top;'>
         //                           <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
         //                               text-align: center;' class="style16">
         //                               <asp:Label ID="Label18" runat="server" Text=""></asp:Label>
         //                           </td>
         //                           <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
         //                               text-align: center;'>
         //                               <asp:Label ID="Label19" runat="server" Text=""></asp:Label>
         //                           </td>
         //                           <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
         //                               text-align: center;'>
         //                               <asp:Label ID="Label21" runat="server" Text=""></asp:Label>
         //                           </td>
         //                       </tr>
         //                       <tr style='height: 22px; background: #fff; font: 11px Arial, Helvetica, sans-serif;
         //                           color: #333; vertical-align: text-top;'>
         //                           <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
         //                               text-align: center;' class="style16">
         //                               <asp:Label ID="Label60" runat="server" Text=""></asp:Label>
         //                           </td>
         //                           <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
         //                               text-align: center;'>
         //                               <asp:Label ID="Label63" runat="server" Text=""></asp:Label>
         //                           </td>
         //                           <td style='font-weight: normal; padding: 4px 0 5px 5px; border-right: 1px solid #ccc;
         //                               text-align: center;'>
         //                               <asp:Label ID="Label66" runat="server" Text=""></asp:Label>
         //                           </td>
         //                       </tr>
         //                   </tbody>
         //               </table>

    }
}