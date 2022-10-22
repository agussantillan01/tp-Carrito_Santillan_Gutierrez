<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="detalleArticulo.aspx.cs" Inherits="Administracion_web.detalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="card" style="width: 18rem;">
        <img src="<% = seleccionado.ImagenUrl %>" class="card-img-top" alt="..." onerror="this.src='https://assets.cdn-shop.com/mi-arte3-es/assets/img/backgrounds/placeholder-8b83e412a5.svg';">
        <div class="card-body">
            <h5><% = seleccionado.Nombre %></h5>
            <p>Descripcion: <% = seleccionado.Descripcion %></p>
            <p>Categoria: <% = seleccionado.Categoria %></p>
            <p>Marca: <% = seleccionado.Marca %></p>
            <p>Precio $: <% = seleccionado.Precio %></p>
            <a class="btn btn-primary" href="Carrito.aspx?id=<% = seleccionado.Id%>" role="button">Agregar Carrito</a>
        </div>
    </div>

</asp:Content>
