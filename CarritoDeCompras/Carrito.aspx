<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoDeCompras.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="RepCarrito" runat="server">
        <ItemTemplate>
            <div style="display: flex">
                <p><%#Eval("Id") %></p>
                <h2><%#Eval("nombre") %></h2>
                <p style="padding:5px"><%#Eval("marca") %></p>
                <p style="padding:5px">$ <%#Eval("precio") %></p>

                <asp:Button autoPOSTBACK = "true" ID="btnEliminar" runat="server" Text="Eliminar"  CssClass="btn btn-primary" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEliminar_Click"/>
            </div>

        </ItemTemplate>

    </asp:Repeater>
    <div style="display:flex">
        <h3 style="padding:5px">TOTAL: $ </h3>
        <asp:Label ID="lblTotal" runat="server" Text="" style="font-size:30px"></asp:Label>
    </div>
    
    

</asp:Content>
