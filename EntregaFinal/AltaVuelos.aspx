<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="AltaVuelos.aspx.cs" Inherits="AltaVuelos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">



        .style1
        {
            width: 414px;
            height: 122px;
        }
        .style24
        {
        height: 37px;
        width: 134px;
    }
        .style4
        {
            height: 37px;
        }
        .style25
        {
            height: 37px;
            width: 424px;
        }
        .style23
        {
            height: 37px;
            width: 138px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="style1">
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            &nbsp;</td>
        <td align="center" bgcolor="#99CCFF" class="style4" colspan="2" 
                    style="color: #000000; font-style: inherit; text-transform: none; font-variant: normal;">
            Alta Vuelos</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            &nbsp;</td>
        <td align="center" class="style25">
            <asp:Label ID="lblGood" runat="server" ForeColor="#99CCFF"></asp:Label>
        </td>
        <td align="center" class="style23">
                    &nbsp;</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            Fecha de Partida</td>
        <td align="center" class="style25">
            <asp:TextBox ID="txtFechaHoraSalida" runat="server"></asp:TextBox>
        </td>
        <td align="center" class="style23">
            <asp:Label ID="lblfecha1" runat="server" ForeColor="#CCCCCC" Text="dd/mm/aaaa"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            Aeropuerto<br />
            Salida</td>
        <td align="center" class="style25">
            <asp:DropDownList ID="ddlSalida" runat="server">
            </asp:DropDownList>
        </td>
        <td align="center" class="style23">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            Fecha de Llegada</td>
        <td align="center" class="style25">
            <asp:TextBox ID="txtFechaHoraLlegada" runat="server"></asp:TextBox>
        </td>
        <td align="center" class="style23">
            <asp:Label ID="lblfecha2" runat="server" ForeColor="#CCCCCC" Text="dd/mm/aaaa"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            Aeropuerto Llegada</td>
        <td align="center" class="style25">
            <asp:DropDownList ID="ddlLlegada" runat="server">
            </asp:DropDownList>
        </td>
        <td align="center" class="style23">
                    &nbsp;</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            Precio Pasaje</td>
        <td align="center" class="style25">
            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
        </td>
        <td align="center" class="style23">
                    &nbsp;</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            Cantidad de asientos</td>
        <td align="center" class="style25">
            <asp:TextBox ID="txtAsientos" runat="server"></asp:TextBox>
        </td>
        <td align="center" class="style23">
                    &nbsp;</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            &nbsp;</td>
        <td align="center" class="style25">
            &nbsp;</td>
        <td align="center" class="style23">
                    &nbsp;</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            &nbsp;</td>
        <td align="center" class="style25">
            <asp:Button ID="btnAltaVuelo" runat="server" BackColor="#99CCFF" 
                onclick="btnAltaVuelo_Click1" Text="Agregar!" />
        </td>
        <td align="center" class="style23">
                    &nbsp;</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            Codigo del Vuelo:</td>
        <td align="center" class="style25">
&nbsp;&nbsp;<asp:Label ID="lblCodigoVuelo" runat="server"></asp:Label>
        </td>
        <td align="center" class="style23">
            <asp:Button ID="btnLimpiar" runat="server" BackColor="#CCCCFF" 
                         Text="Limpiar " onclick="btnLimpiar_Click" />
        </td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            &nbsp;</td>
        <td align="center" class="style25" style="color: #FF0000">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
        <td align="center" class="style23">
                    &nbsp;</td>
    </tr>
</table>
</asp:Content>

