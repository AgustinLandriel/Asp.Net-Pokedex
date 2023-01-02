<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="presentacion_pokedex.ListaPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-12 mt-5">
                    <h1>Lista de pokemons</h1>
                    <asp:GridView ID="dgvPokemon"  runat="server" AutoGenerateColumns="false" DataKeyNames="id"
                        CssClass="table table-dark table-bordered" OnSelectedIndexChanged="dgvPokemon_SelectedIndexChanged" OnPageIndexChanging="dgvPokemon_PageIndexChanging" AllowPaging="true" PageSize="5">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Número" DataField="Numero" />
                            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                            <asp:BoundField HeaderText="Debilidad" DataField="Debilidad.Descripcion" />
                            <asp:CommandField HeaderText = "Accion" SelectText="Modificar" ShowSelectButton="true" />
                            </Columns>
                    </asp:GridView>
                    <a href="AgregarPokemon.aspx" class=" btn btn-danger">Agregar</a>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
