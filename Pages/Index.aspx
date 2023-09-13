<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="IBDI_Bootcamp4.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width:300px">
            <h2>Lista de Produtos</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:Button runat="server" ID="BtnCreate" CssClass="btn btn-sucess form-control" Text="Create" />
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvusers" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="All Products">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Editar" CssClass="btn form-control btm-info" ID="BtnUpdate" />
                                <asp:Button runat="server" Text="Deletar" CssClass="btn form-control btm-info" ID="BtnDelete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
