<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="presentacion_pokedex.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Bienvenido a Pokedex!!</h3>

    <!--Listar tarjetas con foreach -->
   <%-- <div class="row row-cols-1 row-cols-md-3 g-4">
        <%
            foreach (dominio.Pokemon pokemon in ListPokemon)
            {
        %>
                <div class="col">
                    <div class="card text-black">
                        <img src="<%:pokemon.UrlImagen %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: pokemon.Nombre%></h5>
                            <p class="card-text"><%:pokemon.Descripcion %></p>
                            <a href="DetallePokemon.aspx?id=<%:pokemon.Id %>">Ver Detalle</a>
                        </div>
                    </div>
                </div>
        <%
            }
        %>
    </div>--%>

     <!--Listar tarjetas con Repeater -->
      <div class="row row-cols-1 row-cols-md-2 g-4">
    <asp:Repeater runat="server" ID="repPokemon" >
        <ItemTemplate>
            <div class="col-6">
                    <div class="card text-black d-flex"> 
                        <img src="<%#Eval("UrlImagen")%>" class=" align-self-center w-50 h-50" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="DetallePokemon.aspx?id=<%#Eval("id") %>">Ver Detalle</a>
                            <asp:Button Text="Ejemplo" CssClass="btn btn-primary" ID="btnEjemplo" runat="server" CommandArgument ='<%#Eval("id") %>' CommandName="PokemonId" OnClick="btnEjemplo_Click"/>
                        </div>
                    </div>
                </div>
        </ItemTemplate>
    </asp:Repeater>
          </div>
</asp:Content>
