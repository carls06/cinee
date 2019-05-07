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
using System.Runtime.InteropServices;

namespace Proyecto_Alpha
{
    public partial class login : Form
    {
        private SqlConnection conn;
        private string sCn;
        
        public login()
        {
            InitializeComponent();
            conexion cn = new conexion();
            cn.conec();
            sCn = cn.cadena;
            conn = new SqlConnection(sCn);
            conn.Open();
           
        }

        //metodos para mover a cualquier lado de la pandalla el form

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        public void inicio()
        {

            //try
            //{
                if (txtUsuario.Text != null)
                {


                    if (txtContraseña.Text != null)
                    {


                        string s = "select logUsuario, contraseña, Cargo from usuario where logUsuario like '" + txtUsuario.Text + "' and contraseña like '" + txtContraseña.Text + "'";
                        SqlCommand comander = new SqlCommand(s, conn);
                       
                        

                            SqlDataAdapter adapt = new SqlDataAdapter(comander);
                            DataTable prueba = new DataTable();
                            adapt.Fill(prueba);

                              
                        if ((txtUsuario.Text == prueba.Rows[0][0].ToString()) && (txtContraseña.Text == prueba.Rows[0][1].ToString()))
                        {

                            if (prueba.Rows[0][2].ToString()== "Admin"){

                                MessageBox.Show("BIENVENIDO!", "HOLA ADMIN");


                                form fo = new form();

                                tipo = "Admin";
                                fo.Show();

                                this.Hide();
                            }       
                             else
                             {

                                MessageBox.Show("BIENVENIDO!", "HOLA USER");
                                form form = new form();
                                tipo = "User";
                                form.Show();

                                this.Hide();
                             }
                        }
  
                    }
 
                }
            //}
            

            //catch
            //{
            //    MessageBox.Show("Error! Su contraseña y/o usuario son invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        public static string tipo;
        
        private void button1_Click(object sender, EventArgs e)
        {
                inicio();
        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //para iniciar sesion con un enter
        private void txtContraseña_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                this.inicio();
                
        }
        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.Silver;
            }
        }

        private void TxtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Password")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void TxtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Password";
                txtContraseña.ForeColor = Color.Silver;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        //eventos que permiten mover de posicion el form
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {

           
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Panel3_MouseDown(object sender, MouseEventArgs e)
        {
           
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
