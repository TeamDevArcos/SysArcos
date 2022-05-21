﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SysArcos;
namespace ProjetoArcos
{
    public partial class formusuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaPermissoes();
                String login = Request.QueryString["login"];
                if ((login!=null) && (!login.Equals("")))
                {
                    using (ARCOS_Entities entities = new ARCOS_Entities())
                    {
                        USUARIO u = entities.USUARIO.FirstOrDefault(x => x.LOGIN.Equals(login));
                        if (u != null)
                        {
                            txt_user.ReadOnly = true;
                            txt_cpf.Text = u.CPF;
                            txt_email.Text = u.EMAIL;
                            txt_nomeUsuario.Text = u.NOME;
                            txt_senhaUsuario.Text = u.SENHA;
                            txt_user.Text = u.LOGIN;
                            ddlPermissao.SelectedValue = u.GRUPO_PERMISSAO.ID.ToString();
                            ckAdministrador.Checked = u.ADM;
                            CB_ativo.Checked = u.ATIVO;
                            CB_AlteraProxLogin.Checked = u.ALTERA_SENHA_PROX_LOGIN;
                            lblAcao.Text = "ALTERANDO";
                        }
                    }

                }
            }
        }

        protected void btn_cadastrar_Click(object sender, EventArgs e)
        {
            if (txt_nomeUsuario.Text == "" || txt_senhaUsuario.Text == "" || txt_user.Text == "" ||
                 txt_cpf.Text == "" || txt_email.Text == "" || ddlPermissao.Text == "")
            {
                Response.Write("<script>alert('Há campos obrigatorios não preenchidos!');</script>");
            }
            else if(!SenhaValida()){
                Response.Write("<script>alert('A senha deve conter no mínimo 1 letra minúscula, 1 letra maiúscula, 1 número, 1 caracter especial e 8 caracteres no total!');</script>");
            }
            else
            {
                try
                {
                    using (ARCOS_Entities entity = new ARCOS_Entities())
                    {
                        USUARIO usuario = null;
                        if (lblAcao.Text.Equals("NOVO"))
                        {
                            usuario = new USUARIO();
                            usuario.LOGIN = txt_user.Text;

                            usuario.SENHA = txt_senhaUsuario.Text;
                            usuario.NOME = txt_nomeUsuario.Text.ToUpper();
                            usuario.CPF = txt_cpf.Text;
                            usuario.EMAIL = txt_email.Text.ToLower();
                            usuario.DATA_HORA_CRIACAO_REGISTRO = DateTime.Now;
                            usuario.ADM = ckAdministrador.Checked;
                            usuario.ATIVO = CB_ativo.Checked;
                            usuario.ALTERA_SENHA_PROX_LOGIN = CB_AlteraProxLogin.Checked;
                            usuario.ID_GRUPOPERMISSAO = Convert.ToInt32(ddlPermissao.SelectedValue);
                            entity.USUARIO.Add(usuario);
                        }
                        else
                        {
                            usuario = entity.USUARIO.FirstOrDefault(x => x.LOGIN.Equals(txt_user.Text));


                            usuario.SENHA = txt_senhaUsuario.Text;
                            usuario.NOME = txt_nomeUsuario.Text.ToUpper();
                            usuario.CPF = txt_cpf.Text;
                            usuario.EMAIL = txt_email.Text.ToLower();
                            usuario.DATA_HORA_CRIACAO_REGISTRO = DateTime.Now;
                            usuario.ADM = ckAdministrador.Checked;
                            usuario.ATIVO = CB_ativo.Checked;
                            usuario.ALTERA_SENHA_PROX_LOGIN = CB_AlteraProxLogin.Checked;
                            usuario.ID_GRUPOPERMISSAO = Convert.ToInt32(ddlPermissao.SelectedValue);
                            entity.Entry(usuario);
                        }
                        limpar();
                        entity.SaveChanges();

                        Response.Write("<script>alert('Usuario salvo com Sucesso!');</script>");
                    }
                }
                catch
                {
                    Response.Write("<script>alert('Registro não pode ser salvo!');</script>");
                }
            }
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmbuscausuario.aspx");
        }

        private void limpar()
        {
            txt_nomeUsuario.Text = string.Empty;
            txt_senhaUsuario.Text = string.Empty;
            txt_user.Text = string.Empty;
            txt_cpf.Text = string.Empty;
            txt_email.Text = string.Empty;
            ddlPermissao.SelectedIndex = -1;
            ckAdministrador.Checked = false;
            CB_ativo.Checked = true;
            CB_AlteraProxLogin.Checked = false;
            lblAcao.Text = "NOVO";
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            txt_user.ReadOnly = false;
            limpar();
        }

        private void carregaPermissoes()
        {
            using (ARCOS_Entities entity = new ARCOS_Entities())
            {
                List<GRUPO_PERMISSAO> list = entity.GRUPO_PERMISSAO.OrderBy(x => x.DESCRICAO).ToList();
                ddlPermissao.DataTextField = "DESCRICAO";
                ddlPermissao.DataValueField = "ID";
                ddlPermissao.DataSource = list;
                ddlPermissao.DataBind();
                ddlPermissao.Items.Insert(0, "");
            }
        }

        private bool SenhaValida()
        {
            Regex regexMin = new Regex("([a-z])");
            Regex regexMai = new Regex("([A-Z])");
            Regex regexNum = new Regex("([0-9])");
            Regex regexCar = new Regex("([*|!])");

            if (!regexCar.IsMatch(this.txt_senhaUsuario.Text)
                || (!regexMin.IsMatch(this.txt_senhaUsuario.Text))
                || (!regexMai.IsMatch(this.txt_senhaUsuario.Text))
                || (!regexNum.IsMatch(this.txt_senhaUsuario.Text))
                || (this.txt_senhaUsuario.Text.Length < 8))
            {
                return false;
            }
            return true;
        }

    }
}