<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="MantenimientoCiudades.aspx.cs" Inherits="MantenimientoCiudades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style1
        {
            width: 414px;
            height: 122px;
        }
        .style16
        {
            height: 30px;
            width: 661px;
        }
        .style4
        {
            height: 30px;
        }
        .style19
        {
            height: 30px;
            width: 695px;
        }
        .style17
        {
            height: 30px;
            width: 138px;
        }
        .style18
        {
            height: 31px;
            width: 661px;
        }
        .style20
        {
            height: 31px;
            width: 695px;
        }
        .style15
        {
            height: 31px;
            width: 138px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="style1">
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style16">
                    &nbsp;</td>
            <td align="center" bgcolor="#99CCFF" class="style4" colspan="2" 
                    style="color: #000000; font-style: inherit; text-transform: none; font-variant: normal;">
                    Mantenimiento Ciudades</td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style16">
                    &nbsp;</td>
            <td align="center" class="style19">
                    <asp:Label ID="lblGood" runat="server" ForeColor="#0099FF"></asp:Label>
            </td>
            <td align="center" class="style17">
                    &nbsp;</td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style16">
                    Codigo de la Ciudad</td>
            <td align="center" class="style19">
                <asp:TextBox ID="txtCodigoCiudad" runat="server"></asp:TextBox>
            </td>
            <td align="center" class="style17">
                <asp:Button ID="btnBuscarCiudad" runat="server" BackColor="#99CCFF" 
                        onclick="btnBuscarCiudad_Click" Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style16">
                    Nombre de la Ciudad</td>
            <td align="center" class="style19">
                <asp:TextBox ID="txtNombreCiudad" runat="server"></asp:TextBox>
            </td>
            <td align="center" class="style17">
                    &nbsp;</td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style18">
                    Pais</td>
            <td align="center" class="style20">
                <asp:TextBox ID="txtPais" runat="server"></asp:TextBox>
            </td>
            <td align="center" class="style15">
                    &nbsp;</td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style18">
                    &nbsp;</td>
            <td align="center" class="style20">
                    &nbsp;</td>
            <td align="center" class="style15">
                    &nbsp;</td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style18">
                    &nbsp;</td>
            <td align="center" class="style20">
                <asp:Button ID="btnAltaCiudad" runat="server" BackColor="#99CCFF" 
                        onclick="btnAltaCiudad_Click" Text="Agregar!" Width="56px" />
&nbsp;<asp:Button ID="btnModCiudad" runat="server" BackColor="#99CCFF" onclick="btnModCiudad_Click" 
                        Text="Modificar!" />
&nbsp;<asp:Button ID="btnEliminarCiudad" runat="server" BackColor="#99CCFF" 
                        onclick="btnEliminarCiudad_Click" Text="Eliminar!" />
            </td>
            <td align="center" class="style15">
                <asp:Button ID="btnLimpiar" runat="server" BackColor="#CCCCFF" 
                        onclick="btnLimpiar_Click" Text="Limpiar " />
            </td>
        </tr>
        <tr>
            <td align="center" bgcolor="#99CCFF" class="style18">
                    &nbsp;</td>
            <td align="center" class="style20" style="color: #FF0000">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td align="center" class="style15">
                    &nbsp;</td>
        </tr>
    </table>
</asp:Content>

