<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarritoDeCompras.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Tienda</h1>

    <asp:Label Text="Buscar" runat="server" style="padding-right:10px; padding-bottom:10px"/>
    <asp:TextBox runat="server" ID="Txtfiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" style="width:200px" Placeholder="Buscar por nombre..."/>


    <p>Tienda De Articulos</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("imagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <p class="card-text" style="font-weight:bold;font-size:25px">$<%#Eval("Precio") %></p>
                            
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Marca") %></p>
                            
                            <div style="display:flex; float:left;padding-left:20px">
                                <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>" style="padding-right:15px">Ver detalle</a>
                            </div>
                            
                            <div style="display:flex; float:right;padding-right:20px">
                                <asp:Button style="" autoPOSTBACK="true" ID="btnAgregar" runat="server" Text="Agregar"  CssClass="btn btn-primary" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnAgregar_Click"/>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
