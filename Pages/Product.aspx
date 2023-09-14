<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="IBDI_Bootcamp4.Pages.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Produto
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="height:100vh; background:#f4f4f4">
        <div class="p-5 bg-white mt-5 mx-auto border rounded-3" style="width:max-content">
            <br />
            <div class="mx-auto text-center mb-5">
                <asp:Label runat="server" CssClass="h2" ID="title" />
            </div>
            <form runat="server" class="d-flex align-items-center justify-content-center mt-2">
                <div>
                    <div class="mb-5">
                        <label class="form-label fs-6">Nome do Produto</label>
                        <div class="input-group input-group-lg mb-3">
                            <asp:TextBox runat="server" CssClass="form-control" type="text" ID="TableName" Placeholder="Digite o nome do produto" />
                        </div>
                        <br />
                        <label class="form-label fs-6">Valor do Produto</label>
                        <div class="input-group input-group-lg mb-3">
                            <span class="input-group-text">$</span>
                                <asp:TextBox runat="server" CssClass="form-control" ID="TablePrice" Placeholder="0" type="number" />
                            <span class="input-group-text">.00</span>
                        </div>
                    </div>
                    <div class="mx-auto">
                        <asp:Button runat="server" CssClass="btn btn-lg btn-primary w-100 mb-2" ID="BtnCreate" Text="Criar" Visible="false" OnClick="BtnCreate_Click" />
                        <asp:Button runat="server" CssClass="btn btn-lg btn-primary w-100 mb-2" ID="BtnUpdate" Text="Editar" Visible="false" OnClick="BtnUpdate_Click" />
                        <asp:Button runat="server" CssClass="btn btn-lg btn-primary w-100 mb-2 btn-dark" ID="BtnReturn" Text="Voltar" Visible="true" OnClick="BtnReturn_Click" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
