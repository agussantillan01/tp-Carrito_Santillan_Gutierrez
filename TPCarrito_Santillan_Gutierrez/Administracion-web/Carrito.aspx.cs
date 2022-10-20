using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion_web
{

    public partial class Carrito : System.Web.UI.Page
    {

       protected void Page_Load(object sender, EventArgs e)
        {
            ///public string Id { get; set; }

       

            if (Session["ListaCarrito"] == null)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                
                Session.Add("ListaCarrito", negocio.listarConSP());
                //    ListaArticulos = negocio.listarConSP();
            }



            if (!IsPostBack)
            {
                dgvCarrito.DataSource = Session["ListaCarrito"];
                dgvCarrito.DataBind();
            }




        }
    }
}
