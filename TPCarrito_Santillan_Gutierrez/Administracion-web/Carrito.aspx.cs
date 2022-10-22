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

        public List<itemCarrito> ListaEnCarrito;


        protected void Page_Load(object sender, EventArgs e)
        {

            ListaEnCarrito = (List<itemCarrito>)Session["listaEnCarro"];



            if (ListaEnCarrito == null)
                ListaEnCarrito = new List<itemCarrito>();




            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    if (ListaEnCarrito.Find(x => x.item.Id.ToString() == Request.QueryString["Id"]) == null)
                    {
                        List<Articulo> listadoOriginal = (List<Articulo>)Session["listadoProductos"];
                        itemCarrito aux = new itemCarrito();

                        aux.item = listadoOriginal.Find(x => x.Id.ToString() == Request.QueryString["Id"]);
                        aux.subtotal = aux.item.Precio;
                        aux.id = aux.item.Id;

                        ListaEnCarrito.Add(aux);
                    }


                }
                repetidor.DataSource = ListaEnCarrito;
                repetidor.DataBind();
            }


            Session.Add("listaEnCarro", ListaEnCarrito);

        }
    }
}
