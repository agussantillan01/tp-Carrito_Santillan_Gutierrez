<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Administracion_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>DESDE HOME!</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
         <asp:Repeater runat="server" id="repRepetidor">
            <itemtemplate>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%> </h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="detalleArticulo.aspx?Id=<%#Eval("Id")%>">Ver Detalle</a>
                            <asp:Button Text="Agregar" cssClass="btn btn-primary" ID="btnAgregar" runat="server" CommandArgument='<%#Eval("Id")%>' CommandName="ArticuloID" onclick="btnAgregar_Click"/>
                            </div>
                    </div>
                </div>
            </itemtemplate>
        </asp:Repeater>
    </div>
</asp:Content>
