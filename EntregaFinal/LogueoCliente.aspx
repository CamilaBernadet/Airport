<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogueoCliente.aspx.cs" Inherits="LogueoCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="height: 269px;">
        <br />
        Aeropuertos Americanos<br />
        ✈<br />
        Logueo Cliente<br />
        <br />
        <table style="width: 100%;">
            <tr>
                <td align="center">
                    Nro de Pasaporte: 
                    <asp:TextBox ID="txtPasaporte" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    Contraseña:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtContraseñaCli" runat="server" TextMode="Password" 
                        ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnLoginCli" runat="server" Text="Login" 
                        onclick="btnLoginCli_Click" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
