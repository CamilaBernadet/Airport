using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Compartidas;
using Persistencia;

public partial class MasterPageCliente : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Cliente"] is Clientes)
            {
                lblBienvenido.Text = "Bienvenido:" + ((Clientes)Session["Cliente"]).NomCliente;
            }
        }
        catch
        {
            Response.Redirect("Principal.aspx");
        }
        
    }

    protected void btnDeslogueo_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("Principal.aspx");
        }
        catch
        {
            Response.Write("Ocurrió un error al cerrar la sesión. Por favor, inténtelo de nuevo.");
        }
    }
}
