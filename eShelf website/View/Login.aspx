<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="eShelf_website.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <img src="../Style/Icon/eShelf%20Logo.png" />
            <asp:Label ID="LBwelcome" runat="server" Text="Please Login to your Account"></asp:Label>
    
            <div class="input">
                <asp:Label ID="LBemail" class="inputLabel" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="TBemail" class="inputTextBox" runat="server" type ="email"></asp:TextBox>
            </div>

            <div class="input">
                <asp:Label ID="LBpassword" class="inputLabel" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="TBpassword" class="inputTextBox" runat="server" type="password"></asp:TextBox>
            </div>

            <div class="rememberBox">
                <asp:CheckBox ID="CBremember" runat="server" /> 
                <asp:Label ID="LBremember" runat="server" Text="Remember Me"></asp:Label>
            </div>

            <asp:Label ID="LBerror" runat="server" Text="Invalid Email or Password"></asp:Label>

            <asp:LinkButton ID="BTNtoRegister" runat="server" OnClick="BTNtoRegister_Click" >Register new Account</asp:LinkButton>
    
            <asp:Button ID="BTNlogin" runat="server" Text="Login" OnClick="BTNlogin_Click"  />

  
        </div>

    </form>
</body>
</html>
