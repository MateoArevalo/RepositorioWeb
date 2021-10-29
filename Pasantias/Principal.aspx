﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Pasantias.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="/your-path-to-fontawesome/css/fontawesome.css" rel="stylesheet" />
    <title>Web 1</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <h1>Bienvenido</h1>
            <asp:HiddenField ID="hdfIdProducto" runat="server" />
            <asp:TextBox ID="txtProducto" runat="server"></asp:TextBox>
            <asp:DropDownList ID="cbxCategoria" runat="server"></asp:DropDownList>
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtPrecio" runat="server" TextMode="Number" step="0.01" min="0"></asp:TextBox>
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
        </div>
        <div class="Table">
            <ContentTemplate>
                <asp:GridView ID="grvProducto" runat="server" AutoGenerateColumns="false" EmptyDataText="No hay productos disponibles">
                    <Columns>
                        <asp:BoundField DataField="idProducto" HeaderText="Id" Visible="false" />
                        <asp:BoundField DataField="producto" HeaderText="Producto" ReadOnly="true"/>
                        <asp:BoundField DataField="categoria" HeaderText="Categoria" ReadOnly="true" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" ReadOnly="true"/>
                        <asp:BoundField DataField="precio" HeaderText="Precio" ReadOnly="true" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnSeleccionarProducto" runat="server" CommandArgument='<%#Eval("idProducto")%>' ImageUrl="Icons/edit.png" OnClick="btnSeleccionarProducto_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEliminarProducto" runat="server" CommandArgument='<%#Eval("idProducto")%>' ImageUrl="Icons/trash.png" OnClick="btnEliminarProducto_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </div>
    </form>
</body>
</html>