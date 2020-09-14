using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 校园卡管理系统
{
    public partial class stuform : Form
    {
        public static string account;
        public stuform()
        {
            InitializeComponent();
        }

        private void 消费ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.Show();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stuxgmm f = new stuxgmm();
            f.Show();
        }

        private void 挂失与解挂ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form21 f = new Form21();
            f.Show();
        }

        private void 充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stuxf f = new stuxf();
            f.Show();
        }

        private void 查询ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form22 f = new Form22();
            f.Show();
        }

        private void 查询充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stucxcz f = new stucxcz();
            f.Show();
        }

        private void 修改个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form23 f = new Form23();
            f.Show();
        }

        private void 查询个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form25 f=new Form25();
            f.Show();
          
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
