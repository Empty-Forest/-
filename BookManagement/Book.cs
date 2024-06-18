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
using System.IO;

namespace BookManagement
{
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
            Populate();
        }
        private static string appPath = AppDomain.CurrentDomain.BaseDirectory;//当前执行文件的目录
        private static string fileName = "BookStore.mdf";//目录下的数据库文件
        private static string filePath = Path.Combine(appPath, fileName);//数据库路径
        SqlConnection con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={filePath};Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void Populate()
        {
            con.Open();//打开数据库
            string query = "select * from BookTb1";//查询数据表中的全部信息
            SqlDataAdapter sda = new SqlDataAdapter(query , con);//创建数据的批量抓取
            SqlCommandBuilder sqb = new SqlCommandBuilder(sda);//与上述sda的函数配合使用以批量处理数据库数据
            var ds = new DataSet();//创建一个虚拟数据库
            sda.Fill(ds);//将查询到的数据存储到虚拟表中
            bookList.DataSource =ds.Tables[0];//将数据显示在创建好的数据网格中
            con.Close();//关闭数据库
        }
        private void button1_Click(object sender, EventArgs e)//保存
        {
            if (bookName.Text =="" || bookAuthor.Text =="" || bookPrice.Text == "" || bookPrice.Text == "" || bookCat.SelectedIndex == -1)
            {
                MessageBox.Show("书籍信息保存错误，请填写完整!");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "insert into BookTb1 values('"+bookName.Text+"','"+bookAuthor.Text+"','"+bookCat.SelectedItem.ToString()+ "','"+bookPrice.Text+ "','"+bookAmount.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, con);//向数据库发送增删查改的命令
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("书籍信息保存成功！");
                    con.Close();
                    Populate();
                    Reset();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        
        private void Filter()//筛选功能
        {
            con.Open();//打开数据库
            string query = "select * from BookTb1 where BCat = '"+bookFilter.SelectedItem.ToString()+"'";//查询数据表中特定数据并给与特定位置的全部信息
            SqlDataAdapter sda = new SqlDataAdapter(query, con);//创建数据的批量抓取
            SqlCommandBuilder sqb = new SqlCommandBuilder(sda);//与上述sda的函数配合使用以批量处理数据库数据
            var ds = new DataSet();//创建一个虚拟数据库
            sda.Fill(ds);//将查询到的数据存储到虚拟表中
            bookList.DataSource = ds.Tables[0];//将数据显示在创建好的数据网格中
            con.Close();//关闭数据库
        }

        private void refreshBt_Click(object sender, EventArgs e)//刷新
        {
            Populate();//用户点击更新时重新提取数据库数据
            bookFilter.SelectedIndex = -1;//刷新完后使筛选回到默认值
        }

        private void bookFilter_SelectionChangeCommitted(object sender, EventArgs e)//筛选
        {
            Filter();
        }

        private void Reset()//将所有输入设定为空
        {
            bookName.Text = "";
            bookAuthor.Text = "";
            bookCat.SelectedIndex = -1;
            bookAmount.Text = "";
            bookPrice.Text = "";
            key = 0;
        }
        private void resetBt_Click(object sender, EventArgs e)//重置
        {
            Reset();
        }
        int key = 0;//是否选定了书籍，以及选定了哪条书籍
        private void bookList_CellContentClick(object sender, DataGridViewCellEventArgs e)//选取表格中的书籍显示在上方
        {
            bookName.Text = bookList.SelectedRows[0].Cells[1].Value.ToString();
            bookAuthor.Text = bookList.SelectedRows[0].Cells[2].Value.ToString();
            bookCat.SelectedItem = bookList.SelectedRows[0].Cells[3].Value.ToString();
            bookPrice.Text = bookList.SelectedRows[0].Cells[4].Value.ToString();
            bookAmount.Text = bookList.SelectedRows[0].Cells[5].Value.ToString();
            if (bookName.Text == "")//输入为空时使其为0
            {
                key = 0;
            }
            else//否则使key=书籍的Id
            {
                key = Convert.ToInt32(bookList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void deleteBt_Click(object sender, EventArgs e)//删除按钮
        {
            if (key == 0)
            {
                MessageBox.Show("书籍删除错误，请填写完整!");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from BookTb1 where BId = "+key+"";//删除BId为key的那条数据
                    SqlCommand cmd = new SqlCommand(query, con);//向数据库发送增删查改的命令
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("书籍信息删除成功！");
                    con.Close();
                    Populate();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void editBt_Click(object sender, EventArgs e)//编辑按钮
        {
            if (bookName.Text == "" || bookAuthor.Text == "" || bookPrice.Text == "" || bookPrice.Text == "" || bookCat.SelectedIndex == -1)
            {
                MessageBox.Show("书籍信息编辑保存失败，请填写完整!");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update BookTb1 set BTiltle='"+bookName.Text+"',BAuthor='"+bookAuthor.Text+"',BCat='"+bookCat.SelectedItem.ToString()+"',BAmount='"+bookAmount.Text+"',BMoney='"+bookPrice.Text+"' where BId='"+key+"'";
                    SqlCommand cmd = new SqlCommand(query, con);//向数据库发送增删查改的命令
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("书籍信息编辑保存成功！");
                    con.Close();
                    Populate();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)//退出
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)//点击用户时进入用户界面
        {
            User obj = new User();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)//进入清单界面
        {
            List obj = new List();
            obj.Show();
            this.Hide();
        }
    }
}
