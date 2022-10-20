<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Administracion_web.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <style> .oculto      {
               display: none;
 }</style>
    <h1>Desde carrito!</h1>
        <div class="row row-cols-1 row-cols-md-3 g-4">
         <asp:Repeater runat="server" id="dgvCarrito" >
            <itemtemplate>
                <div class="col">
                    <asp:GridView runat="server" ID="dgvCarrito" AutoGenerateColumns="false"></asp:GridView>
                    <columns>
                 
                        <asp:BoundField <h5 ><%#Eval("Id")%> </h5>  />
                       <asp:BoundField <h5 ><%#Eval("Nombre")%> </h5>/>
                           <asp:BoundField   <p><%#Eval("Descripcion") %></p>/>
                         <asp:BoundField   <p><%#Eval("Precio") %></p>/>
                     <%--    <asp:BoundField   <p><%#Eval("Precio") %></p>/>--%>


                            <a href="detalleArticulo.aspx?Id=<%#Eval("Id")%>">Ver Detalle</a>
                    
                   
                    </columns>
                </div>
            </itemtemplate>
        </asp:Repeater>
    </div>
</asp:Content>
