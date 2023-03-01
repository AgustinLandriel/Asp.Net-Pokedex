﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="presentacion_pokedex.MiPerfil" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script>
        function validar() {
            //capturar el control. 
            const txtApellido = document.getElementById("txtApellido");
            const txtNombre = document.getElementById("txtNombre");
            if (txtApellido.value == "") {
                txtApellido.classList.add("is-invalid");
                txtApellido.classList.remove("is-valid");
                txtNombre.classList.add("is-valid");
                return false;
            }
            txtApellido.classList.remove("is-invalid");
            txtApellido.classList.add("is-valid");
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ClientIDMode="Static" runat="server"  CssClass="form-control" ID="txtNombre" />
                <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="*Nombre es requerido" ControlToValidate="txtNombre" runat="server" />

            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ClientIDMode="Static" ID="txtApellido" runat="server" CssClass="form-control">
                </asp:TextBox>
                <asp:RequiredFieldValidator CssClass="text-danger" ErrorMessage="Apellido es requerido" ControlToValidate="txtApellido" runat="server" />
                <%--<asp:RangeValidator ErrorMessage="Fuera de rango" 
                    ControlToValidate="txtApellido" runat="server" 
                    Type="Integer" MinimumValue="1" MaximumValue="20" />--%>
                <%--<asp:RegularExpressionValidator ErrorMessage="Correo invalido" ValidationExpression="^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$"
                    ControlToValidate="txtApellido" runat="server" />--%>
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="Date" />
            </div>

        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgNuevoPerfil"
                runat="server" CssClass="img-fluid mb-3 " />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" OnClientClick=" return validar()"
                OnClick="btnGuardar_Click" 
                ID="btnGuardar" runat="server" />
            <a href="/">Regresar</a>
        </div>
    </div>
</asp:Content>
