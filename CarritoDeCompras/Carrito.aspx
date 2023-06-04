<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="CarritoDeCompras.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="RepCarrito" runat="server">
        <ItemTemplate>
            <div style="display: flex">
                <p ><%#Eval("Id") %></p>
                <h2><%#Eval("nombre") %></h2>
                <p style="padding:5px; font-size:20px"><%#Eval("marca") %></p>
                
                
                <div style="display:flex">
                    <div style="padding-left:20px;padding-right:10px; padding-bottom:5px">
                        <asp:Button ID="btnMenos" runat="server" Text=" - " CssClass="btn btn-primary" style="" />
                    </div>
                    
                    <div  style="padding-right:5px;padding-left:10px">
                        <asp:TextBox ID="txtBoxCantidad" ReadOnly="true" Enabled="false" runat="server" style="width:35px;padding-top:5px;background-color:white"></asp:TextBox>
                    </div>
                    <div style="padding-right:15px;padding-left:20px">
                        <asp:Button ID="btnMas" runat="server" Text=" + " CssClass="btn btn-primary"/>
                    </div>
                    
                </div>
                
                <p style="padding-left:5px;padding-right:10px; font-size:20px">$ <%#Eval("precio") %></p>

                <div>
                    <asp:Button autoPOSTBACK = "true" ID="btnEliminar" runat="server" Text="Eliminar"  CssClass="btn btn-primary" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnEliminar_Click"/>
                </div>
                
            </div>

        </ItemTemplate>

    </asp:Repeater>
    <div style="display:flex">
        <h3 style="padding:5px">TOTAL: $ </h3>
        <asp:Label ID="lblTotal" runat="server" Text="" style="font-size:30px"></asp:Label>
    </div>
    
    

</asp:Content>
