using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SysArcos
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session != null)
            {
                string usuario, path, metodo, campos;
                DateTime timestamp;

                usuario = "Não logado";
                path = HttpContext.Current.Request.Path;
                metodo = HttpContext.Current.Request.HttpMethod;
                timestamp = DateTime.Now;

                campos = "";
                foreach (var i in HttpContext.Current.Request.Params)
                {
                    if (i == null) continue;
                    if ((i.ToString().Contains("txt") || i.ToString().Contains("btn")) && HttpContext.Current.Request.Params[i.ToString()] != "")
                    {
                        campos += $"{i.ToString().Split('$').Last()}: {HttpContext.Current.Request.Params[i.ToString()]},";
                    }
                }

                if (campos != "") campos = campos.Substring(0, campos.Length - 1); // para retirar a última vírgula

                if (Session["usuariologado"] != null)
                {
                    usuario = Session["usuariologado"].ToString();
                }

                using(ARCOS_Entities con = new ARCOS_Entities())
                {
                    var usuarioLogin = con.USUARIO.Where(u => u.LOGIN.Equals(usuario)).FirstOrDefault();
                    var sistemaEntidade = con.SISTEMA_ENTIDADE.Where(s => s.URL.Equals(path)).FirstOrDefault();

                    if(sistemaEntidade != null)
                    {
                        con.LOG.Add(new LOG() { DATA = timestamp,
                                                METODO = metodo,
                                                USUARIO = usuarioLogin,
                                                SISTEMA_ENTIDADE = sistemaEntidade,
                                                DESCRICAO = campos });

                        con.SaveChanges();
                    }
                }

            }
        }
    }
}