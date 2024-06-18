using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManagement
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        int startpos = 0;//计时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 1;//计时器每次增加1
            MyProgress.Value = startpos;//进度条的值等于计时器的值
            PercentLoad.Text = startpos + "%";//进度值
            if (MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                timer1.Stop();//计时器停止
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

    }
}
