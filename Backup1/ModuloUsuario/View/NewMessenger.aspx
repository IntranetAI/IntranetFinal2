<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewMessenger.aspx.cs" Inherits="Intranet.ModuloUsuario.View.NewMessenger" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="form" style="margin: 0 auto; width: 350px;">
							<p class="form" id="vorschauname" style="display: block;">
					            Asunto : <br />
                                <asp:TextBox style="width: 100%;" class="form" id="txtAsunto" runat="server"></asp:TextBox>
				            </p>
							<p class="form" id="vorschauemail" style="display: block;">
					            OT y/o Pliegos: <br />
                                <asp:TextBox style="width: 100%;" class="form" id="txtOT" runat="server"></asp:TextBox>
				            </p>
                            <p class="form" id="P1" style="display: block;">
					            Maquina: <br />
                                <asp:TextBox style="width: 100%;" class="form" id="txtMaquina" runat="server"></asp:TextBox>
				            </p>
						    <p class="form" id="vorschaunachricht" style="display: block;">
				                Mensaje: <br />
                                <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" style="width: 100%;" rows="9" class="form"></asp:TextBox>
			                </p>
	                        <p class="form" style="text-align: center;">
                                <asp:Button class="formsubmit" id="vorschausubmit1"  runat="server" 
                                    Text="¡Enviar mensaje!" onclick="vorschausubmit1_Click" />
                            </p>
    </div>
    </form>
</body>
</html>
