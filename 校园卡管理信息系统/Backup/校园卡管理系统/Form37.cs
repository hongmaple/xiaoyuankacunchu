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
    public partial class Form37 : Form
    {
        public static string account;
        public Form37()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lastp = textBox1.Text;
            string newp = textBox2.Text;
            string newp2 = textBox3.Text;
            using (SqlConnection conn = new SqlConnection(@"Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from teacher where account='" + account + "'";
                    //查找数据库里是否有该用户名
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (lastp != "")
                            {
                                if (reader[1].ToString().Trim() == lastp)
                                {
                                    if (newp == newp2)
                                    {
                                        cmd.CommandText = "update teacher set password ='" + newp + "'where account ='" + account + "'";
                                        reader.Close();
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("修改密码成功！");
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("您两次输入的密码不同！请重新输入！");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("您输入的当前密码错误！请重新输入！");
                                }
                            }
                            else
                            {
                                MessageBox.Show("请先输入当前密码！");
                            }
                        }
                    }
                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }

