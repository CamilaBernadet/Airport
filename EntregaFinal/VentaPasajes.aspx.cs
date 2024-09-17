using System;
using System.Collections.Generic;
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

public partial class VentaPasajes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                List<Vuelos> unV = LogicaVuelos.ListarVuelos();

                if (unV.Count > 0)
                {
                    ddlVuelo.DataSource = unV;
                    ddlVuelo.DataTextField = "CodigoVuelo";
                    ddlVuelo.DataValueField = "CodigoVuelo";
                    ddlVuelo.DataBind();
                    Session["listarVuelo"] = unV;

                }

                else
                {
                    lblError.Text = "Error: No existe ningun Vuelo.";

                }

                List<Clientes> unC = LogicaClientes.ListarClientes();

                if (unC.Count > 0)
                {
                    ddlCliente.DataSource = unC;
                    ddlCliente.DataTextField = "Pasaporte";
                    ddlCliente.DataValueField = "Pasaporte";
                    ddlCliente.DataBind();
                    Session["listarCliente"] = unC;

                }

                else
                {
                    lblError.Text = "Error: No existe ningun Cliente.";

                }
            }
        }

        catch (Exception ex)
        {
            lblError.Text = "Error: " + ex.Message;

        }
    }



    protected void btnAgregarPasaje_Click(object sender, EventArgs e)
    {
         {
        try
        {

            if(ddlVuelo.SelectedIndex==-1)
                throw new Exception("No ha seleccionado un Vuelo");

                Vuelos unV = ((List<Vuelos>)Session["listarVuelo"])[ddlVuelo.SelectedIndex];

                if (unV == null)
                throw new Exception("El Vuelo seleccionado no existe");

            if (ddlCliente.SelectedIndex == -1)
                    throw new Exception("No ha seleccionado un Cliente");

                Clientes unC = ((List<Clientes>)Session["listarCliente"])[ddlCliente.SelectedIndex];

                if (unC == null)
                    throw new Exception("El Cliente seleccionado no existe");

                // Crear el objeto Pasaje sin especificar el número de venta
                Pasajes unP = new Pasajes(0, 0, DateTime.Now, unV, unC);

                // Calcular el precio total
                //int precioTotal = unP.CalcularPrecioTotal();                
                
                Logica.LogicaPasajes.VentaPasajes(unP);

            // Asignar valores a las etiquetas
            lblFecha.Text = unP.FechaCompra.ToString("dd/MM/yyyy");
            lblPrecioTotal.Text = unP.PrecioTotal.ToString("00.00 $");
            lblNroVenta.Text = unP.NroVenta.ToString("");

            lblGood.Text = "Alta con Éxito!";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
    }

    private void LimpioFormulario()
    { 

        lblError.Text = "";
        lblGood.Text = "";
        lblFecha.Text = "";
        lblNroVenta.Text = "";
        lblPrecioTotal.Text = "";
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioFormulario();
    }
}
