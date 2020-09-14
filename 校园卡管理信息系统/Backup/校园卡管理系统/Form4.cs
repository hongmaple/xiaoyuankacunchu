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
    
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stuform.account = textBox1.Text;
            stuxgmm.account = textBox1.Text;
            Form9.account = textBox1.Text;
            stuxf.account = textBox1.Text;
            Form21.account = textBox1.Text;
            Form23.account = textBox1.Text; 
            Form25.account = textBox1.Text;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234";
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from student", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (textBox1.Text == ""||textBox2.Text =="")
                {
                    MessageBox.Show("账户或密码不能为空！");
                    return;
                }
                if (textBox1.Text == dr[0].ToString().Trim() && textBox2.Text == dr[1].ToString().Trim())
                {
                    stuform f = new stuform();
                    f.Show();
                    break;
                }
                else
                {
                    MessageBox.Show("账户或密码输入错误！");
                    return;
                }
               
            }
               connection.Close();
               this.Close();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}

