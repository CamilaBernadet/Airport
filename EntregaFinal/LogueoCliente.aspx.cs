using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Compartidas;
using Logica;
using Persistencia;



public partial class LogueoCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Cliente"] = null;
    }

    protected void btnLoginCli_Click(object sender, EventArgs e)
    {
        try
        {
            //verifico usuario

            Compartidas.Clientes unCli = Logica.LogicaClientes.Logueo(txtPasaporte.Text, txtContraseñaCli.Text);

            if (unCli != null)
            {
                //si llego aca es pq es valido
                Session["Cliente"] = unCli;
                Response.Redirect("HistorialCompras.aspx");
            }
            else
                lblError.Text = "Datos Incorrectos";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

}