using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysArcos.formularios.logs
{
    public partial class frmLogs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtDataIni.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.txtDataFim.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.CarregarDados();
            }
        }

        protected void CarregarDados()
        {
            DateTime dtIni = Convert.ToDateTime(this.txtDataIni.Text);
            DateTime dtFim = Convert.ToDateTime(this.txtDataFim.Text).AddHours(23).AddMinutes(59).AddSeconds(59);
            
            using (ARCOS_Entities con = new ARCOS_Entities())
            {
                IQueryable<LOG> query = con.LOG.Include("USUARIO").Include("SISTEMA_ENTIDADE").Where(l => l.DATA >= dtIni && l.DATA <= dtFim).OrderBy(l => l.DATA);

                var lista = query.ToList();
                this.gridLogs.DataSource = lista;
                this.gridLogs.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            this.CarregarDados();
        }
    }
}