<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pasantias.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" href="CSS/Style.css"/>
    <title>Pasantias</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="loginContainer">
            <h1>Iniciar sesión</h1>
            <asp:Label CssClass="label" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="txtUser" runat="server" placeHolder="Nombre de usuario" CssClass="inputLogin"></asp:TextBox>
            <asp:Label CssClass="label" runat="server" Text="Contraseña: "></asp:Label>
            <asp:TextBox ID="txtPass" runat="server" placeHolder="Contraseña" CssClass="inputLogin" TextMode="Password"></asp:TextBox>
            <asp:Button ID="btnLogin" CssClass="boton" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
            <asp:Label ID="lblMensaje" CssClass="label" runat="server" Text="Usuario o contraseña incorrecta" Color="#ff0000" Visible="false"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Producto Obligatorio" ControlToValidate="txtUser" ForeColor="#ff0000"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Precio Obligatorio" ControlToValidate="txtPass" ForeColor="#ff0000"></asp:RequiredFieldValidator>
        </div>
    </form>
</body>
</html>
