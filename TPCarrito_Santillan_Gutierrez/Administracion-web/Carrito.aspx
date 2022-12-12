<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Administracion_web.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Desde carrito!</h1>
    <table class="table">
        <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("item.Nombre")%></td>
                    <td>
                        <asp:Label ID="lblSubTotal" runat="server" Text='<%#Eval("subtotal") %>'></asp:Label>
                    </td>
                    <td>
                        <div class="btn-toolbar justify-content-between" role="toolbar" aria-label="Toolbar with button groups">
                            <div class="btn-group" role="group" aria-label="First group">
                                <asp:Button ID="btnInc" runat="server" Text="+" type="button" AutoPostBack="true" OnClick="btnInc_Click" class="btn btn-secondary" CommandArgument='<%#Eval("ID")%>' />
                                <asp:Button ID="btnCant" runat="server" Text='<%#Eval("cantidad") %>' type="text" class="btn btn-secondary" AutoPostBack="true" CommandArgument='<%#Eval("ID")%>' />
                                <asp:Button ID="btnDec" runat="server" Text="-" type="button" class="btn btn-secondary" AutoPostBack="true" OnClick="btnDec_Click" CommandArgument='<%#Eval("ID")%>' />
                            </div>
                        </div>

                    </td>
                    <td>
                        <asp:Button Text="Eliminar" CssClass="btn btn-primary" ID="btnEliminar2" AutoPostBack="true" OnClick="btnEliminar2_Click" CommandArgument='<%#Eval("ID")%>' runat="server" />
                    </td>
                </tr>

            </ItemTemplate>
        </asp:Repeater>

    </table>

    <asp:Label Text="" ID="lblPrecioTotal" runat="server" />
</asp:Content>
