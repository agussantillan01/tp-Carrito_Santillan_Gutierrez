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
        public List<Articulo> ListaArticulos { get; set; }
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
            
                        if (Request.QueryString["Id"] != null)
                        {
                            int Id = int.Parse(Request.QueryString["Id"].ToString());
                            List<Articulo> temporal = (List<Articulo>)Session("listaCarrito");
                            Articulo seleccionado = temporal.Find(x => x.Id == Id);
                //aca puedo usar lo q traje
                // PONER UNA CAJA  y ... =seleccionado.Id;
                // PONER UNA CAJA  y ... =seleccionado. algo ;



            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
      //  var Id repRepetidor.SelectedDataKey.Value.ToString();

        }
    }
}