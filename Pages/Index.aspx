<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IBDI_Bootcamp4.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server" />

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form runat="server" style="height:100vh; background:#f4f4f4">
        <br />
        <div class="mx-auto text-center container" style="margin:30px 0px 40px;">
            <h2 class="text-uppercase">Lista de Produtos - Leozhr</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-success border p-3 form-control fw-semibold" Text="ADICIONAR UM NOVO PRODUTO" OnClick="BtnCreate_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="container mx-auto overflow-auto" style="max-height:550px;">
            <table class="table table-striped-columns align-items-center">
                <asp:GridView runat="server" ID="gvusers" class="table table-hover table-bordered table-light">
                    <RowStyle CssClass="align-middle py-2" />
                    <Columns>
                        <asp:TemplateField HeaderText="# Ações">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Editar" CssClass="btn form-control-sm btn-primary py-1" ID="BtnUpdate" OnClick="BtnUpdate_Click" />
                                <asp:Button runat="server" Text="Deletar" CssClass="btn form-control-sm btn-danger py-1" ID="BtnDelete" OnClick="BtnDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </table>
        </div>
    </form>
</asp:Content>
