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
    public partial class form : Form
    {
        double cant = 0;
        private ListViewItem lista;
        private SqlConnection conn;
        private string sCn;
        //Defino una variable de tipo Connection
        private SqlConnection conn1;
        //Defino una variable de tipo DataAdapter
        private string sCn1;
        private SqlCommand insert;
        //instacio un variable OleDbConection
        OleDbConnection cnn = new OleDbConnection();
        public form()
        {
            InitializeComponent();
            //usando la clase conexión
            // creo un nuevo objeto de tipo Conexión y lo asigno a cn
            conexion cn = new conexion();
            //acceso a la función conec de la clase conexión
            cn.conec();
            //agrego la variable scn a la cadena conexión
            sCn = cn.cadena;
            //creo la conexión pensándole como argumento la cadena
            conn = new SqlConnection(sCn);
            //abro la conexión
            conn.Open();
            cnn.ConnectionString = @"PROVIDER=SQLOLEDB;server= DESKTOP-F9FC1KG\\MSSQL; database= teatro ; Integrated Security=true;";
            conexion cn1 = new conexion();
            cn1.conec();
            sCn1 = cn1.cadena;
            conn1 = new SqlConnection(sCn1);
            conn1.Open();



        }

        private void agregarEventoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_Evento n = new Agregar_Evento();
            n.Show();
        }
        // cambiar la direccion por cada computadora

        Image Rojo = Image.FromFile(@"C:\Users\pc\Documents\GitKraken\cine\Proyecto_Alpha\Proyecto_Alpha\Silla_Roja.png");
        Image Negro = Image.FromFile(@"C:\Users\pc\Documents\GitKraken\cine\Proyecto_Alpha\Proyecto_Alpha\Silla_Negra.png");

        private void btnsql_Click(object sender, EventArgs e)
        {
            if (cmbHora.SelectedItem == null) { }
            else
            {
                string s = cmbHora.SelectedItem.ToString();
                DateTime fech = Convert.ToDateTime(s);
                foreach (ListViewItem item in lslButaca.Items)
                {
                    string insertar = "insert into butaca(fecha, nombrebu)";
                    insertar += " values(@Fecha, @NombreBu)";
                    insert = new SqlCommand(insertar, conn);
                    insert.Parameters.Add(new SqlParameter("@NombreBu", SqlDbType.VarChar));
                    insert.Parameters["@NombreBu"].Value = item.Text;
                    insert.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.SmallDateTime));
                    insert.Parameters["@Fecha"].Value = fech.ToString("yyyy/MM/dd HH:mm:00");
                    insert.ExecuteNonQuery();
                }
                reserva.Start();
                reset.Start();
            }
        }
        public void suma()
        {
            double precio = lslButaca.Items.Count * 4.00;
            lblMoney.Text = precio.ToString();
        }

        private void silla1_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFuncion.SelectedItem == null && cmbHora.SelectedItem == null) { }
            else
            {
                string[] but = { "A1", "4.00" };
                lista = new ListViewItem(but);
                if (A1.Checked == true)
                {
                    A1.Image = Rojo;
                    lslButaca.Items.Add(lista);
                }
                if (A1.Checked == false)
                {
                    A1.Image = Negro;
                    lslButaca.Items.Remove(lslButaca.FindItemWithText("A1"));
                }
                suma();
            }
        }
        private void silla2_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFuncion.SelectedItem == null && cmbHora.SelectedItem == null) { }
            else
            {
                string[] but = { "A2", "4.00" };
                lista = new ListViewItem(but);
                if (A2.Checked == true)
                {
                    A2.Image = Rojo;
                    lslButaca.Items.Add(lista);
                }
                if (A2.Checked == false)
                {
                    A2.Image = Negro;
                    lslButaca.Items.Remove(lslButaca.FindItemWithText("A2"));
                }
                suma();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFuncion.SelectedItem == null && cmbHora.SelectedItem == null) { }
            else
            {
                string[] but = { "A3", "4.00" };
                lista = new ListViewItem(but);

                if (A3.Checked == true)
                {
                    A3.Image = Rojo;
                    lslButaca.Items.Add(lista);
                }
                if (A3.Checked == false)
                {
                    A3.Image = Negro;
                    lslButaca.Items.Remove(lslButaca.FindItemWithText("A3"));
                }
                suma();
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFuncion.SelectedItem == null && cmbHora.SelectedItem == null) { }
            else
            {
                string[] but = { "A4", "4.00" };
                lista = new ListViewItem(but);
                if (A4.Checked == true)
                {
                    A4.Image = Rojo;

                    lslButaca.Items.Add(lista);
                }
                if (A4.Checked == false)
                {
                    A4.Image = Negro;
                    lslButaca.Items.Remove(lslButaca.FindItemWithText("A4"));

                }
                suma();
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFuncion.SelectedItem == null && cmbHora.SelectedItem == null) { }
            else
            {
                string[] but = { "A5", "4.00" };
                lista = new ListViewItem(but);
                if (A5.Checked == true)
                {
                    A5.Image = Rojo;

                    lslButaca.Items.Add(lista);
                    suma();
                }
                if (A5.Checked == false)
                {
                    A5.Image = Negro;
                    lslButaca.Items.Remove(lslButaca.FindItemWithText("A5"));

                }
                suma();
            }
        }
        private void cmbFuncion_SelectedIndexChanged(object sender, EventArgs e)
        {
            hora.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tipo.Text = login.tipo;
            if (tipo.Text == "Admin")
            {
                menuToolStripMenuItem.Visible = true;
                btnEliminarF.Visible = true;
            }
            else
                agregarEventoToolStripMenuItem.Visible = false;

            SqlCommand comander = new SqlCommand("SELECT nombreFu from funcion", conn);
            using (SqlDataReader read = comander.ExecuteReader())
            {
                while (read.Read())
                {
                    if (!cmbFuncion.Items.Contains(read["nombreFu"].ToString()))
                        cmbFuncion.Items.Add(read["nombreFu"].ToString());
                }
                hora.Start();
            }
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            cmbHora.SelectedItem = null;
            cmbHora.Items.Clear();
            cmbHora.Items.Clear();
            if (cmbFuncion.SelectedItem == null)
            {

            }
            else
            {
                string s = "SELECT fecha from funcion where nombrefu like '" + cmbFuncion.SelectedText + "'";
                SqlCommand comander = new SqlCommand(s, conn);
                using (SqlDataReader read = comander.ExecuteReader())
                {
                    while (read.Read())
                    {
                        cmbHora.Items.Add(read["fecha"].ToString());
                    }
                }
            }
            hora.Stop();
            reset.Start();
        }

        private void reserva_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (cmbFuncion.SelectedItem == null && cmbHora.SelectedItem == null)
            {
            }
            else
            {
                if (cmbHora.SelectedItem == null)
                {
                }
                else
                {
                    string d = cmbHora.SelectedItem.ToString();
                    string f = "yyyy-MM-dd HH:mm:ss";
                    DateTime tiempo = Convert.ToDateTime(d);
                    string s = "select nombrebu from funcion inner join butaca on funcion.fecha = butaca.fecha where funcion.fecha = '" + tiempo.ToString(f) + "'";
                    SqlCommand comander = new SqlCommand(s, conn);
                    using (SqlDataReader read = comander.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            listBox1.Items.Add(read["nombrebu"].ToString());
                        }
                    }
                }
            }

            if (listBox1.Items.Contains("A1"))
            {
                A1.Enabled = false;
            }
            else
            {
                A1.Enabled = true;
            }

            if (listBox1.Items.Contains("A2"))
            {
                A2.Enabled = false;
            }
            else
            {
                A2.Enabled = true;
            }

            if (listBox1.Items.Contains("A3"))
            {
                A3.Enabled = false;
            }
            else
            {
                A3.Enabled = true;
            }
            if (listBox1.Items.Contains("A4"))
            {
                A4.Enabled = false;
            }
            else
            {
                A4.Enabled = true;
            }
            if (listBox1.Items.Contains("A5"))
            {
                A5.Enabled = false;
            }
            else
            {
                A5.Enabled = true;
            }
            if (listBox1.Items.Contains("A6"))
            {
                A6.Enabled = false;
            }
            else
            {
                A6.Enabled = true;
            }
            if (listBox1.Items.Contains("A7"))
            {
                A7.Enabled = false;
            }
            else
            {
                A7.Enabled = true;
            }
            if (listBox1.Items.Contains("A8"))
            {
                A8.Enabled = false;
            }
            else
            {
                A8.Enabled = true;
            }
            if (listBox1.Items.Contains("A9"))
            {
                A9.Enabled = false;
            }
            else
            {
                A9.Enabled = true;
            }
            if (listBox1.Items.Contains("A10"))
            {
                A10.Enabled = false;
            }
            else
            {
                A10.Enabled = true;
            }
            if (listBox1.Items.Contains("B1"))
            {
                B1.Enabled = false;
            }
            else
            {
                B1.Enabled = true;
            }

            if (listBox1.Items.Contains("B2"))
            {
                B2.Enabled = false;
            }
            else
            {
                B2.Enabled = true;
            }
            if (listBox1.Items.Contains("B3"))
            {
                B3.Enabled = false;
            }
            else
            {
                B3.Enabled = true;
            }
            if (listBox1.Items.Contains("B4"))
            {
                B4.Enabled = false;
            }
            else
            {
                B4.Enabled = true;
            }
            if (listBox1.Items.Contains("B5"))
            {
                B5.Enabled = false;
            }
            else
            {
                B5.Enabled = true;
            }
            if (listBox1.Items.Contains("B6"))
            {
                B6.Enabled = false;
            }
            else
            {
                B6.Enabled = true;
            }
            if (listBox1.Items.Contains("B7"))
            {
                B7.Enabled = false;
            }
            else
            {
                B7.Enabled = true;
            }
            if (listBox1.Items.Contains("B8"))
            {
                B8.Enabled = false;
            }
            else
            {
                B8.Enabled = true;
            }
            if (listBox1.Items.Contains("B9"))
            {
                B9.Enabled = false;
            }
            else
            {
                B9.Enabled = true;
            }
            if (listBox1.Items.Contains("B10"))
            {
                B10.Enabled = false;
            }
            else
            {
                B10.Enabled = true;
            }
            if (listBox1.Items.Contains("C1"))
            {
                C1.Enabled = false;
            }
            else
            {
                C1.Enabled = true;
            }
            if (listBox1.Items.Contains("C2"))
            {
                C2.Enabled = false;
            }
            else
            {
                C2.Enabled = true;
            }
            if (listBox1.Items.Contains("C3"))
            {
                C3.Enabled = false;
            }
            else
            {
                C3.Enabled = true;
            }
            if (listBox1.Items.Contains("C4"))
            {
                C4.Enabled = false;
            }
            else
            {
                C4.Enabled = true;
            }
            if (listBox1.Items.Contains("C5"))
            {
                C5.Enabled = false;
            }
            else
            {
                C5.Enabled = true;
            }
            if (listBox1.Items.Contains("C6"))
            {
                C6.Enabled = false;
            }
            else
            {
                C6.Enabled = true;
            }
            if (listBox1.Items.Contains("C7"))
            {
                C7.Enabled = false;
            }
            else
            {
                C7.Enabled = true;
            }
            if (listBox1.Items.Contains("C8"))
            {
                C8.Enabled = false;
            }
            else
            {
                C8.Enabled = true;
            }
            if (listBox1.Items.Contains("C9"))
            {
                C9.Enabled = false;
            }
            else
            {
                C9.Enabled = true;
            }
            if (listBox1.Items.Contains("C10"))
            {
                C10.Enabled = false;
            }
            else
            {
                C10.Enabled = true;
            }
            if (listBox1.Items.Contains("D1"))
            {
                D1.Enabled = false;
            }
            else
            {
                D1.Enabled = true;
            }
            if (listBox1.Items.Contains("D2"))
            {
                D2.Enabled = false;
            }
            else
            {
                D2.Enabled = true;
            }
            if (listBox1.Items.Contains("D3"))
            {
                D3.Enabled = false;
            }
            else
            {
                D3.Enabled = true;
            }
            if (listBox1.Items.Contains("D4"))
            {
                D4.Enabled = false;
            }
            else
            {
                D4.Enabled = true;
            }
            if (listBox1.Items.Contains("D5"))
            {
                D5.Enabled = false;
            }
            else
            {
                D5.Enabled = true;
            }
            if (listBox1.Items.Contains("D6"))
            {
                D6.Enabled = false;
            }
            else
            {
                D6.Enabled = true;
            }
            if (listBox1.Items.Contains("D7"))
            {
                D7.Enabled = false;
            }
            else
            {
                D7.Enabled = true;
            } if (listBox1.Items.Contains("D8"))
            {
                D8.Enabled = false;
            }
            else
            {
                D8.Enabled = true;
            }
            if (listBox1.Items.Contains("E1"))
            {
                E1.Enabled = false;
            }
            else
            {
                E1.Enabled = true;
            }
            if (listBox1.Items.Contains("E2"))
            {
                E2.Enabled = false;
            }
            else
            {
                E2.Enabled = true;
            }
            if (listBox1.Items.Contains("E3"))
            {
                E3.Enabled = false;
            }
            else
            {
                E3.Enabled = true;
            }
            if (listBox1.Items.Contains("E4"))
            {
                E4.Enabled = false;
            }
            else
            {
                E4.Enabled = true;
            }
            if (listBox1.Items.Contains("E5"))
            {
                E5.Enabled = false;
            }
            else
            {
                E5.Enabled = true;
            }
            if (listBox1.Items.Contains("E6"))
            {
                E6.Enabled = false;
            }
            else
            {
                E6.Enabled = true;
            }
            if (listBox1.Items.Contains("E7"))
            {
                E7.Enabled = false;
            }
            else
            {
                E7.Enabled = true;
            }
            if (listBox1.Items.Contains("E8"))
            {
                E8.Enabled = false;
            }
            else
            {
                E8.Enabled = true;
            }
            if (listBox1.Items.Contains("F1"))
            {
                F1.Enabled = false;
            }
            else
            {
                F1.Enabled = true;
            }
            if (listBox1.Items.Contains("F2"))
            {
                F2.Enabled = false;
            }
            else
            {
                F2.Enabled = true;
            }
            if (listBox1.Items.Contains("F3"))
            {
                F3.Enabled = false;
            }
            else
            {
                F3.Enabled = true;
            }
            if (listBox1.Items.Contains("F4"))
            {
                F4.Enabled = false;
            }
            else
            {
                F4.Enabled = true;
            }
            if (listBox1.Items.Contains("G1"))
            {
                G1.Enabled = false;
            }
            else
            {
                G1.Enabled = true;
            }
            if (listBox1.Items.Contains("G2"))
            {
                G2.Enabled = false;
            }
            else
            {
                G2.Enabled = true;
            }
            if (listBox1.Items.Contains("G3"))
            {
                G3.Enabled = false;
            }
            else
            {
                G3.Enabled = true;
            }
            if (listBox1.Items.Contains("G4"))
            {
                G4.Enabled = false;
            }
            else
            {
                G4.Enabled = true;
            }
            if (listBox1.Items.Contains("G5"))
            {
                G5.Enabled = false;
            }
            else
            {
                G5.Enabled = true;
            }
            if (listBox1.Items.Contains("G6"))
            {
                G6.Enabled = false;
            }
            else
            {
                G6.Enabled = true;
            }
            if (listBox1.Items.Contains("G7"))
            {
                G7.Enabled = false;
            }
            else
            {
                G7.Enabled = true;
            }
            if (listBox1.Items.Contains("G8"))
            {
                G8.Enabled = false;
            }
            else
            {
                G8.Enabled = true;
            }
            if (listBox1.Items.Contains("G9"))
            {
                G9.Enabled = false;
            }
            else
            {
                G9.Enabled = true;
            }
            if (listBox1.Items.Contains("G10"))
            {
                G10.Enabled = false;
            }
            else
            {
                G10.Enabled = true;
            }
            if (listBox1.Items.Contains("G11"))
            {
                G11.Enabled = false;
            }
            else
            {
                G11.Enabled = true;
            }
            if (listBox1.Items.Contains("G12"))
            {
                G12.Enabled = false;
            }
            else
            {
                G12.Enabled = true;
            }
            if (listBox1.Items.Contains("G13"))
            {
                G13.Enabled = false;
            }
            else
            {
                G13.Enabled = true;
            }
            if (listBox1.Items.Contains("G14"))
            {
                G14.Enabled = false;
            }
            else
            {
                G14.Enabled = true;
            }
            if (listBox1.Items.Contains("G15"))
            {
                G15.Enabled = false;
            }
            else
            {
                G15.Enabled = true;
            }
            if (listBox1.Items.Contains("G16"))
            {
                G16.Enabled = false;
            }
            else
            {
                G16.Enabled = true;
            }
            reserva.Stop();
        }

        private void cmbHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            //hora.Start();
            reserva.Start();
            reset.Start();
        }

        private void cmbFuncion_Click(object sender, EventArgs e)
        {
            cmbFuncion.Items.Clear();
            SqlCommand comander = new SqlCommand("SELECT nombreFu from funcion", conn);
            using (SqlDataReader read = comander.ExecuteReader())
            {
                while (read.Read())
                {
                    if (!cmbFuncion.Items.Contains(read["nombreFu"].ToString()))
                        cmbFuncion.Items.Add(read["nombreFu"].ToString());
                }
                hora.Start();
            }
            reset.Start();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lslButaca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void A6_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFuncion.SelectedItem == null && cmbHora.SelectedItem == null) { }
            else
            {
                string[] but = { "A6", "4.00" };
                lista = new ListViewItem(but);
                if (A6.Checked == true)
                {
                    A6.Image = Rojo;
                    lslButaca.Items.Add(lista);
                }
                if (A6.Checked == false)
                {
                    A6.Image = Negro;
                    lslButaca.Items.Remove(lslButaca.FindItemWithText("A6"));
                }
                suma();
            }
        }
        private void A7_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFuncion.SelectedItem == null && cmbHora.SelectedItem == null) { }
            else
            {
                string[] but = { "A7", "4.00" };
                lista = new ListViewItem(but);
                if (A7.Checked == true)
                {
                    A7.Image = Rojo;
                    lslButaca.Items.Add(lista);
                }
                if (A7.Checked == false)
                {
                    A7.Image = Negro;
                    lslButaca.Items.Remove(lslButaca.FindItemWithText("A7"));
                }
                suma();
            }
        }
        private void A8_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFuncion.SelectedItem == null && cmbHora.SelectedItem == null) { }
            else
            {
                string[] but = { "A8", "4.00" };
                lista = new ListViewItem(but);
                if (A8.Checked == true)
                {
                    A8.Image = Rojo;

                    lslButaca.Items.Add(lista);
                }
                if (A8.Checked == false)
                {
                    A8.Image = Negro;
                    lslButaca.Items.Remove(lslButaca.FindItemWithText("A8"));

                }
                suma();
            }
        }
        private void A9_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFuncion.SelectedItem == null && cmbHora.SelectedItem == null) { }
            else
            {
                string[] but = { "A9", "4.00" };
                lista = new ListViewItem(but);
                if (A9.Checked == true)
                {
                    A9.Image = Rojo;
                    lslButaca.Items.Add(lista);
                }
                if (A9.Checked == false)
                {
                    A9.Image = Negro;
                    lslButaca.Items.Remove(lslButaca.FindItemWithText("A9"));
                }
                suma();
            }
        }
        private void A10_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbFuncion.SelectedItem == null && cmbHora.SelectedItem == null) { }
            else
            {
                string[] but = { "A10", "4.00" };
                lista = new ListViewItem(but);
                if (A10.Checked == true)
                {
                    A10.Image = Rojo;
                    lslButaca.Items.Add(lista);
                }
                if (A10.Checked == false)
                {
                    A10.Image = Negro;
                    lslButaca.Items.Remove(lslButaca.FindItemWithText("A10"));
                }
                suma();
            }
        }
        private void B1_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "B1", "4.00" };
            lista = new ListViewItem(but);
            if (B1.Checked == true)
            {
                B1.Image = Rojo;
                lslButaca.Items.Add(lista);
            }
            if (B1.Checked == false)
            {
                B1.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("B1"));
            }
            suma();
        }

        private void B2_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "B2", "4.00" };
            lista = new ListViewItem(but);
            if (B2.Checked == true)
            {
                B2.Image = Rojo;
                lslButaca.Items.Add(lista);
            }
            if (B2.Checked == false)
            {
                B2.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("B2"));
            }
            suma();
        }

        private void B3_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "B3", "4.00" };
            lista = new ListViewItem(but);
            if (B3.Checked == true)
            {
                B3.Image = Rojo;
                lslButaca.Items.Add(lista);
            }
            if (B3.Checked == false)
            {
                B3.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("B3"));
            }
            suma();
        }

        private void B4_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "B4", "4.00" };
            lista = new ListViewItem(but);
            if (B4.Checked == true)
            {
                B4.Image = Rojo;
                lslButaca.Items.Add(lista);
            }
            if (B4.Checked == false)
            {
                B4.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("B4"));
            }
            suma();
        }

        private void B5_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "B5", "4.00" };
            lista = new ListViewItem(but);
            if (B5.Checked == true)
            {
                B5.Image = Rojo;
                lslButaca.Items.Add(lista);
            }
            if (B5.Checked == false)
            {
                B5.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("B5"));

            }
            suma();
        }

        private void B6_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "B6", "4.00" };
            lista = new ListViewItem(but);
            if (B6.Checked == true)
            {
                B6.Image = Rojo;
                lslButaca.Items.Add(lista);
            }
            if (B6.Checked == false)
            {
                B6.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("B6"));
            }
            suma();
        }

        private void B7_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "B7", "4.00" };
            lista = new ListViewItem(but);
            if (B7.Checked == true)
            {
                B7.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (B7.Checked == false)
            {
                B7.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("B7"));

            }
            suma();
        }

        private void B8_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "B8", "4.00" };
            lista = new ListViewItem(but);
            if (B8.Checked == true)
            {
                B8.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (B8.Checked == false)
            {
                B8.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("B8"));
            }
            suma();
        }

        private void B9_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "B9", "4.00" };
            lista = new ListViewItem(but);
            if (B9.Checked == true)
            {
                B9.Image = Rojo;
                lslButaca.Items.Add(lista);
            }
            if (B9.Checked == false)
            {
                B9.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("B9"));
            }
            suma();
        }

        private void B10_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "B10", "4.00" };
            lista = new ListViewItem(but);
            if (B10.Checked == true)
            {
                B10.Image = Rojo;

                lslButaca.Items.Add(lista);
                suma();
            }
            if (B10.Checked == false)
            {
                B10.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("B10"));

                foreach (ListViewItem item in lslButaca.Items)
                {
                    cant -= double.Parse(item.SubItems[1].Text);
                }
                lslButaca.Items.Remove(lslButaca.FindItemWithText("B10"));

            }
            suma();
        }

        private void C1_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "C1", "4.00" };
            lista = new ListViewItem(but);
            if (C1.Checked == true)
            {
                C1.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (C1.Checked == false)
            {
                C1.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("C1"));

            }

            suma();
        }

        private void C2_CheckedChanged(object sender, EventArgs e)
        {

            string[] but = { "C2", "4.00" };
            lista = new ListViewItem(but);
            if (C2.Checked == true)
            {
                C2.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (C2.Checked == false)
            {
                C2.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("C2"));

            }
            suma();
        }

        private void C3_CheckedChanged(object sender, EventArgs e)
        {

            string[] but = { "C3", "4.00" };
            lista = new ListViewItem(but);
            if (C3.Checked == true)
            {
                C3.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (C3.Checked == false)
            {
                C3.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("C3"));

            }
            suma();
        }

        private void C4_CheckedChanged(object sender, EventArgs e)
        {

            string[] but = { "C4", "4.00" };
            lista = new ListViewItem(but);
            if (C4.Checked == true)
            {
                C4.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (C4.Checked == false)
            {
                C4.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("C4"));

            }
            suma();
        }

        private void C5_CheckedChanged(object sender, EventArgs e)
        {

            string[] but = { "C5", "4.00" };
            lista = new ListViewItem(but);
            if (C5.Checked == true)
            {
                C5.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (C5.Checked == false)
            {
                C5.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("C5"));

            }
            suma();
        }

        private void C6_CheckedChanged(object sender, EventArgs e)
        {

            string[] but = { "C6", "4.00" };
            lista = new ListViewItem(but);
            if (C6.Checked == true)
            {
                C6.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (C6.Checked == false)
            {
                C6.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("C6"));

            }
            suma();
        }

        private void C7_CheckedChanged(object sender, EventArgs e)
        {

            string[] but = { "C7", "4.00" };
            lista = new ListViewItem(but);
            if (C7.Checked == true)
            {
                C7.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (C7.Checked == false)
            {
                C7.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("C7"));

            }
            suma();
        }

        private void C8_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "C8", "4.00" };
            lista = new ListViewItem(but);
            if (C8.Checked == true)
            {
                C8.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (C8.Checked == false)
            {
                C8.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("C8"));

            }
            suma();
        }

        private void C9_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "C9", "4.00" };
            lista = new ListViewItem(but);
            if (C9.Checked == true)
            {
                C9.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (C9.Checked == false)
            {
                C9.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("C9"));

            }
            suma();
        }

        private void C11_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "C10", "4.00" };
            lista = new ListViewItem(but);
            if (C10.Checked == true)
            {
                C10.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (C10.Checked == false)
            {
                C10.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("C10"));

            }
            suma();
        }

        private void D1_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "D1", "4.00" };
            lista = new ListViewItem(but);
            if (D1.Checked == true)
            {
                D1.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (D1.Checked == false)
            {
                D1.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("D1"));

            }
            suma();
        }

        private void D2_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "D2", "4.00" };
            lista = new ListViewItem(but);
            if (D2.Checked == true)
            {
                D2.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (D2.Checked == false)
            {
                D2.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("D2"));

            }
            suma();
        }

        private void D3_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "D3", "4.00" };
            lista = new ListViewItem(but);
            if (D3.Checked == true)
            {
                D3.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (D3.Checked == false)
            {
                D3.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("D3"));

            }
            suma();
        }

        private void D4_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "D4", "4.00" };
            lista = new ListViewItem(but);
            if (D4.Checked == true)
            {
                D4.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (D4.Checked == false)
            {
                D4.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("D4"));

            }
            suma();

        }

        private void D5_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "D5", "4.00" };
            lista = new ListViewItem(but);
            if (D5.Checked == true)
            {
                D5.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (D5.Checked == false)
            {
                D5.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("D5"));

            }
            suma();
        }

        private void D6_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "D6", "4.00" };
            lista = new ListViewItem(but);
            if (D6.Checked == true)
            {
                D6.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (D6.Checked == false)
            {
                D6.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("D6"));

            }
            suma();
        }

        private void D7_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "D7", "4.00" };
            lista = new ListViewItem(but);
            if (D7.Checked == true)
            {
                D7.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (D7.Checked == false)
            {
                D7.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("D7"));

            }
            suma();
        }

        private void D8_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "D8", "4.00" };
            lista = new ListViewItem(but);
            if (D8.Checked == true)
            {
                D8.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (D8.Checked == false)
            {
                D8.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("D8"));

            }
            suma();
        }

        private void E1_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "E1", "4.00" };
            lista = new ListViewItem(but);
            if (E1.Checked == true)
            {
                E1.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (E1.Checked == false)
            {
                E1.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("E1"));

            }
            suma();
        }

        private void E2_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "E2", "4.00" };
            lista = new ListViewItem(but);
            if (E2.Checked == true)
            {
                E2.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (E2.Checked == false)
            {
                E2.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("E2"));

            }
            suma();
        }

        private void E3_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "E3", "4.00" };
            lista = new ListViewItem(but);
            if (E3.Checked == true)
            {
                E3.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (E3.Checked == false)
            {
                E3.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("E3"));

            }
            suma();
        }

        private void checkBox40_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "E4", "4.00" };
            lista = new ListViewItem(but);
            if (E4.Checked == true)
            {
                E4.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (E4.Checked == false)
            {
                E4.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("E4"));

            }
            suma();
        }

        private void E5_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "E5", "4.00" };
            lista = new ListViewItem(but);
            if (E5.Checked == true)
            {
                E5.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (E5.Checked == false)
            {
                E5.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("E5"));

            }
            suma();
        }

        private void E6_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "E6", "4.00" };
            lista = new ListViewItem(but);
            if (E6.Checked == true)
            {
                E6.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (E6.Checked == false)
            {
                E6.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("E6"));

            }
            suma();
        }

        private void E7_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "E7", "4.00" };
            lista = new ListViewItem(but);
            if (E7.Checked == true)
            {
                E7.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (E7.Checked == false)
            {
                E7.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("E7"));

            }
            suma();
        }

        private void E8_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "E8", "4.00" };
            lista = new ListViewItem(but);
            if (E8.Checked == true)
            {
                E8.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (E8.Checked == false)
            {
                E8.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("E8"));

            }
            suma();
        }

        private void F1_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "F1", "4.00" };
            lista = new ListViewItem(but);
            if (F1.Checked == true)
            {
                F1.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (F1.Checked == false)
            {
                F1.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("F1"));

            }
            suma();
        }

        private void F2_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "F2", "4.00" };
            lista = new ListViewItem(but);
            if (F2.Checked == true)
            {
                F2.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (F2.Checked == false)
            {
                F2.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("F2"));

            }
            suma();
        }

        private void F3_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "F3", "4.00" };
            lista = new ListViewItem(but);
            if (F3.Checked == true)
            {
                F3.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (F3.Checked == false)
            {
                F3.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("F3"));

            }
            suma();
        }

        private void checkBox47_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "F4", "4.00" };
            lista = new ListViewItem(but);
            if (F4.Checked == true)
            {
                F4.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (F4.Checked == false)
            {
                F4.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("F4"));

            }
            suma();
        }

        private void G1_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G1", "4.00" };
            lista = new ListViewItem(but);
            if (G1.Checked == true)
            {
                G1.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G1.Checked == false)
            {
                G1.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G1"));

            }
            suma();


        }

        private void G2_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G2", "4.00" };
            lista = new ListViewItem(but);
            if (G2.Checked == true)
            {
                G2.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G2.Checked == false)
            {
                G2.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G2"));

            }
            suma();
        }

        private void G3_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G3", "4.00" };
            lista = new ListViewItem(but);
            if (G3.Checked == true)
            {
                G3.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G3.Checked == false)
            {
                G3.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G3"));

            }
            suma();
        }

        private void checkBox51_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G4", "4.00" };
            lista = new ListViewItem(but);
            if (G4.Checked == true)
            {
                G4.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G4.Checked == false)
            {
                G4.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G4"));

            }
            suma();
        }

        private void G5_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G5", "4.00" };
            lista = new ListViewItem(but);
            if (G5.Checked == true)
            {
                G5.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G5.Checked == false)
            {
                G5.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G5"));

            }
            suma();
        }

        private void G6_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G6", "4.00" };
            lista = new ListViewItem(but);
            if (G6.Checked == true)
            {
                G6.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G6.Checked == false)
            {
                G6.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G6"));

            }
            suma();
        }

        private void G7_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G7", "4.00" };
            lista = new ListViewItem(but);
            if (G7.Checked == true)
            {
                G7.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G7.Checked == false)
            {
                G7.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G7"));

            }
            suma();
        }

        private void G8_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G8", "4.00" };
            lista = new ListViewItem(but);
            if (G8.Checked == true)
            {
                G8.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G8.Checked == false)
            {
                G8.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G8"));

            }
            suma();
        }

        private void G9_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G9", "4.00" };
            lista = new ListViewItem(but);
            if (G9.Checked == true)
            {
                G9.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G9.Checked == false)
            {
                G9.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G9"));

            }
            suma();
        }

        private void G10_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G10", "4.00" };
            lista = new ListViewItem(but);
            if (G10.Checked == true)
            {
                G10.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G10.Checked == false)
            {
                G10.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G10"));
            }
            suma();
        }

        private void G11_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G11", "4.00" };
            lista = new ListViewItem(but);
            if (G11.Checked == true)
            {
                G11.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G11.Checked == false)
            {
                G11.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G11"));

            }
            suma();
        }

        private void G12_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G12", "4.00" };
            lista = new ListViewItem(but);
            if (G12.Checked == true)
            {
                G12.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G12.Checked == false)
            {
                G12.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G12"));

            }
            suma();
        }

        private void G13_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G13", "4.00" };
            lista = new ListViewItem(but);
            if (G13.Checked == true)
            {
                G13.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G13.Checked == false)
            {
                G13.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G13"));
            }
            suma();
        }

        private void G14_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G14", "4.00" };
            lista = new ListViewItem(but);
            if (G14.Checked == true)
            {
                G14.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G14.Checked == false)
            {
                G14.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G14"));
            }
            suma();
        }

        private void checkBox62_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G15", "4.00" };
            lista = new ListViewItem(but);
            if (G15.Checked == true)
            {
                G15.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G15.Checked == false)
            {
                G15.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G15"));
            }
            suma();
        }

        private void G16_CheckedChanged(object sender, EventArgs e)
        {
            string[] but = { "G16", "4.00" };
            lista = new ListViewItem(but);
            if (G16.Checked == true)
            {
                G16.Image = Rojo;

                lslButaca.Items.Add(lista);
            }
            if (G16.Checked == false)
            {
                G16.Image = Negro;
                lslButaca.Items.Remove(lslButaca.FindItemWithText("G16"));

            }
            suma();
        }

        private void reset_Tick(object sender, EventArgs e)
        {
              if ((A1.Enabled == false && A1.Checked == true) || (A1.Enabled == true && A1.Checked == true))
                A1.Checked = false;
            if ((A2.Enabled == false && A2.Checked == true) || (A2.Enabled == true && A2.Checked == true))
                A2.Checked = false;
            if ((A3.Enabled == false && A3.Checked == true) || (A3.Enabled == true && A3.Checked == true))
                A3.Checked = false;
            if ((A4.Enabled == false && A4.Checked == true) || (A4.Enabled == true && A4.Checked == true))
                A4.Checked = false;
            if ((A5.Enabled == false && A5.Checked == true) || (A5.Enabled == true && A5.Checked == true))
                A5.Checked = false;
            if ((A6.Enabled == false && A6.Checked == true) || (A6.Enabled == true && A6.Checked == true))
                A6.Checked = false;
            if ((A7.Enabled == false && A7.Checked == true) || (A7.Enabled == true && A7.Checked == true))
                A7.Checked = false;
            if ((A8.Enabled == false && A8.Checked == true) || (A8.Enabled == true && A8.Checked == true))
                A8.Checked = false;
            if ((A9.Enabled == false && A9.Checked == true) || (A9.Enabled == true && A9.Checked == true))
                A9.Checked = false;
            if ((A10.Enabled == false && A10.Checked == true) || (A10.Enabled == true && A10.Checked == true))
                A10.Checked = false;
            if ((B10.Enabled == false && B10.Checked == true) || (B10.Enabled == true && B10.Checked == true))
                B10.Checked = false;
            if ((B1.Enabled == false && B1.Checked == true) || (B1.Enabled == true && B1.Checked == true))
                B1.Checked = false;
            if ((B2.Enabled == false && B2.Checked == true) || (B2.Enabled == true && B2.Checked == true))
                B2.Checked = false;
            if ((B3.Enabled == false && B3.Checked == true) || (B3.Enabled == true && B3.Checked == true))
                B3.Checked = false;
            if ((B4.Enabled == false && B4.Checked == true) || (B4.Enabled == true && B4.Checked == true))
                B4.Checked = false;
            if ((B5.Enabled == false && B5.Checked == true) || (B5.Enabled == true && B5.Checked == true))
                B5.Checked = false;
            if ((B6.Enabled == false && B6.Checked == true) || (B6.Enabled == true && B6.Checked == true))
                B6.Checked = false;
            if ((B7.Enabled == false && B7.Checked == true) || (B7.Enabled == true && B7.Checked == true))
                B7.Checked = false;
            if ((B8.Enabled == false && B8.Checked == true) || (B8.Enabled == true && B8.Checked == true))
                B8.Checked = false;
            if ((B9.Enabled == false && B9.Checked == true) || (B9.Enabled == true && B9.Checked == true))
                B9.Checked = false;
            if ((B10.Enabled == false && B10.Checked == true) || (B10.Enabled == true && B10.Checked == true))
                B10.Checked = false;
            if ((C1.Enabled == false && C1.Checked == true) || (C1.Enabled == true && C1.Checked == true))
                C1.Checked = false;
            if ((C1.Enabled == false && C1.Checked == true) || (C1.Enabled == true && C1.Checked == true))
                C1.Checked = false;
            if ((C2.Enabled == false && C2.Checked == true) || (C2.Enabled == true && C2.Checked == true))
                C2.Checked = false;
            if ((C3.Enabled == false && C3.Checked == true) || (C3.Enabled == true && C3.Checked == true))
                C3.Checked = false;
            if ((C4.Enabled == false && C4.Checked == true) || (C4.Enabled == true && C4.Checked == true))
                C4.Checked = false;
            if ((C5.Enabled == false && C5.Checked == true) || (C5.Enabled == true && C5.Checked == true))
                C5.Checked = false;
            if ((C6.Enabled == false && C6.Checked == true) || (C6.Enabled == true && C6.Checked == true))
                C6.Checked = false;
            if ((C7.Enabled == false && C7.Checked == true) || (C7.Enabled == true && C7.Checked == true))
                C7.Checked = false;
            if ((C8.Enabled == false && C8.Checked == true) || (C8.Enabled == true && C8.Checked == true))
                C8.Checked = false;
            if ((C9.Enabled == false && C9.Checked == true) || (C9.Enabled == true && C9.Checked == true))
                C9.Checked = false;
            if ((C10.Enabled == false && C10.Checked == true) || (C10.Enabled == true && C10.Checked == true))
                C10.Checked = false;
            if ((D1.Enabled == false && D1.Checked == true) || (D1.Enabled == true && D1.Checked == true))
                D1.Checked = false;
            if ((D2.Enabled == false && D2.Checked == true) || (D2.Enabled == true && D2.Checked == true))
                D2.Checked = false;
            if ((D3.Enabled == false && D3.Checked == true) || (D3.Enabled == true && D3.Checked == true))
                D3.Checked = false;
            if ((D4.Enabled == false && D4.Checked == true) || (D4.Enabled == true && D4.Checked == true))
                D4.Checked = false;
            if ((D5.Enabled == false && D5.Checked == true) || (D5.Enabled == true && D5.Checked == true))
                D5.Checked = false;
            if ((D6.Enabled == false && D6.Checked == true) || (D6.Enabled == true && D6.Checked == true))
                D6.Checked = false;
            if ((D7.Enabled == false && D7.Checked == true) || (D7.Enabled == true && D7.Checked == true))
                D7.Checked = false;
            if ((D8.Enabled == false && D8.Checked == true) || (D8.Enabled == true && D8.Checked == true))
                D8.Checked = false;
            if ((E1.Enabled == false && E1.Checked == true) || (E1.Enabled == true && E1.Checked == true))
                E1.Checked = false;
            if ((E2.Enabled == false && E2.Checked == true) || (E2.Enabled == true && E2.Checked == true))
                E2.Checked = false;
            if ((E3.Enabled == false && E3.Checked == true) || (E3.Enabled == true && E3.Checked == true))
                E3.Checked = false;
            if ((E4.Enabled == false && E4.Checked == true) || (E4.Enabled == true && E4.Checked == true))
                E4.Checked = false;
            if ((E5.Enabled == false && E5.Checked == true) || (E5.Enabled == true && E5.Checked == true))
                E5.Checked = false;
            if ((E6.Enabled == false && E6.Checked == true) || (E6.Enabled == true && E6.Checked == true))
                E6.Checked = false;
            if ((E7.Enabled == false && E7.Checked == true) || (E7.Enabled == true && E7.Checked == true))
                E7.Checked = false;
            if ((E8.Enabled == false && E8.Checked == true) || (E8.Enabled == true && E8.Checked == true))
                E8.Checked = false;
            if ((F1.Enabled == false && F1.Checked == true) || (F1.Enabled == true && F1.Checked == true))
                F1.Checked = false;
            if ((F2.Enabled == false && F2.Checked == true) || (F2.Enabled == true && F2.Checked == true))
                F2.Checked = false;
            if ((F3.Enabled == false && F3.Checked == true) || (F3.Enabled == true && F3.Checked == true))
                F3.Checked = false;
            if ((F4.Enabled == false && F4.Checked == true) || (F4.Enabled == true && F4.Checked == true))
                F4.Checked = false;
            if ((G1.Enabled == false && G1.Checked == true) || (G1.Enabled == true && G1.Checked == true))
                G1.Checked = false;
            if ((G2.Enabled == false && G2.Checked == true) || (G2.Enabled == true && G2.Checked == true))
                G2.Checked = false;
            if ((G3.Enabled == false && G3.Checked == true) || (G3.Enabled == true && G3.Checked == true))
                G3.Checked = false;
            if ((G4.Enabled == false && G4.Checked == true) || (G4.Enabled == true && G4.Checked == true))
                G4.Checked = false;
            if ((G5.Enabled == false && G5.Checked == true) || (G5.Enabled == true && G5.Checked == true))
                G5.Checked = false;
            if ((G6.Enabled == false && G6.Checked == true) || (G6.Enabled == true && G6.Checked == true))
                G6.Checked = false;
            if ((G7.Enabled == false && G7.Checked == true) || (G7.Enabled == true && G7.Checked == true))
                G7.Checked = false;
            if ((G8.Enabled == false && G8.Checked == true) || (G8.Enabled == true && G8.Checked == true))
                G8.Checked = false;
            if ((G9.Enabled == false && G9.Checked == true) || (G9.Enabled == true && G9.Checked == true))
                G9.Checked = false;
            if ((G10.Enabled == false && G10.Checked == true) || (G10.Enabled == true && G10.Checked == true))
                G10.Checked = false;
            if ((G11.Enabled == false && G11.Checked == true) || (G11.Enabled == true && G11.Checked == true))
                G11.Checked = false;
            if ((G12.Enabled == false && G12.Checked == true) || (G12.Enabled == true && G12.Checked == true))
                G12.Checked = false;
            if ((G13.Enabled == false && G13.Checked == true) || (G13.Enabled == true && G13.Checked == true))
                G13.Checked = false;
            if ((G14.Enabled == false && G14.Checked == true) || (G14.Enabled == true && G14.Checked == true))
                G14.Checked = false;
            if ((G15.Enabled == false && G15.Checked == true) || (G15.Enabled == true && G15.Checked == true))
                G15.Checked = false;
            if ((G16.Enabled == false && G16.Checked == true) || (G16.Enabled == true && G16.Checked == true))
                G16.Checked = false;
            reset.Stop();
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult mensaje = MessageBox.Show("Esta seguro que desea cerrar sesion","Cerrar Sesion",MessageBoxButtons.YesNoCancel);
            if (mensaje == DialogResult.Yes)
            {
                login log = new login();
                log.Show();
                this.Hide();
            }
            else if (mensaje == DialogResult.No) 
            { 
                
            }
            else if (mensaje == DialogResult.Cancel)
            {

            }
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarF_Click(object sender, EventArgs e)
        {
            if ((cmbFuncion.SelectedItem == null || cmbHora.SelectedItem == null))
            {
            }
            else
            {
                string s = cmbHora.SelectedItem.ToString();
                DateTime fech = Convert.ToDateTime(s);
                string insertar1 = "DELETE butaca FROM butaca INNER JOIN funcion ON butaca.fecha = funcion.fecha WHERE funcion.fecha = '" + fech.ToString("yyyy/MM/dd HH:mm:00 ") + "'";
                string insertar2 = "delete  from funcion where fecha = '" + fech.ToString("yyyy/MM/dd HH:mm:00") + "'";
                SqlCommand comander = new SqlCommand(insertar1, conn);
                SqlCommand comander2 = new SqlCommand(insertar2, conn);
                comander.ExecuteNonQuery();
                comander2.ExecuteNonQuery();
            }
            hora.Start();
            cmbFuncion.SelectedItem = null;
        }
    }
}
