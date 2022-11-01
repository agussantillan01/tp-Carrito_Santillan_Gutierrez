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

            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listar();
            Session.Add("listadoProductos", ListaArticulos);

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (Buscador.Text == "")
                {
                    ListaArticulos = negocio.listar();

                }
                else
                {
                    ListaArticulos = negocio.listarConParametros(armaConsultaFiltro());
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string armaConsultaFiltro()
        {
            string consulta = "";
            if (Buscador.Text != "")
            {
                consulta += "A.Nombre LIKE '%" + Buscador.Text.ToString() + "%'";

            }


            return consulta;
        }
    }
}