using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Administracion_web
{
    public partial class Default : System.Web.UI.Page
    {
      ///  public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ListaArticulos"] == null)
            {     
            ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("ListaArticulos", negocio.listarConSP());
                //    ListaArticulos = negocio.listarConSP();
                }
         
         
                
            if (!IsPostBack)
            {
                repRepetidor.DataSource = Session["ListaArticulos"];
                repRepetidor.DataBind();
            }
  

        }

    

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
                

            string valor = ((Button)sender).CommandArgument;


            if ( valor != null)
            {
                int id = int.Parse(valor.ToString());
                List<Articulo> temporal = (List<Articulo>)Session["listaCarrito"];
              Articulo seleccionado = temporal.Find(x => x.Id == id);
        //         if ( seleccionado != null )
        //       {
                    temporal.Add(seleccionado);
        //        } else
        //        {
        //          aca tendiramos que sumar la cantidad 

        //        }


            }

        }
    }
}