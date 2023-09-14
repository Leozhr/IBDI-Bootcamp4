<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="IBDI_Bootcamp4.Pages.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="mx-auto" style="width:250px">
        <asp:Label runat="server" CssClass="h2" ID="title" />
    </div>

    <div class="container text-danger my-4 text-center rounded-1" style="width:400px; background:#f9d7db;">
        <asp:Label runat="server" CssClass="p-3" Visible="false" ID="lblerror" />
    </div>

    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">Nome do Produto</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TableName" />
                <label class="form-label">Valor do Produto</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TablePrice" type="number"/>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Criar" Visible="false" OnClick="BtnCreate_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnUpdate" Text="Editar" Visible="false" OnClick="BtnUpdate_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnDelete" Text="Deletar" Visible="false" OnClick="BtnDelete_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnReturn" Text="Voltar" Visible="true" OnClick="BtnReturn_Click" />
          </div>
    </form>
</asp:Content>
