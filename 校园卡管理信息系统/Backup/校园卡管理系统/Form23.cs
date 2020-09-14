﻿using System;
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
    public partial class Form23 : Form
    {
        public static string account;
        public Form23()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = textBox2.Text;
            string c = textBox3.Text;
            string d = textBox4.Text;
            string g = textBox5.Text;
            using (SqlConnection conn = new SqlConnection(@"Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234"))
            {
                conn.Open();//连接数据库
                 string str = "update  student  set collge=@b, name =@a,speciality= @c, phone=@d,email =@g  where account =@account";
                 SqlCommand cmd  =  new SqlCommand (str ,conn );
                
                 //   cmd.CommandText = "select * from student where account='" + account + "'";
                    //查找数据库里是否有该用户名

                    SqlParameter a1, b1, c1, d1, g1, acc;
                    a1 = cmd.Parameters.Add("@a",SqlDbType.Char);
                    b1 = cmd.Parameters.Add("@b", SqlDbType.Char);
                    c1 = cmd.Parameters.Add("@c", SqlDbType.Char);
                    d1 = cmd.Parameters.Add("@d", SqlDbType.Char);
                    g1 = cmd.Parameters.Add("@g", SqlDbType.Char);
                    acc = cmd.Parameters.Add("@account",SqlDbType.Char  );
                    a1.Value = a;
                    b1.Value = b; c1.Value = c; d1.Value = d; g1.Value = g; acc.Value = Form23.account;
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                    {
                        MessageBox.Show("请填写全部信息");
                            return;
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("修改信息成功");
                    this.Close();



                }
            }
        }
    }
