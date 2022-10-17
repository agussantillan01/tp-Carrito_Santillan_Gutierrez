using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion= new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security = true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.Id,A.CODIGO, A.Nombre,A.Descripcion,M.Descripcion AS Marca,C.Descripcion AS TIPO,A.ImagenUrl, A.Precio, A.IdCategoria, A.IdMarca FROM ARTICULOS A LEFT JOIN MARCAS M ON M.ID= A.IDMARCA LEFT JOIN CATEGORIAS C ON C.ID= A.IdCategoria";
                comando.Connection = conexion;  
                conexion.Open();

                lector = comando.ExecuteReader();
                while (lector.Read())
                {

                    //CODIGO, NOMBRE, DESCRIPCION, IMAGEN,CATEGORIA, MARCA Y PRECIO PERMITEN NULOS
                    // CATEGORIA Y MARCA NO ES POSIBLE QUE SE CARGUEN DE MANERA NULA
                    Articulo art = new Articulo();
                    art.Id = (int)lector["Id"];
                    if (!(lector["CODIGO"] is DBNull))
                        art.Codigo = (string)lector["CODIGO"];
                    if (!(lector["NOMBRE"] is DBNull))
                        art.Nombre = (string)lector["NOMBRE"];
                    if (!(lector["Descripcion"] is DBNull))
                        art.Descripcion = (string)lector["Descripcion"];
                    if (!(lector["ImagenUrl"] is DBNull))
                    art.ImagenUrl = (string)lector["ImagenUrl"];
                    if (!(lector["Precio"] is DBNull))
                        art.Precio = (decimal)lector["Precio"];

                    art.Marca = new Marca();
                    art.Marca.Id = (int)lector["IdMarca"];
                    art.Marca.NombreMarca = (string)lector["Marca"];


                    art.Categoria = new Categoria();
                    art.Categoria.Id = (int)lector["IdCategoria"];
                    //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                    if (!(lector["TIPO"]is DBNull))
                    art.Categoria.Tipo = (string)lector["TIPO"];



                    lista.Add(art);
                }

                //conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            
        }

        public List<Articulo> listarConSP()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //string consulta = "SELECT A.Id,A.CODIGO,A.Nombre,A.Descripcion,M.Descripcion AS Marca,C.Descripcion AS TIPO,A.ImagenUrl,A.Precio,A.IdCategoria,A.IdMarca FROM ARTICULOS A LEFT JOIN MARCAS M ON M.ID= A.IDMARCA LEFT JOIN CATEGORIAS C ON C.ID= A.IdCategoria";
                //datos.setearConsulta(consulta);
                datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["CODIGO"] is DBNull))
                        art.Codigo = (string)datos.Lector["CODIGO"];
                    if (!(datos.Lector["NOMBRE"] is DBNull))
                        art.Nombre = (string)datos.Lector["NOMBRE"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        art.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        art.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        art.Precio = (decimal)datos.Lector["Precio"];

                    art.Marca = new Marca();
                    art.Marca.Id = (int)datos.Lector["IdMarca"];
                    art.Marca.NombreMarca = (string)datos.Lector["Marca"];


                    art.Categoria = new Categoria();
                    art.Categoria.Id = (int)datos.Lector["IdCategoria"];


                    if (!(datos.Lector["TIPO"] is DBNull))
                        art.Categoria.Tipo = (string)datos.Lector["TIPO"];



                    lista.Add(art);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> listarPorParametro(int id)
        {

            {
                List<Articulo> lista = new List<Articulo>();
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;
                try
                {
                    conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security = true";
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "SELECT A.Id,A.CODIGO, A.Nombre,A.Descripcion,M.Descripcion AS Marca,C.Descripcion AS TIPO,A.ImagenUrl, A.Precio, A.IdCategoria, A.IdMarca FROM ARTICULOS A LEFT JOIN MARCAS M ON M.ID= A.IDMARCA LEFT JOIN CATEGORIAS C ON C.ID= A.IdCategoria where a.Id="+id;
                    comando.Connection = conexion;
                    conexion.Open();

                    lector = comando.ExecuteReader();
                    while (lector.Read())
                    {

                        //CODIGO, NOMBRE, DESCRIPCION, IMAGEN,CATEGORIA, MARCA Y PRECIO PERMITEN NULOS
                        // CATEGORIA Y MARCA NO ES POSIBLE QUE SE CARGUEN DE MANERA NULA
                        Articulo art = new Articulo();
                        art.Id = (int)lector["Id"];
                        if (!(lector["CODIGO"] is DBNull))
                            art.Codigo = (string)lector["CODIGO"];
                        if (!(lector["NOMBRE"] is DBNull))
                            art.Nombre = (string)lector["NOMBRE"];
                        if (!(lector["Descripcion"] is DBNull))
                            art.Descripcion = (string)lector["Descripcion"];
                        if (!(lector["ImagenUrl"] is DBNull))
                            art.ImagenUrl = (string)lector["ImagenUrl"];
                        if (!(lector["Precio"] is DBNull))
                            art.Precio = (decimal)lector["Precio"];

                        art.Marca = new Marca();
                        art.Marca.Id = (int)lector["IdMarca"];
                        art.Marca.NombreMarca = (string)lector["Marca"];


                        art.Categoria = new Categoria();
                        art.Categoria.Id = (int)lector["IdCategoria"];
                        //SI EL TIPO DE ARTICULO NO ES NULO LO LEE
                        if (!(lector["TIPO"] is DBNull))
                            art.Categoria.Tipo = (string)lector["TIPO"];



                        lista.Add(art);
                    }

                    //conexion.Close();
                    return lista;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conexion.Close();
                }

            }
        }
        public void agregar(Articulo articuloNuevo) 
        {

            AccesoDatos datos = new AccesoDatos();


            try
            {
              datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio, imagenUrl) values ('" + articuloNuevo.Codigo + "','" + articuloNuevo.Nombre + "','" + articuloNuevo.Descripcion + "', @idMarca, @idCategoria,'" + articuloNuevo.Precio+"','" + articuloNuevo.ImagenUrl+"' )");
                datos.setearParametro("idMarca", articuloNuevo.Marca.Id);
                datos.setearParametro("idCategoria", articuloNuevo.Categoria.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public void Modificar(Articulo artModificado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo=@Codigo , Descripcion = @Descripcion, ImagenUrl =@ImagenUrl, Precio =@Precio, IdCategoria=@IdCategoria, IdMarca =@IdMarca where Id=@Id");
                datos.setearParametro("@Codigo", artModificado.Codigo);
                datos.setearParametro("@Descripcion", artModificado.Descripcion);
                datos.setearParametro("@ImagenUrl", artModificado.ImagenUrl);
                datos.setearParametro("@Precio", artModificado.Precio);
                datos.setearParametro("@IdCategoria", artModificado.Categoria.Id);
                datos.setearParametro("@IdMarca", artModificado.Marca.Id);
                datos.setearParametro("@Id", artModificado.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where Id = @Id");
                datos.setearParametro("@Id",id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista=new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id,A.CODIGO,A.Nombre,A.Descripcion,M.Descripcion AS Marca,C.Descripcion AS TIPO,A.ImagenUrl,A.Precio,A.IdCategoria,A.IdMarca FROM ARTICULOS A LEFT JOIN MARCAS M ON M.ID= A.IDMARCA LEFT JOIN CATEGORIAS C ON C.ID= A.IdCategoria WHERE ";
                switch (campo)
                {
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.NOMBRE LIKE '"+filtro+"%'  ";
                            break;
                            case "Termina con":
                                consulta += "A.NOMBRE LIKE '%"+filtro+"'  ";
                                break;
                            case "Contiene":
                                consulta += "A.NOMBRE LIKE '%"+filtro+"%'  ";
                                break;
                        }
                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "M.Descripcion LIKE '" + filtro + "%'  ";
                                break;
                            case "Termina con":
                                consulta += "M.Descripcion LIKE '%" + filtro + "'  ";
                                break;
                            case "Contiene":
                                consulta += "M.Descripcion LIKE '%"+filtro+"%'  ";
                                break;
                        }
                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "C.Descripcion LIKE '" + filtro + "%'  ";
                                break;
                            case "Termina con":
                                consulta += "C.Descripcion LIKE '%" + filtro + "'  ";
                                break;
                            case "Contiene":
                                consulta += "C.Descripcion LIKE '%" +filtro+ "%'  ";
                                break;
                        }
                        break;
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "A.Precio > " + filtro;
                                break;
                            case "Menor a":
                                    consulta += "A.Precio < " + filtro;
                                break;
                            case "Igual a":
                                consulta += "A.Precio = " + filtro;
                                break;
                            default:
                                break;
                        }
                        break;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["CODIGO"] is DBNull))
                        art.Codigo = (string)datos.Lector["CODIGO"];
                    if (!(datos.Lector["NOMBRE"] is DBNull))
                        art.Nombre = (string)datos.Lector["NOMBRE"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        art.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        art.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        art.Precio = (decimal)datos.Lector["Precio"];

                    art.Marca = new Marca();
                    art.Marca.Id = (int)datos.Lector["IdMarca"];
                    art.Marca.NombreMarca = (string)datos.Lector["Marca"];


                    art.Categoria = new Categoria();
                    art.Categoria.Id = (int)datos.Lector["IdCategoria"];


                    if (!(datos.Lector["TIPO"] is DBNull))
                        art.Categoria.Tipo = (string)datos.Lector["TIPO"];



                    lista.Add(art);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
