<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddressInfo.aspx.cs" Inherits="eShelf_website.View.AddressInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Style/AddressInfo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div id="container">

         <!-- Contact Billing Address, Country, State, Zipcode -->

         <asp:Label ID="LBtitle" runat="server" Text="My Address"></asp:Label>
         <asp:Label ID="LBinfo" runat="server" Text="Please fill the following form"></asp:Label>

         <div class ="ContainerContact">
             <asp:Label ID="LBcontact" runat="server" CssClass="LBinput" Text="Phone Number"></asp:Label> 
              <asp:TextBox ID="TBphone"  CssClass="TBinput" runat="server"></asp:TextBox>
         </div>

         <div id="ContainerAddress">
             <asp:Label ID="LBinput" runat="server" CssClass="LBinput" Text="Billing Address"></asp:Label>
             <asp:TextBox ID="TBaddress" runat="server" TextMode="MultiLine"></asp:TextBox>
         
         </div>

         <div class="ContainerExtra">
             <div class="subextra">
                 <asp:Label ID="LBpostal" runat="server" class ="LBinput" Text="Postal Code"></asp:Label>
                 <asp:TextBox ID="TBpostal" CssClass="TBinput" runat="server"></asp:TextBox>
             </div>
             <div class="subextra">
                 <asp:Label ID="LBcountry" runat="server" class ="LBinput" Text="Country"></asp:Label>
                 <asp:DropDownList ID="DDLcountry" runat="server" CssClass="TBinput"></asp:DropDownList>
             </div>
    
         </div>


         <div class="ContainerExtra">
             <div class="subextra">
                 <asp:Label ID="LBstate" runat="server" class ="LBinput" Text="State"></asp:Label>
                 <asp:TextBox ID="TBstate" CssClass="TBinput" runat="server"></asp:TextBox>
             </div>
             <div class="subextra">
                 <asp:Label ID="LBcity" runat="server" class ="LBinput" Text="City"></asp:Label>
                 <asp:TextBox ID="TBcity" CssClass="TBinput" runat="server"></asp:TextBox>
             </div>
    
         </div>

         <asp:Label ID="LBerror" runat="server" Text="Invalid Email or Password"></asp:Label>

         <div class="ContainerButton">
             <asp:Button ID="BTNskip" CssClass="inputButton" runat="server" Text="Skip" OnClick="BTNskip_Click" />
             <asp:Button ID="BTNsave" CssClass="inputButton" runat="server" Text="Save" OnClick="BTNsave_Click" />
         </div>
     
     
     </div>
    </form>
</body>
</html>
