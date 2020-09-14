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
    public partial class stuje : Form
    {
        public stuje()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "挂失";
            string lastp = textBox1.Text;
            using (SqlConnection conn = new SqlConnection(@"Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from teacher where account='" + lastp + "'";
                    //查找数据库里是否有该用户名

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            {

                                if (lastp == reader[0].ToString().Trim())
                                {
                                    cmd.CommandText = "update teacher set states ='" + s + "'where account ='" + lastp + "'";
                                    reader.Close();
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("挂失成功！");
                                    this.Close();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             string s = "正常";
            string lastp = textBox1.Text;
            using (SqlConnection conn = new SqlConnection(@"Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from teacher where account='" + lastp + "'";
                    //查找数据库里是否有该用户名

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            {

                                if (lastp == reader[0].ToString().Trim())
                                {
                                    cmd.CommandText = "update teacher set states ='" + s + "'where account ='" + lastp + "'";
                                    reader.Close();
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("解挂成功！");
                                    this.Close();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
        }
        }

