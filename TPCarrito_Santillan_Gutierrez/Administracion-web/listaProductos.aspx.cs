﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;


namespace Administracion_web
{
    public partial class listaProductos : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)

        {
            
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.listarConSP();
            dgvArticulos.DataBind();
        }
    }
}