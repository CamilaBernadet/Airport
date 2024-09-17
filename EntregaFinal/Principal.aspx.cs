using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Compartidas;
using Persistencia;
using Logica;

public partial class Principal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                
                List<Aeropuertos> aeropuertos = LogicaAeropuertos.ListarAeros();
                if (aeropuertos != null && aeropuertos.Count > 0)
                {
                    Session["unV"] = aeropuertos;
                    ddlAero.DataSource = aeropuertos;
                    ddlAero.DataTextField = "CodigoAeropuerto";
                    ddlAero.DataValueField = "CodigoAeropuerto"; 
                    ddlAero.DataBind();
                }
                else
                {
                    lblError.Text = "No se encontraron aeropuertos.";
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Ocurrió un error al cargar los aeropuertos: " + ex.Message;
        }

    }
    protected void btnListar_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.Text = "";
            Compartidas.Aeropuertos unA = ((List<Compartidas.Aeropuertos>)Session["unV"])[ddlAero.SelectedIndex];

            List<Compartidas.Vuelos> _listaVP = LogicaVuelos.ListarVuelosSinPartir(unA);
            List<Compartidas.Vuelos> _listaVS = LogicaVuelos.ListarVuelosSinLlegar(unA);

            if (_listaVP.Count > 0)
            {
                gvPorPartir.DataSource = _listaVP;
                gvPorPartir.DataBind();
            }
            else
            {
                lblError.Text = "No hay Vuelos por Partir";
                gvPorPartir.DataSource = _listaVP;
                gvPorPartir.DataBind();

            }

            if (_listaVS.Count > 0)
            {
                gvPorArribar.DataSource = _listaVS;
                gvPorArribar.DataBind();
            }
            else
            {
                lblError.Text = "No hay Vuelos por Arribar";
                gvPorArribar.DataSource = _listaVS;
                gvPorArribar.DataBind();

            }
        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }
    protected void ddlAero_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvPorArribar_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvPorPartir_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}