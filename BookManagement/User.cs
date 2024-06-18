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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            Population();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\VScode\LibraryManagement\BookManagement\Data\BookStore.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void Population()
        {
            con.Open();
            string query = "select * from UserTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder sqb = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            userList.DataSource = ds.Tables[0];
            con.Close();
        }
        int key = 0;
        private void Reset()
        {
            userName.Text = "";
            userTName.Text = "";
            userSex.SelectedIndex = -1;
            userPhone.Text = "";
            userPassword.Text = "";
            key = 0;
        }
        private void saveBt_Click(object sender, EventArgs e)//保存按钮
        {
            if (userName.Text == "" || userTName.Text == "" || userSex.SelectedIndex == -1 || userPhone.Text == "" || userPassword.Text == "")
            {
                MessageBox.Show("用户信息保存失败，请填写完整！");
            }
            else
            {
                try
                {
                    con.Open() ;
                    string query = "insert into UserTb1 values('"+userName.Text+"','"+userPhone.Text+"','"+userSex.SelectedItem.ToString()+ "','"+userPassword.Text+ "','"+userTName.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("用户信息保存成功！");
                    con.Close();
                    Population();
                    Reset();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void freshBt_Click(object sender, EventArgs e)//重置按钮
        {
            Reset();
        }

        private void editBt_Click(object sender, EventArgs e)//编辑按钮
        {
            if (userName.Text == "" || userTName.Text == "" || userSex.SelectedIndex == -1 || userPhone.Text == "" || userPassword.Text == "")
            {
                MessageBox.Show("用户信息编辑保存失败，请填写完整！");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "update UserTb1 set UName='" + userName.Text + "',UPhone='" + userPhone.Text + "',Usex='" + userSex.SelectedItem.ToString() + "',Upassword='" + userPassword.Text + "',UTName='" + userTName.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("用户信息编辑保存成功！");
                    con.Close();
                    Population();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void userList_CellContentClick(object sender, DataGridViewCellEventArgs e)//表格内容选取
        {
            userName.Text = userList.SelectedRows[0].Cells[1].Value.ToString();
            userTName.Text = userList.SelectedRows[0].Cells[5].Value.ToString();
            userSex.SelectedItem = userList.SelectedRows[0].Cells[3].Value.ToString();
            userPhone.Text = userList.SelectedRows[0].Cells[2].Value.ToString();
            userPassword.Text = userList.SelectedRows[0].Cells[4].Value.ToString();
            if(userName.Text=="")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(userList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void deleteBt_Click(object sender, EventArgs e)//删除按钮
        {
            if(key == 0)
            {
                MessageBox.Show("用户信息不完整，删除错误！");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from UserTb1 where UId ="+key+" ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("用户信息删除成功！");
                    con.Close();
                    Population();
                    Reset();
                }
                catch(Exception ex)
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

        private void label1_Click(object sender, EventArgs e)//进入书籍界面
        {
            Book obj = new Book();
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
