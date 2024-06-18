using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void signIn_Click(object sender, EventArgs e)//登录按钮
        {
            if(aPasswordInput.Text == "password")
            {
                List obj = new List();
                obj.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误！");
            }
        }

        private void backU_Click(object sender, EventArgs e)//返回用户登录
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void exitBt_Click(object sender, EventArgs e)//退出
        {
            Application.Exit();
        }
    }
}
