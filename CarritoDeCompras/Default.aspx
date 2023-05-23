<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoDeCompras.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>CARRITO</h1>
    <p>Carrito de compras</p>

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
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn btn-primary" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnAgregar_Click"/>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
