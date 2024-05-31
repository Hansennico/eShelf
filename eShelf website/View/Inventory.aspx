<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="eShelf_website.View.Inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../Style/Inventory.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="ContainerItem">
        <div class="ContainerHeader">
            <span class="ItemTitle">Inventory Management</span>
            <asp:Button ID="BTNbook" CssClass="BTNheader" runat="server" Text="Add Book" OnClick="BTNbook_Click" />
            <asp:Button ID="BTNrestock" CssClass="BTNheader" runat="server" Text="Restock" OnClick="BTNrestock_Click" />
        </div>

        

        
        <div class="ContainerBook">
            <div class="ContainerBookRow BookRowHeader">

                <asp:CheckBox ID="CBrestockAll" CssClass="CBbook" runat="server" />

                <div class="BookInfo BookHeader">Book ID</div>
                <div class="BookInfo BookHeader">Book Title</div>
                <div class="BookInfo BookHeader">Price</div>
                <div class="BookInfo BookHeader">Physical Stock</div>
                <div class="BookInfo BookHeader">Digital Stock</div>

                <div class="BookInfo BookHeader">Update</div>
                <!--<div class="BookInfo BookHeader">Delete</div>-->

            </div>

            
            <asp:Panel ID="PNbookItem" CssClass="PNbookItem" runat="server">
                <!--
                <div class="ContainerBookRow">
                    <asp:CheckBox ID="CBrestock" CssClass="CBbook" runat="server" />

                    <div class="BookInfo">BO001</div>
                    <div class="BookInfo">Game of Throne</div>
                    <div class="BookInfo">Price</div>
                    <div class="BookInfo">2</div>
                    <div class="BookInfo">3</div>


                    <asp:LinkButton ID="BTNbookEdit" CssClass="BookInfo BTNbook BTNbookEdit" runat="server">Edit</asp:LinkButton>
                    <asp:LinkButton ID="BTNbookRemove" CssClass="BookInfo BTNbook BTNbookRemove" runat="server">Remove</asp:LinkButton>
                </div>
                    -->
            </asp:Panel>
    
        </div>
    </div>

    <!--
    <div class="ContainerPlaceholder"></div>

    <div class="ContainerSummary"> test</div>
    -->

</asp:Content>
