using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysArcos
{
    public partial class AlterarSenhaProxLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            using(ARCOS_Entities entity = new ARCOS_Entities())
            {
                string login = (string)Session["usuariologado"];
                USUARIO u = entity.USUARIO.FirstOrDefault(
                    l => l.LOGIN.Equals(login));
                if (!u.SENHA.Equals(txtSenhaAtual.Text))
                {
                    Response.Write("<script>alert('Senha altual incorreta');</script>");
                }
                else if (!txtNovaSenha.Text.Equals(txtRepetirNovaSenha.Text))
                {
                    Response.Write("<script>alert('Nova senha não confere');</script>");
                }
                else if(!this.SenhaValida()){
                    Response.Write("<script>alert('A senha deve conter no mínimo 1 letra minúscula, 1 letra maiúscula, 1 número, 1 caracter especial e 8 caracteres no total!');</script>");
                }
                else
                {
                    u.SENHA = txtNovaSenha.Text;
                    u.ALTERA_SENHA_PROX_LOGIN = false;
                    entity.Entry(u);
                    entity.SaveChanges();
                    Session["altera_primeiro_login"] = false;
                    Response.Redirect("/PaginaInicial.aspx");
                }
            }
        }

        private bool SenhaValida()
        {
            Regex regexMin = new Regex("([a-z])");
            Regex regexMai = new Regex("([A-Z])");
            Regex regexNum = new Regex("([0-9])");
            Regex regexCar = new Regex("([*|!])");

            if (!regexCar.IsMatch(this.txtNovaSenha.Text)
                || (!regexMin.IsMatch(this.txtNovaSenha.Text))
                || (!regexMai.IsMatch(this.txtNovaSenha.Text))
                || (!regexNum.IsMatch(this.txtNovaSenha.Text))
                || (this.txtNovaSenha.Text.Length < 8))
            {
                return false;
            }
            return true;
        }
    }
}