    <%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="eShelf_website.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../Style/Home.css" rel="stylesheet" />
    <link href="../Style/HomeItem.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="ContainerFilter">
         <asp:Label ID="LBfilter" CssClass="subtitle" runat="server" Text="Filter"></asp:Label>
     
         <div class="ContainerFilterItem">

             <asp:Panel ID="PNcategory" CssClass="PNsubFilter" runat="server">
                 <asp:Label ID="LBcategoryItem" CssClass="LBsubtitleContainerItem" runat="server" Text="Category"></asp:Label>
             </asp:Panel>

             <div class="line"></div>

             <asp:Panel ID="PNprice" CssClass="PNsubFilter" runat="server">
                 <asp:Label ID="LBpriceItem" CssClass="LBsubtitleContainerItem" runat="server" Text="Price"></asp:Label>

                 <div class="ContainerInputPrice">
                     Rp. 
                     <asp:TextBox ID="TBminPrice" CssClass="TBinputPrice" runat="server" Placeholder="Min Price" TextMode="Number"></asp:TextBox>
                 </div>

                 <div class="ContainerInputPrice">
                     Rp. 
                     <asp:TextBox ID="TBmaxPrice" CssClass="TBinputPrice" runat="server" Placeholder="Max Price" TextMode="Number"></asp:TextBox>
                 </div>
             </asp:Panel>

             <div class="line"></div>

             <asp:Button ID="BTNfilter" CssClass="BTNfilter" runat="server" Text="Filter" OnClick="BTNfilter_Click" />
         </div>
     </div>



     <div id="ContainerPlaceholder"></div>
 
     <div class="ContainerShowItems">
        <div class="ContainerSubtitleItem">
            eShelf
            <asp:Label ID="LBshowFilter" CssClass="LBshowFilter" runat="server" Text="Label"></asp:Label>
        </div>


     
         <asp:Panel ID="PNcontainerShowItem" CssClass="PNcontainerShowItem" runat="server">

             
             <!--
             <asp:LinkButton ID="LinkButton1" class="ContainerItem" runat="server">
             
                 <div class="itemBookCover"></div>
                 <asp:Label ID="Label1" CssClass="itemTitle" runat="server" Text="Game of Throne: Song of Ice and Fire"></asp:Label>
                 <asp:Label ID="Label2" CssClass="itemAuthor" runat="server" Text="author"></asp:Label>
                 <asp:Label ID="Label3" CssClass="itemPrice" runat="server" Text="Rp.100.000.000.000"></asp:Label>   
                 <div class="ContainerItemRating">
                     <img src="../Style/Icon/star.png" />
                     <asp:Label ID="Label4" runat="server" Text="4.3"></asp:Label>
                 </div>
             </asp:LinkButton>
             -->
             
 
        

         </asp:Panel>
     </div>
</asp:Content>
