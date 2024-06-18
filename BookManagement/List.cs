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

namespace BookManagement
{
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\VScode\LibraryManagement\BookManagement\Data\BookStore.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        private void label5_Click(object sender, EventArgs e)//退出
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)//进入书籍界面
        {
            Book obj = new Book();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)//进入用户界面
        {
            User obj = new User();
            obj.Show();
            this.Hide();
        }

        private void List_Load(object sender, EventArgs e)
        {
            con.Open();
            //总库存量
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(BAmount) from BookTb1",con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            BookStock.Text = dt1.Rows[0][0].ToString();
            //总销售额
            SqlDataAdapter sda2 = new SqlDataAdapter("select sum(Amount) from OrderTb1", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            SellAmount.Text = dt2.Rows[0][0].ToString();
            //总用户量
            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from UserTb1", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            UsersAmount.Text = dt3.Rows[0][0].ToString();
            con.Close();
        }
    }
}
