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


public partial class MantenimientoCiudades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpioFormulario();
    }

    private void ActivoBotonesBM()
    {
        btnModCiudad.Enabled = true;
        btnEliminarCiudad.Enabled = true;

        btnAltaCiudad.Enabled = false;
        btnBuscarCiudad.Enabled = false;

        txtCodigoCiudad.Enabled = false;
    }

    private void ActivoBotonesA()
    {
        btnModCiudad.Enabled = false;
        btnEliminarCiudad.Enabled = false;

        btnAltaCiudad.Enabled = true;
        btnBuscarCiudad.Enabled = false; ;

        txtCodigoCiudad.Enabled = false;
    }

    private void LimpioFormulario()
    {
        btnModCiudad.Enabled = false;
        btnEliminarCiudad.Enabled = false;

        btnAltaCiudad.Enabled = false;
        btnBuscarCiudad.Enabled = true;

        txtCodigoCiudad.Enabled = true;

        txtCodigoCiudad.Text = "";
        txtNombreCiudad.Text = "";
        txtPais.Text = "";

        lblError.Text = "";
        lblGood.Text = "";


    }

    protected void btnBuscarCiudad_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudades _Ciudad = LogicaCiudades.BuscarCiudad(txtCodigoCiudad.Text);

            //determino acciones
            if (_Ciudad == null)
            {
                //alta
                this.ActivoBotonesA();
                Session["unaC"] = null;
            }
            else
            {
                this.ActivoBotonesBM();
                Session["unaC"] = _Ciudad;

                txtCodigoCiudad.Text = _Ciudad.CodigoCiudad;
                txtNombreCiudad.Text = _Ciudad.NomCiudad;
                txtPais.Text = _Ciudad.Pais;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnAltaCiudad_Click(object sender, EventArgs e)
    {
        {

            lblError.Text = "";

            try
            {
                Ciudades _unaC = new Ciudades(txtCodigoCiudad.Text, txtNombreCiudad.Text, txtPais.Text);

                LogicaCiudades.AltaCiudad(_unaC);
                lblGood.Text = "Alta con exito";

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }

    }
    protected void btnModCiudad_Click(object sender, EventArgs e)
    {
        string codigoCiudad = txtCodigoCiudad.Text;
        string nombreCiudad = txtNombreCiudad.Text;
        string pais = txtPais.Text;

        Ciudades C = (Ciudades)Session["unaC"];//subido a la session por el boton buscar

        C.CodigoCiudad = codigoCiudad;
        C.NomCiudad = nombreCiudad;
        C.Pais = pais;

        try
        {

            LogicaCiudades.ModificarCiudad(C);
            lblGood.Text = "Modificación Exitosa";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnEliminarCiudad_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudades C = (Ciudades)Session["unaC"];
            LogicaCiudades.EliminarCiudad(C);
            lblGood.Text = "Eliminación Exitosa";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioFormulario();
    }
}