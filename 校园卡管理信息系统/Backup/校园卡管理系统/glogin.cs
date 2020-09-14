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
     
    public partial class glogin : Form
    {
        public glogin()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("账户或密码不能为空！");
                return;
            } 
            if ((textBox1.Text == "admin") && (textBox2.Text == "admin"))
            {
                mangform f = new mangform();
                f.Show();
                
            }
            else
            {
                MessageBox.Show("账户或密码输入错误！");
                return;
            }
            this.Close();
        }

        private void textglyh_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
