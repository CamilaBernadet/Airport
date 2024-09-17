using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Logica;
using Compartidas;


public partial class AltaVuelos : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                this.LimpioFormulario();

                Session["unV"] = LogicaAeropuertos.ListarAeros();

                ddlSalida.DataSource = Session["unV"];
                ddlSalida.DataTextField = "CodigoAeropuerto";
                ddlSalida.DataBind();

                ddlLlegada.DataSource = Session["unV"];
                ddlLlegada.DataTextField = "CodigoAeropuerto";
                ddlLlegada.DataBind();
            }

        }
        catch (Exception ex)
        {
            lblError.Text = "Error: " + ex.Message;
        }
    }


    private void LimpioFormulario()
    {

        txtFechaHoraLlegada.Text = "";
        txtFechaHoraSalida.Text = "";
        txtPrecio.Text = "";
        txtAsientos.Text = "";

        lblError.Text = "";
        lblCodigoVuelo.Text = "";
        lblGood.Text = "";
    }
    

    protected void  btnAltaVuelo_Click1(object sender, EventArgs e)
    {
        try
        {
            Aeropuertos _unAS = ((List<Aeropuertos>)Session["unV"])[ddlSalida.SelectedIndex];
            Aeropuertos _unAL = ((List<Aeropuertos>)Session["unV"])[ddlLlegada.SelectedIndex];

            if (_unAL == null)
                throw new Exception("Debe Seleccionar un Aeropuerto de Llegada");
            if (_unAS == null)
                throw new Exception("Debe Seleccionar un Aeropuerto de Salida");
            if (_unAL == _unAS)
                throw new Exception("No puede poner el mismo Aeropuerto de Llegada como de Salida");
            

            Vuelos _unV = new Vuelos(lblCodigoVuelo.Text,Convert.ToDateTime(txtFechaHoraSalida.Text), 
                Convert.ToDateTime(txtFechaHoraLlegada.Text),
                Convert.ToInt32(txtPrecio.Text), 
                Convert.ToInt32(txtAsientos.Text),
                _unAS, 
                _unAL);
            
            

            LogicaVuelos.AltaVuelos(_unV);
            lblGood.Text  = "Alta con exito";

            lblCodigoVuelo.Text = _unV.CodigoVuelo;

        }
        catch (Exception ex)
        {
            lblError.Text = "Error: " + ex.Message;
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }
}
