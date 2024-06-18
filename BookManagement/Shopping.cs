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
    public partial class Shopping : Form
    {
        public Shopping()
        {
            InitializeComponent();
            Populate();
        }
        private void Shopping_Load(object sender, EventArgs e)//左上角用户名显示
        {
            userNameWatch.Text = Login.userNameId;
        }
        private void label5_Click(object sender, EventArgs e)//退出
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\VScode\LibraryManagement\BookManagement\Data\BookStore.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void Populate()
        {
            con.Open();
            string query = "select * from BookTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder scb =new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            bookList.DataSource = ds.Tables[0];
            con.Close();
        }
        
        private void UpdateBookAmount()//当加入购物车后更新库存
        {
            int bookQuatity = stock - Convert.ToInt32(bookAmount.Text);
            con.Open();
            string query = "update BookTb1 set BAmount='"+bookQuatity+"' where BId='" + key +"'";
            SqlCommand sc = new SqlCommand(query, con);
            sc.ExecuteNonQuery();
            con.Close();
            Populate();
            Reset();
        }
        int key = 0;
        private void Reset()
        {
            bookName.Text = "";
            bookAuthor.Text = "";
            bookPrice.Text = "";
            bookAmount.Text = "";
            stock = 0;
            key = 0;
            n = 0;
        }
        int stock = 0;//库存量
        private void bookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bookName.Text = bookList.SelectedRows[0].Cells[1].Value.ToString();
            bookAuthor.Text = bookList.SelectedRows[0].Cells[2].Value.ToString();
            bookPrice.Text = bookList.SelectedRows[0].Cells[4].Value.ToString();
            if (bookName.Text == "")
            {
                key = 0;
                stock = 0;
            }
            else
            {
                key = Convert.ToInt32(bookList.SelectedRows[0].Cells[0].Value.ToString());
                stock = Convert.ToInt32(bookList.SelectedRows[0].Cells[5].Value.ToString());
            }
        }
        private void Filter()//筛选功能
        {
            con.Open();//打开数据库
            string query = "select * from BookTb1 where BCat = '" + bookFilter.SelectedItem.ToString() + "'";//查询数据表中特定数据并给与特定位置的全部信息
            SqlDataAdapter sda = new SqlDataAdapter(query, con);//创建数据的批量抓取
            SqlCommandBuilder sqb = new SqlCommandBuilder(sda);//与上述sda的函数配合使用以批量处理数据库数据
            var ds = new DataSet();//创建一个虚拟数据库
            sda.Fill(ds);//将查询到的数据存储到虚拟表中
            bookList.DataSource = ds.Tables[0];//将数据显示在创建好的数据网格中
            con.Close();//关闭数据库
        }
        private void bookFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filter();
        }
        private void refreshBt_Click(object sender, EventArgs e)//刷新按钮
        {
            Populate();//用户点击更新时重新提取数据库数据
            bookFilter.SelectedIndex = -1;//刷新完后使筛选回到默认值
        }


        int shopNumber = 1;//订单号
        int total = 0;//总计金额
        private void saveBt_Click(object sender, EventArgs e)//加入购物车
        {
            if (bookAmount.Text == "" || Convert.ToInt32(bookAmount.Text)>stock)
            {
                MessageBox.Show("库存不足!");
            }
            else if (Convert.ToInt32(bookAmount.Text) <= 0)
            {
                MessageBox.Show("数量不能为零或负数！");
            }
            else
            {
                try
                {
                    int totalPurchase = Convert.ToInt32(bookAmount.Text) * Convert.ToInt32(bookPrice.Text);
                    DataGridViewRow dgvr = new DataGridViewRow();
                    dgvr.CreateCells(shopCar);
                    dgvr.Cells[0].Value = shopNumber;
                    dgvr.Cells[1].Value = bookName.Text;
                    dgvr.Cells[2].Value = bookAuthor.Text;
                    dgvr.Cells[3].Value = bookPrice.Text;
                    dgvr.Cells[4].Value = bookAmount.Text;
                    dgvr.Cells[5].Value = totalPurchase;
                    shopCar.Rows.Add(dgvr);//添加信息到表
                    shopNumber++;
                    UpdateBookAmount();
                    total = total + totalPurchase;
                    totalMoney.Text = "¥" + total;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void resetBt_Click(object sender, EventArgs e)//重置按钮
        {
            Reset();
        }


        private void deleteBt_Click(object sender, EventArgs e)//删除按钮
        {
            if (n == 0)
            {
                MessageBox.Show("删除失败!");
            }
            else
            {
                if (shopCar.Rows.Count >= 1)//判断是否购物车中有书籍
                {
                    int backMoney = Convert.ToInt32(shopCar.SelectedRows[0].Cells[5].Value.ToString());//删除后返回的金额
                    total = total - backMoney;
                    totalMoney.Text = "¥" + total;
                    shopCar.Rows.Remove(shopCar.SelectedRows[0]);//删除选定行
                    shopCar.Refresh();//刷新购物车
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select BAmount from BookTb1 where BTiltle = '" + bookName.Text + "'",con);//获得购物车中删除的书籍的库存
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    stock = (int)dt.Rows[0][0];//将库存转换为int类型
                    stock = stock + n;//删除时将书本数量加回库存
                    string query = "update BookTb1 set BAmount='" + stock + "' where BTiltle = '" + bookName.Text + "'";
                    SqlCommand sc = new SqlCommand(query, con);
                    sc.ExecuteNonQuery();
                    con.Close();
                    Reset();
                    Populate();
                }
            }
        }
        int n = 0;
        private void shopCar_CellContentClick(object sender, DataGridViewCellEventArgs e)//购物车数据选取
        {
            bookName.Text = shopCar.SelectedRows[0].Cells[1].Value.ToString();
            bookAuthor.Text = shopCar.SelectedRows[0].Cells[2].Value.ToString();
            bookPrice.Text = shopCar.SelectedRows[0].Cells[3].Value.ToString();
            bookAmount.Text = shopCar.SelectedRows[0].Cells[4].Value.ToString();
            if (bookAmount.Text != shopCar.SelectedRows[0].Cells[4].Value.ToString())
            {
                n = 0;
            }
            else
            {
                n = Convert.ToInt32(shopCar.SelectedRows[0].Cells[4].Value.ToString());//选中的购物车书籍的数量
            }
        }

        private void purchase_Click(object sender, EventArgs e)//计算打印小票
        {
            
            if (shopCar.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("您还没有选择书籍");
            }
            else
            {
                printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprum", 285, 600);
                if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
                try
                {
                    con.Open();
                    string query = "insert into OrderTb1 values('" + userNameWatch.Text + "','" + total + "')";
                    SqlCommand cmd = new SqlCommand(query, con);//向数据库发送增删查改的命令
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("订单信息保存成功！");
                    con.Close();
                    total = 0;
                    totalMoney.Text = "总计金额";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        int prOdId, prOdAmount, prOdPrice, prOdTotal, pos = 60;
        string prOdName;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("小白书店", new Font("幼圆", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("编号   书名   单价   数量   总计", new Font("幼圆", 10, FontStyle.Bold), Brushes.Red, new Point(26,40));
            foreach(DataGridViewRow row in shopCar.Rows)
            {
                prOdId = Convert.ToInt32(row.Cells["OrderId"].Value);
                prOdName = "" + row.Cells["OrderName"].Value;
                prOdPrice = Convert.ToInt32(row.Cells["OrderPrice"].Value);
                prOdAmount = Convert.ToInt32(row.Cells["OrderAmount"].Value);
                prOdTotal = Convert.ToInt32(row.Cells["OrderTotal"].Value);
                e.Graphics.DrawString("" + prOdId, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + prOdName, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prOdPrice, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + prOdAmount, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + prOdTotal, new Font("幼圆", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("订单总额：¥" + total, new Font("幼圆", 12, FontStyle.Bold), Brushes.Red, new Point(60, pos + 50));
            e.Graphics.DrawString("************小白书店************", new Font("幼圆", 12, FontStyle.Bold), Brushes.Red, new Point(40, pos + 85));
            //小票打印出来后，清空购物车内容
            shopCar.Rows.Clear();
            shopCar.Refresh();
            pos = 100;
        }
    }
}
