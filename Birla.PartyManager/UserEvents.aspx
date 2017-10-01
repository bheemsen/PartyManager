<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="UserEvents.aspx.cs" Inherits="UserEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="margin: 0px auto;">
        <tr>
            <td>
                Select User
            </td>
            <td>
                <asp:DropDownList ID="ddlUser" runat="server" AppendDataBoundItems="true" 
                    AutoPostBack="True" onselectedindexchanged="ddlUser_SelectedIndexChanged">
                    <asp:ListItem>Select User</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Select Event
            </td>
            <td>
                <asp:DropDownList ID="ddlEvent" runat="server" AppendDataBoundItems="true" 
                    AutoPostBack="True" onselectedindexchanged="ddlEvent_SelectedIndexChanged">
                    <asp:ListItem>Select EVent</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Amount
            </td>
            <td>
                <asp:TextBox ID="txtAount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>

</asp:Content>
