<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IBDI_Bootcamp4.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" style="height:100vh; background:#edf1f2" class="mb-4">
        <br />
        <div class="mx-auto text-center container" style="margin:30px 0px 40px;">
            <h2 class="text-uppercase">Lista de Produtos</h2>
            <p class="text-secondary opacity-75" style="line-height:24px">Descubra nosso sistema de gerenciamento de produtos em .NET WebForms - a solução perfeita <br /> para criar, atualizar, ler e deletar informações de produtos de forma eficiente.</p>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-primary border p-3 form-control fw-semibold" Text="ADICIONAR UM NOVO PRODUTO" OnClick="BtnCreate_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="container mx-auto overflow-auto" style="max-height:550px;">
            <table class="table table-striped-columns align-items-center">
                <asp:GridView runat="server" ID="gvusers" class="table table-hover">
                    <RowStyle CssClass="align-middle py-2" />
                    <Columns>
                        <asp:TemplateField HeaderText="# Ações">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Editar" CssClass="btn form-control-sm btn-primary py-1" ID="BtnUpdate" OnClick="BtnUpdate_Click" />
                                <asp:Button runat="server" Text="Deletar" CssClass="btn form-control-sm btn-secondary py-1" ID="BtnDelete" OnClick="BtnDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </table>
        </div>
    </form>
</asp:Content>
