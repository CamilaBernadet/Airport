using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Compartidas;
using Logica;

public partial class MantenimientoAeropuertos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpioFormulario();
    }

    private void ActivoBotonesBM()
    {
        btnModAero.Enabled = true;
        btnEliminarAero.Enabled = true;

        btnAltaAero.Enabled = false;
        btnBuscar.Enabled = false;

        txtCodigoAeropuerto.Enabled = false;
    }

    private void ActivoBotonesA()
    {
        btnModAero.Enabled = false;
        btnEliminarAero.Enabled = false;

        btnAltaAero.Enabled = true;
        btnBuscar.Enabled = false;

        txtCodigoAeropuerto.Enabled = false;
    }

    private void LimpioFormulario()
    {
        btnModAero.Enabled = false;
        btnEliminarAero.Enabled = false;

        btnAltaAero.Enabled = false;
        btnBuscar.Enabled = true;

        txtCodigoAeropuerto.Enabled = true;

        txtCodigoAeropuerto.Text = "";
        txtNombreAeropuerto.Text = "";
        txtDireccion.Text = "";
        txtImpuestosA.Text = "0";
        txtImpuestosP.Text = "0";
        txtCodigoCiudad.Text = "";

        lblError.Text = "";
        lblGood.Text = "";
    }
    
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            Aeropuertos _Aero = LogicaAeropuertos.BuscarAeropuerto(txtCodigoAeropuerto.Text);

            //determino acciones
            if (_Aero == null)
            {
                //alta
                this.ActivoBotonesA();
                Session["unA"] = null;
            }
            else
            {
                this.ActivoBotonesBM();
                Session["unA"] = _Aero;

                txtCodigoAeropuerto.Text = _Aero.CodigoAeropuerto;
                txtNombreAeropuerto.Text = _Aero.NomAeropuerto;
                txtDireccion.Text = _Aero.Direccion;
                txtImpuestosA.Text = _Aero.ImpLlegada.ToString();
                txtImpuestosP.Text = _Aero.ImpPartida.ToString();
                txtCodigoCiudad.Text = _Aero.ciudadAeropuerto.CodigoCiudad;
            }
        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnAltaAero_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudades _unaC = LogicaCiudades.BuscarCiudad(txtCodigoCiudad.Text);
            Aeropuertos _unA = new Aeropuertos(txtCodigoAeropuerto.Text, txtNombreAeropuerto.Text, txtDireccion.Text, Convert.ToInt32(txtImpuestosA.Text), Convert.ToInt32(txtImpuestosP.Text), _unaC);

            LogicaAeropuertos.AltaAeropuerto(_unA);
            lblGood.Text = "Alta con exito";
            
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnModAero_Click(object sender, EventArgs e)
   {
        try
        {
            Ciudades _unaC = LogicaCiudades.BuscarCiudad(txtCodigoCiudad.Text);
            Aeropuertos _unA = (Aeropuertos)Session["unA"];

            //modifico el objeto
            _unA.NomAeropuerto = txtNombreAeropuerto.Text;
            _unA.Direccion = txtDireccion.Text;
            _unA.ImpLlegada = Convert.ToInt32(txtImpuestosA.Text);
            _unA.ImpPartida = Convert.ToInt32(txtImpuestosP.Text);
            _unA.ciudadAeropuerto = _unaC;

            LogicaAeropuertos.ModificarAeropuerto(_unA);
            lblGood.Text = "Modificacion con éxito";

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnEliminarAero_Click(object sender, EventArgs e)
    {
        try
        {
            Aeropuertos _unA = (Aeropuertos)Session["unA"];

            LogicaAeropuertos.EliminarAeropuerto(_unA);

            lblGood.Text = "Eliminacion con éxito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
    }
}
