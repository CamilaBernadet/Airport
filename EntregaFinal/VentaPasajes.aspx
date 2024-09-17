<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="VentaPasajes.aspx.cs" Inherits="VentaPasajes" %>

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
            Venta de Pasajes</td>
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
            Vuelo</td>
        <td align="center" class="style25">
            <asp:DropDownList ID="ddlVuelo" runat="server" BackColor="#99CCFF">
            </asp:DropDownList>
        </td>
        <td align="center" class="style23">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            Cliente</td>
        <td align="center" class="style25">
            <asp:DropDownList ID="ddlCliente" runat="server" BackColor="#99CCFF">
            </asp:DropDownList>
        </td>
        <td align="center" class="style23">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            Numero de Venta</td>
        <td align="center" class="style25">
            <asp:Label ID="lblNroVenta" runat="server"></asp:Label>
        </td>
        <td align="center" class="style23">
                    &nbsp;</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            Fecha</td>
        <td align="center" class="style25">
            <asp:Label ID="lblFecha" runat="server"></asp:Label>
        </td>
        <td align="center" class="style23">
                    &nbsp;</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style24">
            Precio Total</td>
        <td align="center" class="style25">
            <asp:Label ID="lblPrecioTotal" runat="server"></asp:Label>
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
            <asp:Button ID="btnAgregarPasaje" runat="server" BackColor="#99CCFF" 
                Text="Agregar!" onclick="btnAgregarPasaje_Click" />
&nbsp;&nbsp;</td>
        <td align="center" class="style23">
            <asp:Button ID="btnLimpiar" runat="server" BackColor="#CCCCFF" 
                         Text="Limpiar " OnClick="btnLimpiar_Click" />
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

