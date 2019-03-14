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
    public partial class Agregar_Evento : Form
    {
        private SqlConnection conn;
        private SqlCommand insert;
        private string sCn;
        OleDbConnection cnn = new OleDbConnection();
        public Agregar_Evento()
        {
            InitializeComponent();
            conexion cn = new conexion();
            cn.conec();
            sCn = cn.cadena;
            conn = new SqlConnection(sCn);
            conn.Open();
            cnn.ConnectionString = @"Provider=sqloledb;Data Source=SQL5008.site4now.net,1433;Initial Catalog=DB_A464EC_cine;User Id=DB_A464EC_cine_admin;Password=hola1234;";
        }

        private void Agregar_Evento_Load(object sender, EventArgs e)
        {
            SqlCommand comander = new SqlCommand("SELECT fecha from funcion", conn);
            using (SqlDataReader read = comander.ExecuteReader())
            {
                while (read.Read())
                {
                    listBox1.Items.Add(read["fecha"].ToString());
                }
            }
        }

        private void btnAgre_Click(object sender, EventArgs e)
        {
            if (txtFuncion.Text == "" || txtDescrip.Text == "") { }
            else
            {
                string s = dateFecha.Value.Date.ToString("d/M/yyyy") + " " + dateHora.Value.ToString("hh:mm:00 tt");
                if (!listBox1.Items.Contains(s))
                {
                    string[] c = { txtFuncion.Text, dateFecha.Value.Date.ToString("yyyy/MM/dd"), dateHora.Value.Hour + ":" + dateHora.Value.Minute + ":00", txtDescrip.Text };
                    ListViewItem lista = new ListViewItem(c);
                    lstFecha.Items.Add(lista);
                }
                else
                    MessageBox.Show("Fecha ya reservada");

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lista in lstFecha.SelectedItems)
            {
                lista.Remove();
            }
        }

        private void btnAddEveneto_Click(object sender, EventArgs e)
        {
            if (lstFecha.Items.Count == 0) { this.Close(); }
            else
            {
                foreach (ListViewItem lista in lstFecha.Items)
                {
                    string insertar = "insert into funcion(fecha, nombrefu, descripcion)";
                    insertar += " values(@Fecha, @Nombrefu, @Descripcion)";
                    insert = new SqlCommand(insertar, conn);
                    insert.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.SmallDateTime));
                    insert.Parameters["@Fecha"].Value = lista.SubItems[1].Text + " " + lista.SubItems[2].Text;
                    insert.Parameters.Add(new SqlParameter("@Nombrefu", SqlDbType.VarChar));
                    insert.Parameters["@Nombrefu"].Value = lista.Text;
                    insert.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar));
                    insert.Parameters["@Descripcion"].Value = lista.SubItems[3].Text;
                    insert.ExecuteNonQuery();
                    //MessageBox.Show(lista.SubItems[1].Text + " " + lista.SubItems[2].Text);
                }
                conn.Close();
                this.Close();
            }
        }
    }
}
