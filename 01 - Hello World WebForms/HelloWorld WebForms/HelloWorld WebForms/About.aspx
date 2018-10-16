<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="HelloWorld_WebForms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <p> <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label> </p>
    <p> <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox> </p>
    <p> <asp:Label ID="lblApellido" runat="server" Text="Apellido:"></asp:Label> </p>
    <p> <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox> </p>
    <p> <asp:Button ID="btnSaludar" runat="server" Text="Saludar" OnClick="btnSaludar_Click" /> </p>
    <p> <asp:Label ID="lblResultado" runat="server" Text="Resultado"></asp:Label> </p>
    
</asp:Content>
