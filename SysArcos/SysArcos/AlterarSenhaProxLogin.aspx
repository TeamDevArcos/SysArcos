<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AlterarSenhaProxLogin.aspx.cs" Inherits="SysArcos.AlterarSenhaProxLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        window.onload = function () {      
            if (document.getElementById("ContentPlaceHolder1_txtNovaSenha").value != "") {
                validar(document.getElementById("ContentPlaceHolder1_txtNovaSenha"));
            }
        }


        function validar(element){
            var str = element.value;
            var valida = true;
           
            var regexpMin = new RegExp(/[a-z]/);
            var regexpMai = new RegExp(/[A-Z]/);
            var regexpNum = new RegExp(/[0-9]/);
            var regexpCar = new RegExp(/[*|!]/);

            var min = regexpMin.exec(str);
            var mai = regexpMai.exec(str);
            var num = regexpNum.exec(str);
            var car = regexpCar.exec(str);

            document.getElementById("min").classList.remove("text-danger", "text-success");
            document.getElementById("mai").classList.remove("text-danger", "text-success");
            document.getElementById("num").classList.remove("text-danger", "text-success");
            document.getElementById("car").classList.remove("text-danger", "text-success");
            document.getElementById("tamanho").classList.remove("text-danger", "text-success");
           
            if(min == null){
                document.getElementById("min").classList.add("text-danger");
                valida = false;
            }else{
                document.getElementById("min").classList.add("text-success");
            }
           
            if(mai == null){
                document.getElementById("mai").classList.add("text-danger");
                valida = false;
            }else{
                document.getElementById("mai").classList.add("text-success");
            }
           
            if(num == null){
                document.getElementById("num").classList.add("text-danger");
                valida = false;
            }else{
                document.getElementById("num").classList.add("text-success");
            }

            if(car == null){
                document.getElementById("car").classList.add("text-danger");
                valida = false;
            }else{
                document.getElementById("car").classList.add("text-success");
            }

            if(str.length < 8){
                document.getElementById("tamanho").classList.add("text-danger");
                valida = false;
            }else{
                document.getElementById("tamanho").classList.add("text-success");
            }

            document.getElementById("politicaSenha").classList.remove("alert-danger", "alert-success");

            if (valida) {
                document.getElementById("politicaSenha").classList.add("alert-success");
            }
            else {
                document.getElementById("politicaSenha").classList.add("alert-danger");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 0 auto;width:250px">
        <h2>Altere sua senha</h2>
        <div id="politicaSenha"class="alert font-weight-bold d-flex flex-column">
            <span class="text-dark">A senha deverá conter:</span>
            <span id="min">No mínimo 1 letra minúscula</span>
            <span id="mai">No mínimo 1 letra maiúscula</span>
            <span id="num">No mínimo 1 número</span>
            <span id="car">No mínimo 1 caracter especial</span>
            <span id="tamanho">8 caracteres</span>
        </div>
        <div class="form-group">
            <asp:Label ID="lblSenhaAtual" runat="server" Text="Senha Atual"></asp:Label>
            <asp:TextBox ID="txtSenhaAtual" runat="server" TextMode="Password" class="form-control col-12"></asp:TextBox>
        </div>
        <div class="form-group">

            <asp:Label ID="lblNovaSenha" runat="server" Text="Nova Senha"></asp:Label>
            <asp:TextBox ID="txtNovaSenha" runat="server" TextMode="Password" class="form-control col-12" onKeyUp="javascript:validar(this)"></asp:TextBox>

        </div>
        <div class="form-group">

            <asp:Label ID="lblRepetirNovaSenha" runat="server" Text="Repetir Nova Senha"></asp:Label>
            <asp:TextBox ID="txtRepetirNovaSenha" runat="server" TextMode="Password" class="form-control col-12"></asp:TextBox>

        </div>
        <div>

            <asp:Button ID="btnAlterarSenha" runat="server" Text="Alterar Senha" class="btn btn-primary col-12" OnClick="btnAlterarSenha_Click"/>

        </div>
    </div>
</asp:Content>
