using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Compartidas;
using Logica;
using Persistencia;

public partial class LogueoEmpleado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Empleado"] = null;
    }
    protected void btnLoginEmp_Click(object sender, EventArgs e)
    {
        {
            try
            {
                //verifico usuario
                Compartidas.Empleados unEmp = Logica.LogicaEmpleados.Logueo(txtUsuario.Text, txtContraseñaEmp.Text);

                if (unEmp != null)
                {
                    //si llego aca es pq es valido
                    Session["Empleado"] = unEmp;
                    Response.Redirect("Bienvenido.aspx");
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
}