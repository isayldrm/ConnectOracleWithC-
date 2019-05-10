using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace ConnectOracle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                OracleConnection conn = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=INFOR)));user id=TEST; Password=TEST; ");
                OracleCommand cmd = new OracleCommand();

                cmd.CommandText = "SELECT UCO_ENTITY, UCO_CODE FROM R5UCODES";
                cmd.Connection = conn;

                conn.Open();

                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable dbListe = new DataTable();
                adapter.Fill(dbListe);
                dataGridView1.DataSource = dbListe;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
