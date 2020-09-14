using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 校园卡管理系统
{
    public partial class Form30 : Form
    {
        public static string account;
        public Form30()
        {
            InitializeComponent();
        }

        private void 消费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 f = new Form31();
            f.Show();
        }

        private void 充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form32 f = new Form32();
            f.Show();
        }

        private void 挂失解挂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form33 f = new Form33();
            f.Show();
        }

        private void 查询消费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form34 f = new Form34();
            f.Show();
        }

        private void 查询充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form35 f = new Form35();
            f.Show();
        }

        private void 查询个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form36 f = new Form36();
            f.Show();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form37 f = new Form37();
            f.Show();
        }

        private void 修改个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form38 f = new Form38();
            f.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
