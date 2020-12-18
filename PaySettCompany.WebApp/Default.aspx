<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PaySettCompany.WebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row">
        <div class="col-md-12">
            <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
            <input id="pathFile" type="file" runat="server" name="pathFile">
            <asp:button id="btnUpload" type="submit" text="Upload" runat="server" OnClick="btnUpload_Click"></asp:button>
            <asp:Label ID="LabelUploaded" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </div>

</asp:Content>
