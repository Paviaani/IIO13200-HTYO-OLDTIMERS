<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="IIO13200_HTYO_OLDTIMERS.Main1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="CQuestion" ContentPlaceHolderID="CphQuestion" runat="server">
    <h1><asp:Label ID="lbTest" runat="server" Text="Testi label"></asp:Label></h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnAns1" CssClass="AnswerButton" Text="Answer1" runat="server"/>
    <asp:Button ID="btnAns2" CssClass="AnswerButton" Text="Answer2" runat="server"/>
    <asp:Button ID="btnAns3" CssClass="AnswerButton" Text="Answer3" runat="server"/>
    <asp:Button ID="btnAns4" CssClass="AnswerButton" Text="Answer4" runat="server"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <input id="Text1" class="Textbox" type="text" />
    <input id="Button5" type="button" value="button" />
    <br />
    <input id="Password1" class="Textbox" type="password" />
    <asp:HyperLink ID="HyperLink1" runat="server">Register</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2>Footer</h2>
</asp:Content>

