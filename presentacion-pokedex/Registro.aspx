<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="presentacion_pokedex.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-5 p-4">
            <h2>Creá tu perfil Trainee</h2>
            <hr />
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtEmail"/>
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" TextMode="Password"/>
            </div>
            <asp:Button Text="Registrarse" cssclass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
            <a href="/">Cancelar</a>
        </div>
    </div>
</asp:Content>
