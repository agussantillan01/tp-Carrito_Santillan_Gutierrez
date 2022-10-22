<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administracion_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <h1>DESDE HOME!</h1>

 <div class="row">
<% foreach (dominio.Articulo item in ListaArticulos)
   {%>

     <div class="col">
       <div class="card h-100">
         <img src="<% = item.ImagenUrl %>" class="card-img-top" alt="..." onerror="this.src='https://assets.cdn-shop.com/mi-arte3-es/assets/img/backgrounds/placeholder-8b83e412a5.svg';">
         <div class="card-body">
          <h5 class="card-title"><% = item.Nombre %></h5>
          <p class="card-text"><%= item.Descripcion %></p>
          <p class="card-text"><%= item.Precio %></p>
          <a href="DetalleArticulo.aspx?id=<% = item.Id %>" class="btn btn-primary">Ver Detalle</a>
          </div>
         </div>
       </div>


 <%} %>
 </div>
</asp:Content>
