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
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // stuxgmm.account = textBox1.Text;
            Form30.account = textBox1.Text;
           // stuxf.account = textBox1.Text;
            Form31.account = textBox1.Text;
            Form32.account = textBox1.Text;
            Form33.account = textBox1.Text;
            Form36.account = textBox1.Text;
            Form37.account = textBox1.Text;
            Form38.account = textBox1.Text;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234";
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from teacher", connection);
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
                    Form30 f = new Form30();
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
  

