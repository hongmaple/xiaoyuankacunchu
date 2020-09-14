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
    public partial class mangform : Form
    {
        public mangform()
        {
            InitializeComponent();
        }

        private void 为学生办理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmadd f = new frmadd();
            f.Show();
        }

        private void 为教师办理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Show();
        }

        private void 删除教师卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delteacher f = new delteacher();
            f.Show();
        }

        private void 修改学生密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xiugaixs f = new xiugaixs();
            f.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void 挂失ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 挂失教师卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ggj f = new ggj();
            f.Show();
        }

        private void 删除学生卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delca f = new delca();
            f.Show();
        }

        private void 挂失学生卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stuje f= new stuje();
            f.Show();
        }

        private void 查询消费记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selxf f = new selxf();
            f.Show();
        }

        private void 查询充值记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selcz f = new selcz();
            f.Show();
        }

        private void 修改学生密码ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form20 f = new Form20();
            f.Show();
        }

        private void 查询学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selxsxx f = new selxsxx();
            f.Show();
        }

        private void 删除卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 查询教师信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form40 f = new Form40();
            f.Show();
        }
    }
}
