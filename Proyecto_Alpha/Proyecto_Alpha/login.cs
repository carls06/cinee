using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Globalization;

namespace Proyecto_Alpha
{
    public partial class login : Form
    {
        private SqlConnection conn;
        private string sCn;
        OleDbConnection cnn = new OleDbConnection();
        public login()
        {
            InitializeComponent();
            conexion cn = new conexion();
            cn.conec();
            sCn = cn.cadena;
            conn = new SqlConnection(sCn);
            conn.Open();
            cnn.ConnectionString = @"Provider=sqloledb;Data Source=SQL5008.site4now.net,1433;Initial Catalog=DB_A464EC_cine;User Id=DB_A464EC_cine_admin;Password=hola1234;";

            
        }

        public void inicio() {

            
                if (txtUsuario.Text == "")
                {
                }
                else
                {
                    if (txtContraseña.Text == "")
                    {
                    }
                    else
                    {
                        string s = "select logUsuario, contraseña, Cargo from usuario where logUsuario like '" + txtUsuario.Text + "' and contraseña like '" + txtContraseña.Text + "'";
                        SqlCommand comander = new SqlCommand(s, conn);
                        using (SqlDataReader read = comander.ExecuteReader())
                        {
                            while (read.Read())
                            {
                                if (txtUsuario.Text == read["logUsuario"].ToString() && txtContraseña.Text == read["contraseña"].ToString() && read["cargo"].ToString() == "Admin")
                                {
                                    MessageBox.Show("Hola Admin");
                                    form fo = new form();

                                    tipo = "Admin";
                                    fo.Show();


                                    this.Hide();

                                }
                                else
                                {
                                    MessageBox.Show("Hola user");
                                    form form = new form();
                                    tipo = "User";
                                    form.Show();

                                    this.Hide();
                                }


                            }
                        }
                    }
                }
            
           
        }

        public static string tipo;
        
        private void button1_Click(object sender, EventArgs e)
        {
            inicio();
        }

        private void login_Load(object sender, EventArgs e)
        {
            //conn.Open();
        }
       

        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void txtContraseña_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.inicio();
                
        }
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
