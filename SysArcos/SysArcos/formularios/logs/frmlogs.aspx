<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmlogs.aspx.cs" Inherits="SysArcos.formularios.logs.frmLogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
                
        function Filtrar() {

          var input, filter, table, tr, td, i, txtValue, finded;
          input = document.getElementById("txtFiltro");
          filter = input.value.toUpperCase();
          table = document.getElementById("ContentPlaceHolder1_gridLogs");
          tr = table.getElementsByTagName("tr");
            debugger;
            if (filter == "") {
                for (i = 0; i < tr.length; i++) {
                    tr[i].style.display = "";
                }
            }

            for (i = 0; i < tr.length; i++) {
            finded = false;
                td = tr[i].getElementsByTagName("td");
            for (j = 0; j < tr.length; j++) {
                    if (td[j]) {

                      txtValue = td[j].textContent || td[j].innerText;

                      if (txtValue.toUpperCase().indexOf(filter) > -1) {
                          finded = true;
                      }
                      if (finded) break;
                    }
            }
            if (finded) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
          }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="entidade col-12">
            Logs
        </div>
    </div>
    <div class="col-xl-8 col-md-10 col-sm-12 mx-auto" style="margin-bottom: 10px">
        <div class="d-flex flex-row">
            <asp:TextBox CssClass="form-control" runat="server" TextMode="Date" ID="txtDataIni" ></asp:TextBox>
            <asp:TextBox CssClass="form-control" runat="server" TextMode="Date" ID="txtDataFim"></asp:TextBox>
            <asp:Button style="width: 300px" ID="btnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click"></asp:Button>
        </div>
        <input class="form-control col-12" id="txtFiltro" OnKeyPress="Filtrar()" placeholder="Filtro..." />
    </div>
    <asp:GridView ID="gridLogs" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" CssClass="table table-responsive table-hover col-12" >
        <Columns>
            <asp:BoundField DataField="DATA" HeaderText="Data"></asp:BoundField>
            <asp:BoundField DataField="METODO" HeaderText="Método"></asp:BoundField>
            <asp:BoundField DataField="SISTEMA_ENTIDADE.URL" HeaderText="Path"></asp:BoundField>
            <asp:BoundField DataField="USUARIO.LOGIN" HeaderText="Usuário"></asp:BoundField>
            <asp:BoundField DataField="DESCRICAO" HeaderText="Descrição"></asp:BoundField>
        </Columns>
    </asp:GridView>
    
</asp:Content>
