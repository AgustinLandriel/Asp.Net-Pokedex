<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarPokemon.aspx.cs" Inherits="presentacion_pokedex.AgregarPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6 mt-3">
                    <h4 class="text-warning p-3 ">Agregar pokémon</h4>
                    <hr />
                    <div class="mt-3">
                        <!-- Numero -->
                        <asp:Label Text="Número" ID="lblNumero" CssClass="form-label" runat="server" />
                        <asp:TextBox ID="textNumero" CssClass="form-control" runat="server" />
                    </div>
                    <div class="mt-3">
                        <!-- Nombre -->
                        <asp:Label Text="Nombre" ID="lblNombre" CssClass="form-label" runat="server" />
                        <asp:TextBox ID="textNombre" CssClass="form-control" runat="server" />
                    </div>
                    <div class="mt-3">
                        <!-- Descripcion -->
                        <asp:Label Text="Descripcion" ID="lblDescripcion" CssClass="form-label" runat="server" />
                        <asp:TextBox ID="textDescripcion" TextMode="MultiLine" CssClass="form-control" runat="server" />
                    </div>
                    <div class="mt-3">
                        <!-- URL -->
                        <asp:Label Text="Imágen" ID="lblImagen" CssClass="form-label" runat="server" />
                        <asp:TextBox ID="textImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="textImagen_TextChanged" runat="server" />
                    </div>
                    <div class="mt-3">
                        <!-- Tipo -->
                        <asp:Label Text="Tipo" ID="lblTipo" CssClass="form-label" runat="server" />
                        <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                    <div class="mt-3">
                        <!-- Debilidad -->
                        <asp:Label Text="Debilidad" ID="lblDebilidad" CssClass="form-label" runat="server" />
                        <asp:DropDownList ID="ddlDebilidad" CssClass="form-select" runat="server"></asp:DropDownList>
                    </div>
                    <div class="mt-3 p-3 ">
                        <asp:Button Text="Agregar" CssClass="btn btn-primary" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
                        <a href="ListaPokemon.aspx" class="btn btn-light mx-2">Cancelar</a>
                    </div>
                </div>
                <div class="col d-flex justify-content-center align-items-center">
                    <img src="<%:urlImagen %>" alt="Pokemon" class="h-auto w-auto" />
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
