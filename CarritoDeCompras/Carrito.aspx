﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoDeCompras.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Repeater ID="RepCarrito" runat="server">
        <ItemTemplate>
            <div>
                <p><%#Eval("precio") %></p>
                <p><%#Eval("nombre") %></p>
                <p><%#Eval("marca") %></p>
            </div>

        </ItemTemplate>

    </asp:Repeater>

</asp:Content>
