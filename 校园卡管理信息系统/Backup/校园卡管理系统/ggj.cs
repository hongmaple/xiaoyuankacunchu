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
    public partial class ggj : Form
    {
        public ggj()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("请输入要挂失或解挂的卡号！");
                return;
            }
            string s = "挂失";
            string lastp = textBox1.Text;
            using (SqlConnection conn = new SqlConnection(@"Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234"))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from student where account='" + lastp + "'";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                if (lastp == reader[0].ToString().Trim())
                                {
                                    cmd.CommandText = "update student set states ='" + s + "'where account ='" + lastp + "'";
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
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("请输入要挂失或解挂的卡号！");
                return;
            } 
            string s = "正常";
            string lastp = textBox1.Text;
            using (SqlConnection conn = new SqlConnection(@"Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234"))
            {
                conn.Open();//连接数据库

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from student where account='" + lastp + "'";
                    //查找数据库里是否有该用户名

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            {

                                if (lastp == reader[0].ToString().Trim())
                                {
                                    cmd.CommandText = "update student set states ='" + s + "'where account ='" + lastp + "'";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
                 
