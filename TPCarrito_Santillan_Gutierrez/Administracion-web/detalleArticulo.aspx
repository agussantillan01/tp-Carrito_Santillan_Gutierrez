<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="detalleArticulo.aspx.cs" Inherits="Administracion_web.detalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <%foreach (dominio.Articulo art in ListaArticulos)
            { %>

             <div class="card" style="width: 18rem; text-align:center;">
                <img src="<%:art.ImagenUrl%>" class="card-img-top" alt="...">
                <div class="card-body">
                    <hr />
                    <h5 class="card-title"><%:art.Nombre%></h5>
                    <p class="card-text"><%:art.Descripcion%></p>
                    <p class="card-text">Marca:  <%:art.Marca.NombreMarca%></p>
                    <%if (art.Categoria.Tipo != null)
                    {%>
                    <p class="card-text">tipo de articulo: <%:art.Categoria.Tipo%></p>
                    <%}%>
                    <p class="card-text">$  <%:art.Precio.ToString()%></p>
                </div>
            </div>


        <% } %>

</asp:Content>
