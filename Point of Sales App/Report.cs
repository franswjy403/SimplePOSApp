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

namespace SimpleSupermarketApp
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\Documents\smarket.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            string query, quer;
            if (SelectCategory.SelectedItem.ToString().Equals("Seller Name"))
            {
                query = "SELECT SellerName, SUM(Amount) AS 'Total Income' FROM Bill GROUP BY SellerName";
            }
            else
            {
                query = "SELECT BillDate, SUM(Amount) AS 'TOTAL INCOME' FROM Bill GROUP BY BillDate";
            }
            Con.Open();
            quer = "SELECT SUM(Amount) AS Total FROM Bill";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CatDGV.DataSource = ds.Tables[0];
            sda = new SqlDataAdapter(quer, Con);
            builder = new SqlCommandBuilder(sda);
            ds = new DataSet();
            sda.Fill(ds);
            TotalGDV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product prod = new Product();
            prod.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            cat.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Seller sell = new Seller();
            sell.Show();
            this.Hide();
        }

        private void CatDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main log = new Main();
            log.Show();
            this.Hide();
        }

        private void SelectCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
