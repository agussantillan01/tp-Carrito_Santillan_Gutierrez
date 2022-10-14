<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="listaProductos.aspx.cs" Inherits="Administracion_web.listaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Desde lista Productos!</h1>
    <asp:GridView ID="dgvArticulos" runat="server" CssClass="table" AutoGenerateColumns="false"></asp:GridView>
  

    <columns>
        <asp:Boundfield HeaderText="Nombre" dataField="Nombre"/>    
     </columns>
</asp:Content>
