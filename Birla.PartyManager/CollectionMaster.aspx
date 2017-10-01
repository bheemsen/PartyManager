<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CollectionMaster.aspx.cs" Inherits="CollectionMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="margin: 0px auto;">
        <tr>
            <td>
                Select User
            </td>
            <td>
                <asp:DropDownList ID="ddlUser" runat="server" AppendDataBoundItems="true" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlUser_SelectedIndexChanged">
                    <asp:ListItem>Select User</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Total Due
            </td>
            <td>
                <asp:TextBox ID="txtTotalDue" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Amount
            </td>
            <td>
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <h1>
        Total Due is :
        <asp:Label ID="lblDue" runat="server"></asp:Label></h1>
</asp:Content>
