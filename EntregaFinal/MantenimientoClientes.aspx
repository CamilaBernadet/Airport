<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="MantenimientoClientes.aspx.cs" Inherits="MantenimientoClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style4
        {
            height: 29px;
        }
        .style23
        {
            height: 323px;
            width: 390px;
        }
        .style33
        {
            height: 45px;
            width: 661px;
        }
        .style39
        {
            height: 45px;
            width: 130px;
        }
        .style40
        {
            height: 45px;
            width: 726px;
        }
        .style41
        {
            height: 29px;
            width: 661px;
        }
        .style45
        {
            height: 30px;
            width: 661px;
        }
        .style46
        {
            height: 30px;
            width: 726px;
        }
        .style47
        {
            height: 30px;
            width: 130px;
        }
        .style48
        {
            height: 31px;
            width: 661px;
        }
        .style49
        {
            height: 31px;
            width: 726px;
        }
        .style50
        {
            height: 31px;
            width: 130px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="style23">
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style41">
                    </td>
        <td align="center" bgcolor="#99CCFF" class="style4" colspan="2" 
                    style="color: #000000; font-style: inherit; text-transform: none; font-variant: normal;">
                    Mantenimiento Clientes</td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style45">
                    </td>
        <td align="center" class="style46">
                    <asp:Label ID="lblGood" runat="server" ForeColor="#0099FF"></asp:Label>
        </td>
        <td align="center" class="style47">
                    </td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style45">
                    Nro de Pasaporte</td>
        <td align="center" class="style46">
            <asp:TextBox ID="txtPasaporte" runat="server"></asp:TextBox>
        </td>
        <td align="center" class="style47">
            <asp:Button ID="btnBuscar" runat="server" BackColor="#99CCFF" 
                onclick="btnBuscar_Click" Text="Buscar" />
        </td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style48">
                    Nombre del Cliente</td>
        <td align="center" class="style49">
            <asp:TextBox ID="txtNombreCliente" runat="server"></asp:TextBox>
        </td>
        <td align="center" class="style50">
                    </td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style48">
                    Nro de Tarjeta</td>
        <td align="center" class="style49">
            <asp:TextBox ID="txtTarjeta" runat="server"></asp:TextBox>
        </td>
        <td align="center" class="style50">
                    </td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style45">
                    Contraseña</td>
        <td align="center" class="style46">
            <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
        </td>
        <td align="center" class="style47">
                    </td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style45">
                    </td>
        <td align="center" class="style46">
                    </td>
        <td align="center" class="style47">
                    </td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style33">
                    &nbsp;</td>
        <td align="center" class="style40">
            <asp:Button ID="btnAltaCliente" runat="server" BackColor="#99CCFF" 
                onclick="btnAltaCliente_Click" Text="Agregar!" />
            &nbsp;<asp:Button ID="btnModCliente" runat="server" BackColor="#99CCFF" 
                onclick="btnModCliente_Click" Text="Modificar!" />
&nbsp;<asp:Button ID="btnEliminarCliente" runat="server" BackColor="#99CCFF" 
                onclick="btnEliminarCliente_Click" Text="Eliminar!" />
        </td>
        <td align="center" class="style39">
            <asp:Button ID="btnLimpiar" runat="server" BackColor="#CCCCFF" 
                        onclick="btnLimpiar_Click" Text="Limpiar " />
        </td>
    </tr>
    <tr>
        <td align="center" bgcolor="#99CCFF" class="style33">
                    &nbsp;</td>
        <td align="center" class="style40" style="color: #FF0000">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
        <td align="center" class="style39">
                    &nbsp;</td>
    </tr>
</table>
</asp:Content>

