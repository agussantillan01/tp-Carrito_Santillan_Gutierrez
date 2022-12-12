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

        public carritoCompra carrito = new carritoCompra();
        public List<itemCarrito> ListaEnCarrito;

        decimal totalAux;
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
                    if (ListaEnCarrito.Find(x => x.item.Id.ToString() == Request.QueryString["Id"]) == null)
                    {
                        List<Articulo> listadoOriginal = (List<Articulo>)Session["listadoProductos"];
                        itemCarrito aux = new itemCarrito();

                        if (aux.cantidad == 0)
                        {
                            aux.cantidad = 1;
                        }

                        aux.item = listadoOriginal.Find(x => x.Id.ToString() == Request.QueryString["Id"]);
                        aux.subtotal = aux.cantidad * aux.item.Precio;
                        aux.id = aux.item.Id;

                        carrito.total += aux.item.Precio;

                        lblPrecioTotal.Text = "Total: " + carrito.total.ToString();

                        ListaEnCarrito.Add(aux);
                    }
                    carrito.listado = ListaEnCarrito;

                }
                repetidor.DataSource = ListaEnCarrito;
                repetidor.DataBind();
            }

            lblPrecioTotal.Text = "$ Total: " + carrito.total.ToString();
            Session.Add("listaEnCarro", ListaEnCarrito);
            Session.Add("total", carrito);

        }

        protected void btnDec_Click(object sender, EventArgs e)
        {
            carrito = (carritoCompra)Session["Total"];

            totalAux = 0;


            var argument = ((Button)sender).CommandArgument;
            List<itemCarrito> ListaEnCarrito = (List<itemCarrito>)Session["listaEnCarro"];
            itemCarrito sobrecarga = ListaEnCarrito.Find(x => x.id.ToString() == argument);
            if (sobrecarga.cantidad > 1)
            {
                sobrecarga.cantidad--;
                sobrecarga.subtotal = sobrecarga.item.Precio * sobrecarga.cantidad;
                var elementIndex = ListaEnCarrito.FindIndex(x => x.id.ToString() == argument);
                ListaEnCarrito[elementIndex] = sobrecarga;

                foreach (itemCarrito i in ListaEnCarrito)
                {
                    totalAux += i.subtotal;
                }


                carrito.total = totalAux;

                lblPrecioTotal.Text = "Total: " + carrito.total.ToString();


                Session.Add("listaEnCarro", ListaEnCarrito);
                Session.Add("Total", carrito);
                repetidor.DataSource = null;
                repetidor.DataSource = ListaEnCarrito;
                repetidor.DataBind();

                Response.Redirect("Carrito.aspx");
                
            }
        }

        protected void btnInc_Click(object sender, EventArgs e)
        {
            carrito = (carritoCompra)Session["Total"];
            totalAux = 0;
            var argument = ((Button)sender).CommandArgument;
            List<itemCarrito> ListaEnCarrito = (List<itemCarrito>)Session["listaEnCarro"];
            itemCarrito sobrecarga = ListaEnCarrito.Find(x => x.id.ToString() == argument);


            sobrecarga.cantidad++;
            sobrecarga.subtotal = sobrecarga.item.Precio * sobrecarga.cantidad;

            var indiceItem = ListaEnCarrito.FindIndex(x => x.id.ToString() == argument);
            ListaEnCarrito[indiceItem] = sobrecarga;

            foreach (itemCarrito i in ListaEnCarrito)
            {
                totalAux += i.subtotal;
            }

            carrito.total = totalAux;

            lblPrecioTotal.Text = "Total: " + carrito.total.ToString();

            Session.Add("listaEnCarro", ListaEnCarrito);
            Session.Add("Total", carrito);
            repetidor.DataSource = null;
            repetidor.DataSource = ListaEnCarrito;
            repetidor.DataBind();

            Response.Redirect("Carrito.aspx");

        }

        protected void btnEliminar2_Click(object sender, EventArgs e)
        {
            carrito = (carritoCompra)Session["total"];

            var argument = ((Button)sender).CommandArgument;
            List<itemCarrito> ListaEnCarrito = (List<itemCarrito>)Session["listaEnCarro"];
            itemCarrito elim = ListaEnCarrito.Find(x => x.id.ToString() == argument);
            ListaEnCarrito.Remove(elim);

            carrito.total -= elim.subtotal;
            if (carrito.total < 0) carrito.total = 0;
            lblPrecioTotal.Text = "Total: " + carrito.total.ToString();


            Session.Add("listaEnCarro", ListaEnCarrito);
            Session.Add("total", carrito);
            repetidor.DataSource = null;
            repetidor.DataSource = ListaEnCarrito;
            repetidor.DataBind();



            if (carrito.listado.Count > 0)
            {
                Response.Redirect("Carrito.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}
