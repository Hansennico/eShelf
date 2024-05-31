<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="ViewItem.aspx.cs" Inherits="eShelf_website.View.ViewItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../Style/ViewItem.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class ="ContainerHeader">
        <asp:Panel ID="itemBookCover" runat="server" class="itemBookCover"></asp:Panel>

     

        <div class="ContainerDescription">
            <asp:Label ID="LBtitle" CssClass="BookTitle" runat="server" Text=""></asp:Label>
            
            <asp:Label ID="LBauthor" CssClass="BookAuthor" runat="server" Text=""></asp:Label>

            
            <div class="ContainerExtra">
                <asp:Label ID="LBpublish" runat="server" Text="Published by ... . 23 aufust ."></asp:Label>
                <img src="../Style/Icon/star.png" />
                <asp:Label ID="LBrating" runat="server" Text="4.3"></asp:Label>
            </div>


            <asp:Label ID="BookSypnosis" runat="server" Text="" CssClass="BookSypnosis"></asp:Label>
           
        </div>

  

        <div class="ContainerPayment">
            <div class="BookPrice">
                <asp:Label ID="LBprice" runat="server" Text="Rp.300,000.00"></asp:Label> 
            </div>
              

            <div class="ContainerPaymentInfo">
                <asp:Label  CssClass="LBquantity" runat="server" Text="Set Quantity"></asp:Label>
                <asp:TextBox ID="TBquantity" cssClass="TBquantity" runat="server" TextMode="Number"></asp:TextBox>
                
                <div class="ContainerType">
                    <asp:RadioButton ID="RBphysical" runat="server" GroupName="type" CssClass="RBype"/>
                    <asp:Label ID="LBphysical" runat="server" Text="Physical"></asp:Label>
                    <asp:Label ID="LBphysicalStock" runat="server" Text="400 Stock" CssClass="LBstock"></asp:Label>
                </div>

                <div class="ContainerType">
                    <asp:RadioButton ID="RBdigital" runat="server" GroupName="type" CssClass="RBype"/>
                    <asp:Label ID="LBdigital" runat="server" Text="Digital"></asp:Label>
                    <asp:Label ID="LBdigitalStock" runat="server" Text="400 Stock" CssClass="LBstock"></asp:Label>
                </div>

                <asp:Label ID="LBerror" CssClass="LBerror" runat="server" Text="Error"></asp:Label>

                <asp:Button ID="BTNaddCart" CssClass="BTNaddCart" runat="server" Text="+ Cart" OnClick="BTNaddCart_Click" />
            </div>

            
        </div>


    </div>
</asp:Content>
