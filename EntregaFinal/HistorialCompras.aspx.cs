using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Compartidas;
using Logica;



public partial class HistorialCompras : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["Cliente"] != null)
                {
                    Clientes unC = (Clientes)Session["Cliente"];

                    if (Session["Pasajes"] == null)
                    {
                        List<Pasajes> unP = Logica.LogicaPasajes.Compras(unC);
                        Session["Pasajes"] = unP;
                    }
                }

                gvPasajes.DataSource = (List<Pasajes>)Session["Pasajes"];
                gvPasajes.DataBind();
            }
            
        }
        catch (Exception ex)
        {
            lblError.Text = "Ocurrió un error: " + ex.Message;
        }
    }



    protected void gvPasajes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            var listaDePasajes = Session["Pasajes"] as List<Pasajes>;

            if (listaDePasajes != null)
            {
                Pasajes unP = listaDePasajes[gvPasajes.SelectedIndex];
                if (unP != null)
                {
                    Vuelos unV = unP.vueloPasaje;
                    if (unV != null)
                    {
                        List<Vuelos> infoPasaje = new List<Vuelos> { unV };

                        gvInfoPasaje.DataSource = infoPasaje;
                        gvInfoPasaje.DataBind();
                    }
                    else
                    {
                        lblError.Text = "No se pudo cargar la informacion del Pasaje seleccionado";
                    }
                }
                else
                {
                    lblError.Text = "";

                    gvInfoPasaje.DataSource = null;
                    gvInfoPasaje.DataBind();
                }
            }
            else
            {
                lblError.Text = "La sesión no contiene una lista de pasajes.";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}