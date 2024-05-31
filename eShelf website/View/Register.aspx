<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="eShelf_website.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/Register.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">

            <!-- Name, Email, Password, Confirm Password, TOS, to ogin, Register-->

            <img src="../Style/Icon/eShelf%20Logo.png" />
            <asp:Label ID="LBwelcome" runat="server" Text="Please enter the following information"></asp:Label>

            <div class="input">
                <asp:Label ID="LBname" class="inputLabel" runat="server" Text="Name"></asp:Label>
                <asp:TextBox ID="TBname" class="inputTextBox" runat="server" ></asp:TextBox>
            </div>

            <div class="input">
                <asp:Label ID="LBemail" class="inputLabel" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="TBemail" class="inputTextBox" runat="server" type ="email"></asp:TextBox>
            </div>

            <div class="input">
                <asp:Label ID="LBpassword" class="inputLabel" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="TBpassword" class="inputTextBox" runat="server" type="password"></asp:TextBox>
            </div>

            <div class="input">
                <asp:Label ID="LBconfirm" class="inputLabel" runat="server" Text="Confirm Password"></asp:Label>
                <asp:TextBox ID="TBconfirm" class="inputTextBox" runat="server" type="password"></asp:TextBox>
            </div>

            <div class="tosBox">
                <asp:CheckBox ID="CBtos" runat="server" /> 
                <asp:Label ID="LBtos" runat="server" Text="I agree to the Term and Service"></asp:Label>
            </div>

            <asp:Label ID="LBerror" runat="server" Text="Invalid Email or Password"></asp:Label>

            <asp:LinkButton ID="BTNtoLogin" runat="server" OnClick="BTNtoLogin_Click">Already have an Account?</asp:LinkButton>

            <asp:Button ID="BTNRegister" runat="server" Text="Register" OnClick="BTNRegister_Click" />

        </div>
    </form>
</body>
</html>
