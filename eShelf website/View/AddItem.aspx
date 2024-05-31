<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="eShelf_website.View.AddItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../Style/AddItem.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <asp:Panel ID="PNpopUp" CssClass="PNpopUp" runat="server">

            <div class="ContainerPopUp">
                <h2 class="PopUpTitle">Book has been Added</h2>
                <img src="../Style/Icon/verify.png" />
                <asp:Button ID="BTNclose" CssClass="BTNclose" runat="server" Text="Close" OnClick="BTNclose_Click" />
            </div>
        </asp:Panel>

    
    <div class="ContainerAll">

        <div class="ContainerItem">
            <span class="ItemTitle">Add Book</span>
        
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

                <!-- Cover -->

                <div class="ContainerInput">
                    <span class="InputTitle">Cover</span>
                    <asp:FileUpload ID="FFcover" CssClass="InputTB" runat="server" />
                </div>

            </div>


            <span class="ItemTitle TitleExtra">Stocking Info</span>
            <div class="ContainerBook">
                <!-- Physical Stock -->
                <div class="ContainerDoubleInput">
                    <div class="ContainerInput ContainerInput3">
                        <span class="InputTitle">Physical Stock</span>
                        <asp:TextBox ID="TBphysicalStock" CssClass="InputTB" Text="0" TextMode="Number" runat="server"></asp:TextBox>
                    </div>

                <!-- Publish Date -->

                    <div class="ContainerInput ContainerInput3">
                        <span class="InputTitle">Digital Stock</span>
                        <asp:TextBox ID="TBdigitalStock" CssClass="InputTB" Text="0" TextMode="Number" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>


            <span class="ItemTitle TitleExtra">Supplier Info</span>
            <div class="ContainerBook">
                <!-- Supplier -->
                <div class="ContainerInput">
                    <span class="InputTitle">Supplier Name</span>
                    <asp:DropDownList ID="DDLsupplier" CssClass="InputTB" runat="server"></asp:DropDownList>
                </div>
            </div>

            <asp:Label ID="LBerror" CssClass="ItemTitle TitleError" runat="server" Text="Please enter all the relevant Information"></asp:Label>
            <div class="ContainerBook ContainerButton">
                <asp:Button ID="BTNcancel" CssClass="BTNinput BTNcancel" runat="server" Text="Cancel" OnClick="BTNcancel_Click" />
                <asp:Button ID="BTNadd" CssClass="BTNinput" runat="server" Text="Add" OnClick="BTNadd_Click" />
            </div>




        </div>
    </div>





</asp:Content>
