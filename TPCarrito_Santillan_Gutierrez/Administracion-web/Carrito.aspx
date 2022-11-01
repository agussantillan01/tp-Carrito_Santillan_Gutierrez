<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Administracion_web.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .oculto {
            display: none;
        }
    </style>
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
                        <asp:Button Id="btnCantidad" type="text" Text='<%#Eval("cantidad") %>' runat="server" autoPostback="true" CommandArgument='<%#Eval("Id") %>'/>
                    </td>
                </tr>

            </ItemTemplate>
        </asp:Repeater>

    </table>

    <asp:Label Text="" ID="lblPrecioTotal" runat="server" />
</asp:Content>
