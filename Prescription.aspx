<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Prescription.aspx.cs" Inherits="Prescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style11
    {
        color: #660066;
    }
    .style12
    {
        color: #FF0066;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel = "stylesheet" type ="text/css" href ="stylesheet.css" />  
    <h1>Prescription</h1>
<p>
    <asp:Label ID="LabelID" runat="server" CssClass="style11" Text="ID :"></asp:Label>
    <asp:TextBox ID="TxtID" runat="server" AutoPostBack="True" 
        ontextchanged="TxtID_TextChanged" style="height: 22px"></asp:TextBox>
    <asp:Label ID="LabelName" runat="server" Text="Label" Visible="False"></asp:Label><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorID" runat="server" 
                        ControlToValidate="TxtID" ErrorMessage="ID is Required" ForeColor="Red" 
                        Display="Dynamic" ValidationGroup="valGroup1"></asp:RequiredFieldValidator>
</p>
<p>
    <asp:Label ID="LabelDate" runat="server" CssClass="style11" Text="Date : "></asp:Label>
    <asp:TextBox ID="TxtDate" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" 
                        ControlToValidate="TxtDate" ErrorMessage="Date is Required" ForeColor="Red" 
                        Display="Dynamic" ValidationGroup="valGroup1"></asp:RequiredFieldValidator>
</p>
<p>
    <asp:Label ID="LabelFee" runat="server" CssClass="style11" Text="Fee :"></asp:Label>
    <asp:TextBox ID="TxtFee" runat="server"></asp:TextBox><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTFee" runat="server" 
                        ControlToValidate="TxtFee" ErrorMessage="Fee is Required" ForeColor="Red" 
                        Display="Dynamic" ValidationGroup="valGroup1"></asp:RequiredFieldValidator>
</p>
<p>
    <asp:Label ID="Label1" runat="server" CssClass="style11" Text="Docter :"></asp:Label>
    <asp:DropDownList ID="DropDownListname" runat="server" 
        DataSourceID="SqlDataSource1" DataTextField="Doc_name" 
        DataValueField="Doc_id" 
        onselectedindexchanged="DropDownListname_SelectedIndexChanged">
    </asp:DropDownList><br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT [Doc_name], [Doc_id] FROM [Doctor]"></asp:SqlDataSource>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorname" runat="server" 
                        ControlToValidate="DropDownListname" ErrorMessage="Docter name is Required" ForeColor="Red" 
                        Display="Dynamic" ValidationGroup="valGroup1"></asp:RequiredFieldValidator>   
</p>
<p>
    <asp:Button ID="Btninsert" runat="server" Text="Insert" CssClass="style12" 
        onclick="Btninsert_Click" ValidationGroup="valGroup1" />
    <asp:Button ID="Btnupdate" runat="server" Text="Update" CssClass="style12" 
        onclick="Btnupdate_Click" ValidationGroup="valGroup1" />
    <asp:Button ID="BtnClear" runat="server" CssClass="style12" 
        onclick="BtnClear_Click" Text="Clear" ValidationGroup="valGroup1" />
</p>
    <p>
    <asp:Label ID="Labelmass" runat="server" Text="Label" Visible="False"></asp:Label>
</p>
<p>
    <asp:TextBox ID="Txtsearch" runat="server" Width="230px"></asp:TextBox>
</p>
<p>
    <asp:Button ID="Btnsearch" runat="server" Text="Search " CssClass="style12" 
        onclick="Btnsearch_Click" />
</p>
</asp:Content>

