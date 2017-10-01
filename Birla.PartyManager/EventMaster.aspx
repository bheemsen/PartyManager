<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="EventMaster.aspx.cs" Inherits="EventMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table style="margin: 0px auto;">
        <tr>
            <td>
                Event Name
            </td>
            <td>
                <asp:TextBox ID="txtEventName" runat="server"></asp:TextBox>
            </td>
        </tr>

         <tr>
            <td>
                Event Amount
            </td>
            <td>
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            </td>
        </tr>

         <tr>
            <td>
               
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Save" 
                    onclick="btnSubmit_Click" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</asp:Content>
