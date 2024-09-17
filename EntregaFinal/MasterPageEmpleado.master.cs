using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Compartidas;


public partial class MasterPageEmpleado : System.Web.UI.MasterPage
{
        protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Empleado"] == null || !(Session["Empleado"] is Empleados))
            {
                Response.Redirect("Bienvenido.aspx");
                return; // Asegurarse de que el resto del código no se ejecute
            }
        }
        catch
        {
            Response.Redirect("Bienvenido.aspx");
        }
        
    }

    protected void btnDeslog_Click1(object sender, EventArgs e)
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
