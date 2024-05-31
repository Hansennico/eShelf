<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="Restock.aspx.cs" Inherits="eShelf_website.View.ConfirmRestock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../Style/Restock.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="PNpopUp" CssClass="PNpopUp" runat="server">

        <div class="ContainerPopUp">
            <h2 class="PopUpTitle">Restock Verified</h2>
            <img src="../Style/Icon/verify.png" />
            <asp:Button ID="BTNclose" CssClass="BTNclose" runat="server" Text="Close" OnClick="BTNclose_Click" />
        </div>
    </asp:Panel>

    <div class="ContainerItem">
        <div class="ContainerHeader">
            <span class="ItemTitle">Restock Management</span>
            <asp:Button ID="BTNcancel" CssClass="BTNheader BTNcancel" runat="server" Text="Cancel" OnClick="BTNcancel_Click"  />
            <asp:Button ID="BTNconfirm" CssClass="BTNheader" runat="server" Text="Confirm" OnClick="BTNconfirm_Click"  />
        </div>

    
        
    
        <div class="ContainerBook">
            <div class="ContainerBookRow BookRowHeader">


                <div class="BookInfo BookHeader">Book ID</div>
                <div class="BookInfo BookHeader">Book Title</div>
                <div class="BookInfo BookHeader">Physical Restock</div>
                <div class="BookInfo BookHeader">Digital Retock</div>


            </div>

        
            <asp:Panel ID="PNbookItem" CssClass="PNbookItem" runat="server">
                
                <!--
                <div class="ContainerBookRow">

                    <div class="BookInfo">BO001</div>
                    <div class="BookInfo">Game of Throne</div>

                    <asp:TextBox ID="TBphysical" CssClass="BookInfo BookTB" runat="server" Text="50" TextMode="Number" ></asp:TextBox>
                    <asp:TextBox ID="TBdigital" CssClass="BookInfo BookTB" runat="server" Text="50" TextMode="Number" ></asp:TextBox>

                  
                </div>
                -->
                    
            </asp:Panel>
        </div>
    </div>

</asp:Content>
