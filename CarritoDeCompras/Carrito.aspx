<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoDeCompras.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="RepCarrito" runat="server">
        <ItemTemplate>
            <div>
                <p><%#Eval("Id") %></p>
                <h2><%#Eval("nombre") %></h2>
                <p>$ <%#Eval("precio") %></p>
                <p><%#Eval("marca") %></p>
                
                <asp:Button autoPOSTBACK = "true" ID="btnEliminar" runat="server" Text="Eliminar"  CssClass="btn btn-primary" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEliminar_Click"/>
            </div>

        </ItemTemplate>

    </asp:Repeater>

    <h3>TOTAL: $ </h3>
    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
    

</asp:Content>
