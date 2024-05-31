<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="eShelf_website.View.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../Style/ViewCart.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <asp:Panel ID="PNpopUp" CssClass="PNpopUp" runat="server">

      <div class="ContainerPopUp">
          <h2 class="PopUpTitle">Transaction Verified</h2>
          <img src="../Style/Icon/verify.png" />
          <asp:Button ID="BTNclose" CssClass="BTNclose" runat="server" Text="Close" OnClick="BTNclose_Click" />
      </div>
  </asp:Panel>

    <div class="ContainerCart">
        <h3 class="CartTitle">My Cart</h3>
        <div class="CartLine"></div>

        <asp:Panel ID="PNempty" CssClass="ContainerEmpty" runat="server">
            <img src="../Style/Icon/out-of-stock.png" />
            <div class="TitleEmpty">
                Your Cart is Empty
            </div>
        </asp:Panel>



        <asp:Panel ID="PNcontainerItem" runat="server">


            <!--
            <div class="ContainerItem">
                <div class="BookCover"></div>
                <div class="ContainerBookDescription">
                    <div class="ContainerBookDescriptionHeader">
                        <asp:Label ID="LBtitle" CssClass="BookTitle"  runat="server" Text="Game of Thrones"></asp:Label>
                        <asp:Label ID="LBAuthor" CssClass="BookAuthor"  runat="server" Text="George R. R. Martin"></asp:Label>
                        <asp:Label ID="LBgenre" CssClass="BookGenre"  runat="server" Text="Fantasy"></asp:Label>
                    </div>

                    <div class="ContainerBookDescriptionTail">
                        <asp:Label ID="LBprice" CssClass="BookPrice" runat="server" Text="Rp. 400,000.00"></asp:Label>
                        <div class="ContainerCartButton">
                            <asp:Button ID="BTNdelete" CssClass="BTNdelete BTNcart" runat="server"  />

                            <div class="ContainerUpdate">
                                <asp:Button ID="BTNminItem" CssClass="BTNupdate BTNcart" runat="server" Text="-" />
                                <asp:Label ID="BookQuantity" CssClass="BookQuantity" runat="server" Text="2"></asp:Label>
                                <asp:Button ID="BTNmaxItem" CssClass="BTNupdate BTNcart" runat="server" Text="+" />
                            </div>
                        
                        </div>
                    </div>

                
                </div>
            </div>

             <div class="CartLine"></div>
            -->

        </asp:Panel>

    </div>

    <div class="ContainerPlaceholder"></div>




    <div class="ContainerOrder">
        <div class="OrderSubtitle">Order Summary</div>


        <asp:Panel ID="PNcontainerOrderDetail" CssClass="PNcontainerOrderDetail" runat="server">
            <!--
            <div class="ContainerOrderDetail">
                <asp:Label ID="BookOrderTitle" runat="server" Text="2x Game of Thrones"></asp:Label>
                <asp:Label ID="BookOrderPrice"  runat="server" Text="Rp. 400,000.00"></asp:Label>
            </div>
            -->

        </asp:Panel>
        
 

        <div class="CartLineOrder"></div>


        <div class="ContainerOrderDetail">
            <asp:Label ID="LBsubtotal" runat="server" Text="Subtotal"></asp:Label>
            <asp:Label ID="LBsubtotalPrice"  runat="server" Text="Rp. 400,000.00"></asp:Label>
        </div>

        <div class="ContainerOrderDetail">
            <asp:Label ID="LBtax" runat="server" Text="Tax"></asp:Label>
            <asp:Label ID="LBtaxPrice" runat="server" Text="Rp. 50,000.00"></asp:Label>
        </div>

        <div class="ContainerOrderDetail">
            <asp:Label ID="LBtotal" runat="server" CssClass="totalPrice" Text="Order Total"></asp:Label>
            <asp:Label ID="LBtotalPrice" runat="server" CssClass="totalPrice totalPriceVal" Text="Rp. 50,000.00"></asp:Label>
        </div>

        <div class="CartLineOrder"></div>

        <div class="ContainerOrderDetail">
            <asp:Label ID="Label1" runat="server" CssClass="totalPrice" Text="Payment Method"></asp:Label>
            <asp:DropDownList ID="DDLpaymentMethod" CssClass="DDLpaymentMethod" runat="server"></asp:DropDownList>
        </div>

        
        <asp:Button ID="BTNcheckout"  CssClass="BTNcheckout" runat="server" Text="Button" OnClick="BTNcheckout_Click" />
    </div>

  

</asp:Content>
