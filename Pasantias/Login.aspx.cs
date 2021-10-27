using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pasantias
{
    public partial class Login : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Pasantias;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            logeo(txtUser.Text, txtPass.Text);
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

        public int logeo(string user, string pass)
        {
            try
            {
                int verificador=1;
                abrirConexion();
                string sql = "Select * from usuario where userName='"+user+"' and password='"+pass+"'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.Visible = false;
                    Response.Redirect("Principal.aspx");
                }
                else
                {
                    lblMensaje.Visible = true;
                }
                cerrarConexion();
                return verificador;
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('" + exc + "')</script>");
                throw;
            }
        }
    }
}