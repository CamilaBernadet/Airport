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

public partial class MantenimientoClientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            this.LimpioFormulario();
    }

    private void ActivoBotonesBM()
    {
        btnModCliente.Enabled = true;
        btnEliminarCliente.Enabled = true;

        btnAltaCliente.Enabled = false;
        btnBuscar.Enabled = false;

        txtPasaporte.Enabled = false;
    }

    private void ActivoBotonesA()
    {
        btnModCliente.Enabled = false;
        btnEliminarCliente.Enabled = false;

        btnAltaCliente.Enabled = true;
        btnBuscar.Enabled = false;

        txtPasaporte.Enabled = false;
    }

    private void LimpioFormulario()
    {
        btnModCliente.Enabled = false;
        btnEliminarCliente.Enabled = false;

        btnAltaCliente.Enabled = false;
        btnBuscar.Enabled = true;

        txtPasaporte.Enabled = true;

        txtPasaporte.Text = "";
        txtNombreCliente.Text = "";
        txtTarjeta.Text = "";
        txtContraseña.Text = "";

        lblError.Text = "";

    }


    protected void btnAltaCliente_Click(object sender, EventArgs e)
    {
        try
        {
            Clientes _unC = new Clientes(txtPasaporte.Text, txtNombreCliente.Text, Convert.ToInt32(txtTarjeta.Text), txtContraseña.Text);

            LogicaClientes.AltaCliente(_unC);
            lblGood.Text = "Alta con exito";

            //limpio pantalla
            this.LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnModCliente_Click(object sender, EventArgs e)
    {
        try
        {
            Clientes _unC = (Clientes)Session["Cliente"];

            //modifico el objeto
            _unC.Pasaporte = txtPasaporte.Text;
            _unC.NomCliente = txtNombreCliente.Text;
            _unC.ContraCliente = txtContraseña.Text;
            _unC.NroTarjeta = Convert.ToInt32(txtTarjeta.Text);

            LogicaClientes.ModificarCliente(_unC);
            lblGood.Text = "Modificacion con éxito";
            this.LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    protected void btnEliminarCliente_Click(object sender, EventArgs e)
    {
        try
        {
            Clientes _unC = (Clientes)Session["Cliente"];

            LogicaClientes.EliminarCliente(_unC);

            lblGood.Text = "Eliminacion con éxito";
            this.LimpioFormulario();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {

            Clientes _Clientes = LogicaClientes.BuscarCliente(txtPasaporte.Text);

            //determino acciones
            if (_Clientes == null)
            {
                //alta
                this.ActivoBotonesA();
                Session["Cliente"] = null;
            }
            else
            {
                this.ActivoBotonesBM();
                Session["Cliente"] = _Clientes;

                txtPasaporte.Text = _Clientes.Pasaporte;
                txtNombreCliente.Text = _Clientes.NomCliente;
                txtTarjeta.Text = _Clientes.NroTarjeta.ToString();
                txtContraseña.Text = _Clientes.ContraCliente;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.LimpioFormulario();
        lblGood.Text = "";
        txtPasaporte.Text = "";
    }

}