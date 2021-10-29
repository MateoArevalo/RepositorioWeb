using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pasantias
{
    public partial class Principal : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Pasantias;Integrated Security=True");
        DataSet data = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                cargarCategoria();
                cargarProducto();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (hdfIdProducto != null)
            {
                editarProducto(txtProducto.Text, txtDescripcion.Text, Convert.ToInt32(cbxCategoria.SelectedValue), Convert.ToDouble(txtPrecio.Text), Convert.ToInt32(hdfIdProducto.Value));
                hdfIdProducto.Value = string.Empty;
                limpiar();
            }
            else
            {
                CrearProducto(txtProducto.Text, Convert.ToInt32(cbxCategoria.SelectedValue), txtDescripcion.Text, Convert.ToDouble(txtPrecio.Text));
                limpiar();
            }
            
        }

        public void abrirConexion()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void cerrarConexion()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public void CrearProducto(string nombre, int categoria, string descripcion, double precio)
        {
            try
            {
                abrirConexion();
                string sql = "Insert Into productos Values(@nom , @cat , @desc , @prec)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nom", nombre);
                cmd.Parameters.AddWithValue("@cat", categoria);
                cmd.Parameters.AddWithValue("@desc", descripcion);
                cmd.Parameters.AddWithValue("@prec", precio);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                cerrarConexion();
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc + "')</script>");
                throw;
            }
        }

        public void limpiar()
        {
            txtProducto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cbxCategoria.SelectedIndex = 1;
            txtPrecio.Text = "1";
        }

        public void cargarCategoria()
        {
            try
            {
                abrirConexion();
                string sql = "Select idCategoria, categoria from categorias";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                dt.Fill(data, "Categorias");
                cbxCategoria.DataSource = data.Tables["Categorias"];
                cbxCategoria.DataTextField = "categoria";
                cbxCategoria.DataValueField = "idCategoria";
                cbxCategoria.DataBind();
                cerrarConexion();
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc + "')</script>");
                throw;
            }
        }

        public void cargarProductoId(int id)
        {
            abrirConexion();
            string sql = "Select idProducto, producto, c.categoria, descripcion, precio from productos as p inner join categorias as c on c.idCategoria=p.idCategoria where idProducto= "+id+"";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter dt = new SqlDataAdapter(cmd);
            dt.Fill(data, "ProductosId");
            txtProducto.Text = data.Tables["ProductosId"].Rows[0][1].ToString();
            cbxCategoria.SelectedItem.Text = data.Tables["ProductosId"].Rows[0][2].ToString();
            txtDescripcion.Text = data.Tables["ProductosId"].Rows[0][3].ToString();
            txtPrecio.Text = data.Tables["ProductosId"].Rows[0][4].ToString();
            cerrarConexion();
        }

        public void cargarProducto()
        {
            try
            {
                abrirConexion();
                string sql = "Select idProducto, producto, c.categoria, descripcion, precio from productos as p inner join categorias as c on c.idCategoria=p.idCategoria";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter dt = new SqlDataAdapter(cmd);
                dt.Fill(data, "Productos");
                grvProducto.DataSource = data.Tables["Productos"];
                grvProducto.DataBind();
                cerrarConexion();
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc + "')</script>");
                throw;
            }
        }

        public void eliminarProducto(int id)
        {
            abrirConexion();
            string sql = "Delete productos where idProducto=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            cerrarConexion();
        }

        public void editarProducto(string nombre, string descripcion, int categoria, double precio, int id)
        {
            abrirConexion();
            string sql = "Update productos set producto=@nom, descripcion=@desc, idCategoria=@cat, precio=@prec where idProducto=@id";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@nom", nombre);
            cmd.Parameters.AddWithValue("@desc", descripcion);
            cmd.Parameters.AddWithValue("@cat", categoria);
            cmd.Parameters.AddWithValue("@prec", precio);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cerrarConexion();
        }

        protected void btnEliminarProducto_Click(object sender, ImageClickEventArgs e)
        {
            int idProd = Convert.ToInt32((sender as ImageButton).CommandArgument);
            hdfIdProducto.Value = idProd.ToString();
            eliminarProducto(idProd);
        }

        protected void btnSeleccionarProducto_Click(object sender, ImageClickEventArgs e)
        {
            int idProd = Convert.ToInt32((sender as ImageButton).CommandArgument);
            hdfIdProducto.Value = idProd.ToString();
            cargarProductoId(Convert.ToInt32(hdfIdProducto.Value));
        }
    }
}