<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="IBDI_Bootcamp4.Pages.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="mx-auto" style="width:250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo" />
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">Product Name</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbname" />
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Criar" Visible="false" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnUpdate" Text="Editar" Visible="false" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnDelete" Text="Deletar" Visible="false" />
            <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnReturn" Text="Voltar" Visible="false" />
          </div>
    </form>
</asp:Content>
