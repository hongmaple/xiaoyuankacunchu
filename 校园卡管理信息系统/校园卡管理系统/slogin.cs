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
    public partial class slogin : Form
    {

        public slogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // stuxgmm.account = textBox1.Text;
            studentform.account = textBox1.Text;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source= PC-20140530JSPN;Initial Catalog=xiaoyuanka;User ID=sa;Password=wjn021221";
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from student", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("账户或密码不能为空！");
                    return;
                }
                if (textBox1.Text == dr[0].ToString().Trim() && textBox2.Text == dr[1].ToString().Trim())
                {
                    studentform f = new studentform();
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
    
        private void button2_Click_1(object sender, EventArgs e)
        {
            login f = new login();
            f.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
        }
  

