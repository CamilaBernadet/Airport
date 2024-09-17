<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="Principal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 559px;
            height: 69px;
        }
        .style7
        {
            height: 44px;
        }
        .style11
        {
            height: 43px;
            width: 185px;
        }
        .style12
        {
            height: 43px;
        }
        .style13
        {
            height: 44px;
            width: 185px;
        }
        .style14
        {
            height: 44px;
        }
        .style15
        {
            width: 364px;
            height: 69px;
        }
        .style19
        {
            height: 23px;
            }
        .style21
        {
            height: 23px;
            width: 120px;
        }
        .style22
        {
            height: 20px;
            width: 120px;
        }
        .style23
        {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td align="center" class="style11" 
                    style="font-size: x-large; font-style: italic; text-decoration: underline">
                    Pagina Principal</td>
                <td align="right" class="style12">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Menu ID="MenuPrincipal" runat="server" BackColor="#B5C7DE" 
                        DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
                        ForeColor="#284E98" Orientation="Horizontal" StaticSubMenuIndent="10px" 
                        BorderStyle="Outset">
                        <DynamicHoverStyle BackColor="#284E98" ForeColor="White" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicMenuStyle BackColor="#B5C7DE" />
                        <DynamicSelectedStyle BackColor="#507CD1" />
                        <Items>
                            <asp:MenuItem NavigateUrl="~/LogueoEmpleado.aspx" Text="Logueo Empleados" 
                                Value="Logueo Empleados"></asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/LogueoCliente.aspx" Text="Logueo Cliente" 
                                Value="Logueo Cliente"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BackColor="#284E98" ForeColor="White" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticSelectedStyle BackColor="#507CD1" />
                    </asp:Menu>
                </td>
            </tr>
            <tr>
                <td align="center" class="style13">
                    &nbsp;</td>
                <td align="center" class="style7">
                    Aeropuertos:
                    <asp:DropDownList ID="ddlAero" runat="server" BackColor="#D1EFFA" onselectedindexchanged="ddlAero_SelectedIndexChanged" 
                        >
                    </asp:DropDownList>
                &nbsp;
                    <asp:Button ID="btnListar" runat="server" BackColor="#D1EFFA" 
                        onclick="btnListar_Click" Text="Listar" />
                    <br />
                    <br />
                                Vuelos</td>
            </tr>
            <tr>
                <td align="center" class="style13">
                    &nbsp;</td>
                <td align="center" class="style14">
                    <table class="style15">
                        <tr>
                            <td align="center" class="style21">
                                &nbsp;</td>
                            <td align="center" class="style19">
                                Por Partir</td>
                            <td align="center" class="style19">
                                Por Arribar</td>
                        </tr>
                        <tr>
                            <td align="center" class="style21">
                                &nbsp;</td>
                            <td align="center" class="style19">
                                <asp:GridView ID="gvPorPartir" runat="server" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None" 
                                    Height="198px" style="margin-left: 0px" Width="267px" 
                                    onselectedindexchanged="gvPorPartir_SelectedIndexChanged">
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                            <td align="center" class="style19">
                                <asp:GridView ID="gvPorArribar" runat="server" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None" Height="198px" Width="258px" 
                                    onselectedindexchanged="gvPorArribar_SelectedIndexChanged">
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="style22">
                                </td>
                            <td class="style23">
                                </td>
                            <td class="style23">
                                </td>
                        </tr>
                        <tr>
                            <td class="style21">
                                &nbsp;</td>
                            <td class="style19" colspan="2">
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
