<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="presentacion_pokedex.ListaPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <h1 class="p-3 mt-2">Lista de pokemons</h1>
            <div class="row">
                <div class="col-4">
                    <asp:Label Text="Buscar" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />

                </div>
                <div class="col d-flex align-items-center">
                    <asp:CheckBox Text="Filtro avanzado" runat="server" ID="checkFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="checkFiltroAvanzado_CheckedChanged" />
                </div>
            </div>
            <% if (FiltroAvanzado)
                { %>
            <div class="row">
                <div class="col mt-3">
                    <asp:Label Text="Campo" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCampo" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Nombre" />
                        <asp:ListItem Text="Tipo" />
                        <asp:ListItem Text="Número" />
                    </asp:DropDownList>
                </div>
                <div class="col mt-3">
                    <asp:Label Text="Criterio" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-select">
                    </asp:DropDownList>
                </div>
                <div class="col mt-3">
                    <asp:Label Text="Filtro" runat="server" />
                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                </div>
                <div class="col mt-3">
                    <asp:Label Text="Estado" runat="server" />
                    <asp:DropDownList ID="ddlEstado" CssClass="form-select" runat="server">
                        <asp:ListItem Text="Todos" />
                        <asp:ListItem Text="Activo" />
                        <asp:ListItem Text="Inactivo" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-4 mt-3">
                    <asp:Button Text="Buscar" ID="btnBuscarFiltro" CssClass="btn btn-primary" runat="server" OnClick="btnBuscarFiltro_Click" />
                    <asp:Button Text="Reestablecer filtro" ID="btnReset" CssClass="btn btn-danger" runat="server" OnClick="btnReset_Click" />
                </div>
            </div>
            <%} %>
            <div class="row">
                <div class="col-12 mt-5">

                    <asp:GridView ID="dgvPokemon" runat="server" AutoGenerateColumns="false" DataKeyNames="id"
                        CssClass="table table-dark table-bordered" OnSelectedIndexChanged="dgvPokemon_SelectedIndexChanged" OnPageIndexChanging="dgvPokemon_PageIndexChanging" AllowPaging="true" PageSize="10">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="Número" DataField="Numero" />
                            <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                            <asp:BoundField HeaderText="Debilidad" DataField="Debilidad.Descripcion" />
                            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                            <asp:CommandField HeaderText="Accion" SelectText="✍" ShowSelectButton="true" />
                        </Columns>
                    </asp:GridView>
                    <a href="AgregarPokemon.aspx" class=" btn btn-danger">Agregar</a>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
