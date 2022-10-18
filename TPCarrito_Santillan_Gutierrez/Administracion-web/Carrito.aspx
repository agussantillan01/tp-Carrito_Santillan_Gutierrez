<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Administracion_web.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <h1>Desde carrito!</h1>
        <div class="row row-cols-1 row-cols-md-3 g-4">
         <asp:Repeater runat="server" id="dgvCarrito" >
            <itemtemplate>
                <div class="col">
                    <div class="card h-100">
                            <h5 ><%#Eval("Nombre")%> </h5>
                            <p><%#Eval("Descripcion") %></p>

                            <a href="detalleArticulo.aspx?Id=<%#Eval("Id")%>">Ver Detalle</a>
                    
                            </div>
                    </div>
                </div>
            </itemtemplate>
        </asp:Repeater>
    </div>
</asp:Content>
