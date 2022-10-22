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
    public partial class detalleArticulo : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        public Articulo seleccionado;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["Id"]);

                List<Articulo> listado = (List<Articulo>)Session["listadoProductos"];
                seleccionado = listado.Find(x => x.Id == id);




            }


        }
    }
}