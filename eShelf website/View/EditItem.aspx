<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="EditItem.aspx.cs" Inherits="eShelf_website.View.EditItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../Style/EditItem.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="PNpopUp" CssClass="PNpopUp" runat="server">

        <div class="ContainerPopUp">
            <h2 class="PopUpTitle">Book has been Updated</h2>
            <img src="../Style/Icon/verify.png" />
            <asp:Button ID="BTNclose" CssClass="BTNclose" runat="server" Text="Close" OnClick="BTNclose_Click" />
        </div>
    </asp:Panel>

    <div class="ContainerAll">

        <div class="ContainerItem">
            <span class="ItemTitle">Edit Book</span>
    
            <div class="ContainerBook">
                <!-- Title-->
                <div class="ContainerInput">
                    <span class="InputTitle">Title</span>
                    <asp:TextBox ID="TBtitle" CssClass="InputTB" runat="server"></asp:TextBox>
                </div>

                <!-- Author -->
                <div class="ContainerDoubleInput">
                    <div class="ContainerInput ContainerInput1">
                        <span class="InputTitle">Author</span>
                        <asp:TextBox ID="TBauthor" CssClass="InputTB" runat="server"></asp:TextBox>
                    </div>

                <!-- Genre -->

                    <div class="ContainerInput ContainerInput2">
                        <span class="InputTitle">Genre</span>
                        <asp:DropDownList ID="DDLgenre" CssClass="InputTB" runat="server"></asp:DropDownList>
                    </div>
                </div>
        
                <!-- Sypnosis -->

                <div class="ContainerInput">
                    <span class="InputTitle">Sypnosis</span>
                    <asp:TextBox ID="TBsypnosis" CssClass="InputTB TBsypnosis" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>

                <!-- Price -->

                <div class="ContainerInput">
                    <span class="InputTitle">Price</span>
                    <asp:TextBox ID="TBprice" CssClass="InputTB" TextMode="Number" runat="server" ></asp:TextBox>
                </div>


                <!-- Publisher -->
                <div class="ContainerDoubleInput">
                    <div class="ContainerInput ContainerInput1">
                        <span class="InputTitle">Publisher</span>
                        <asp:TextBox ID="TBpublisher" CssClass="InputTB" runat="server"></asp:TextBox>
                    </div>

                <!-- Publish Date -->

                    <div class="ContainerInput ContainerInput2">
                        <span class="InputTitle">Publish Date</span>
                        <asp:TextBox ID="TBpublishDate" CssClass="InputTB" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>

            <asp:Label ID="LBerror" CssClass="ItemTitle TitleError" runat="server" Text="Please enter all the relevant Information"></asp:Label>
            <div class="ContainerBook ContainerButton">
                <asp:Button ID="BTNcancel" CssClass="BTNinput BTNcancel" runat="server" Text="Cancel" OnClick="BTNcancel_Click" />
                <asp:Button ID="BTNedit" CssClass="BTNinput" runat="server" Text="Edit" OnClick="BTNedit_Click" />
            </div>




        </div>
    </div>

</asp:Content>
