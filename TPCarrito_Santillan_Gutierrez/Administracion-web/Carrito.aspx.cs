using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion_web
{

    public partial class Carrito : System.Web.UI.Page
    {

        public List<itemCarrito> ListaEnCarrito;
        public carritoCompra carrito = new carritoCompra();

        protected void Page_Load(object sender, EventArgs e)
        {

            ListaEnCarrito = (List<itemCarrito>)Session["listaEnCarro"];
            carrito = (carritoCompra)Session["total"];


            if (ListaEnCarrito == null)
                ListaEnCarrito = new List<itemCarrito>();

            if (carrito == null)
                carrito = new carritoCompra();
            



            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    List<Articulo> listadoOriginal = (List<Articulo>)Session["listadoProductos"];
                    itemCarrito aux = new itemCarrito();

                        if (aux.cantidad == 0)
                        {
                            aux.cantidad +=1;
                        }

                        aux.item = listadoOriginal.Find(x => x.Id.ToString() == Request.QueryString["Id"]);
                        aux.subtotal = aux.cantidad * aux.item.Precio;
                        aux.id = aux.item.Id;

                        carrito.total += aux.item.Precio;
                        //lblPrecioTotal.Text = "$ Total: " + carrito.total.ToString();
                        

                        ListaEnCarrito.Add(aux);
                    
                  
                    

                    carrito.listado = ListaEnCarrito;

                }
                repetidor.DataSource = ListaEnCarrito;
                repetidor.DataBind();
            }

            lblPrecioTotal.Text = "$ Total: " + carrito.total.ToString();
            Session.Add("listaEnCarro", ListaEnCarrito);
            Session.Add("total", carrito);

        }
    }
}
