<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoDeCompras.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Tienda</h1>

    <asp:Label Text="Filtrar" runat="server"/>
    <asp:TextBox runat="server" ID="Txtfiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />


    <p>Tienda De Articulos</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("imagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Marca") %></p>
                            <p class="card-text">$<%#Eval("Precio") %></p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>">Ver detalle</a>
                            <asp:Button autoPOSTBACK="true" ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn btn-primary" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnAgregar_Click"/>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
