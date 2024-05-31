<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="eShelf_website.View.UserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <link href="../Style/UserInfo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <!-- User Info -->
    <div class="ContainerItem">
        <span class="ContainerTitle">User Info</span>

        <!-- name -->
        <div class="ContainerInfo">
            <div class="InfoTitle">Name</div>
            <asp:Label ID="LBuserName" CssClass="InfoDetail" runat="server" Text="jhonny"></asp:Label>
        </div>

        <!-- Email -->
        <div class="ContainerInfo">
            <div class="InfoTitle">Email</div>
            <asp:Label ID="LBuserEmail" CssClass="InfoDetail" runat="server" Text="jhonny"></asp:Label>
        </div>

        <!-- Phone -->
        <div class="ContainerInfo">
            <div class="InfoTitle">Phone Number</div>
            <asp:Label ID="LBuserPhone" CssClass="InfoDetail" runat="server" Text="jhonny"></asp:Label>
        </div>

        <!-- Billing Address -->
        <div class="ContainerInfo">
            <div class="InfoTitle">Billing Address</div>
            <asp:Label ID="LBuserAddress" CssClass="InfoDetail InfoAddress" runat="server" Text="test"></asp:Label>
        </div>

        <div class="ContainerInfoDouble">
            <!--Country-->
            <div class="ContainerInfo1">
                <div class="InfoTitle">Country</div>
                <asp:Label ID="LBuserCountry" CssClass="InfoDetail" runat="server" Text="jhonny"></asp:Label>
            </div>

            <!-- Postal Code -->
            <div class="ContainerInfo1">
                <div class="InfoTitle">Postal Code</div>
                <asp:Label ID="LBuserPostalCode" CssClass="InfoDetail" runat="server" Text="jhonny"></asp:Label>
            </div>
        </div>

        <div class="ContainerInfoDouble">
            <!--State-->
            <div class="ContainerInfo1">
                <div class="InfoTitle">State</div>
                <asp:Label ID="LBuserState" CssClass="InfoDetail" runat="server" Text="jhonny"></asp:Label>
            </div>

            <!-- City -->
            <div class="ContainerInfo1">
                <div class="InfoTitle">City</div>
                <asp:Label ID="LBuserCity" CssClass="InfoDetail" runat="server" Text="jhonny"></asp:Label>
            </div>
        </div>

    </div>


    <!-- Place holder -->
    <div class="Placeholder"></div>

    <!-- Transaction History -->
    <div class="ContainerItem">
        <span class="ContainerTitle">Transaction History</span>

        <div class="TransactionHeader">
            <span class="tDate">Date</span>
            <span class="tMethod">Method</span>
            <span class="tAmount">Amount</span>
        </div>

        <asp:Panel ID="PNhistory" CssClass="PNhistory" runat="server">
            <!--
            <div class="TransactionDetail">
                <span class="tDate">12 January 2004</span>
                <span class="tMethod">Debit Card</span>
                <span class="tAmount">Rp.200.000.000</span>
            </div>
            -->
        </asp:Panel>
    </div>
    

</asp:Content>
