<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="MantenimientoAeropuertos.aspx.cs" Inherits="MantenimientoAeropuertos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">


        .style1
        {
            width: 414px;
            height: 122px;
        }
        .style4
        {
            height: 37px;
        }
        .style23
        {
            height: 37px;
            width: 138px;
        }
        .style24
        {
            height: 37px;
            width: 1030px;
        }
        .style25
        {
            height: 37px;
            width: 424px;
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
                    Mantenimiento Aeropuertos</td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style24">
                    &nbsp;</td>
            <td align="center" class="style25">
                    <asp:Label ID="lblGood" runat="server" ForeColor="#0099FF"></asp:Label>
            </td>
            <td align="center" class="style23">
                    &nbsp;</td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style24">
                    Codigo del Aeropuerto</td>
            <td align="center" class="style25">
                <asp:TextBox ID="txtCodigoAeropuerto" runat="server"></asp:TextBox>
            </td>
            <td align="center" class="style23">
                <asp:Button ID="btnBuscar" runat="server" BackColor="#99CCFF" 
                    onclick="btnBuscar_Click" Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style24">
                    Nombre del Aeropuerto</td>
            <td align="center" class="style25">
                <asp:TextBox ID="txtNombreAeropuerto" runat="server"></asp:TextBox>
            </td>
            <td align="center" class="style23">
                    &nbsp;</td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style24">
                    Direccion</td>
            <td align="center" class="style25">
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
            <td align="center" class="style23">
                    &nbsp;</td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style24">
                    Impuestos de Arribos</td>
            <td align="center" class="style25">
                <asp:TextBox ID="txtImpuestosA" runat="server"></asp:TextBox>
            </td>
            <td align="center" class="style23">
                    &nbsp;</td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style24">
                    Impuestos de Partidas</td>
            <td align="center" class="style25">
                <asp:TextBox ID="txtImpuestosP" runat="server"></asp:TextBox>
            </td>
            <td align="center" class="style23">
                    &nbsp;</td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style24">
                    Codigo de la Ciudad</td>
            <td align="center" class="style25">
                <asp:TextBox ID="txtCodigoCiudad" runat="server"></asp:TextBox>
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
&nbsp;&nbsp;<asp:Button ID="btnAltaAero" runat="server" BackColor="#99CCFF" 
                    onclick="btnAltaAero_Click" Text="Agregar!" />
&nbsp;<asp:Button ID="btnModAero" runat="server" BackColor="#99CCFF" onclick="btnModAero_Click" 
                    Text="Modificar!" />
&nbsp;<asp:Button ID="btnEliminarAero" runat="server" BackColor="#99CCFF" 
                    onclick="btnEliminarAero_Click" Text="Eliminar!" />
            </td>
            <td align="center" class="style23">
                <asp:Button ID="btnLimpiar" runat="server" BackColor="#CCCCFF" 
                        onclick="btnLimpiar_Click" Text="Limpiar " />
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

