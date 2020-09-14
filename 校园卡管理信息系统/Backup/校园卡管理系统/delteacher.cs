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
    public partial class delteacher : Form
    {
        public delteacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             using (SqlConnection conn = new SqlConnection(@"Data Source= GATEWAY-PC;Initial Catalog=xiaoyuanka;User ID=sa;Password=niit#1234"))
            {
                conn.Open();//连接数据库
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string userdeleteID = textBox1.Text;
                    if (userdeleteID == "")
                    {
                      MessageBox.Show( "请先输入要删除的用户ID！");
                    }
                    else
                    {
                        cmd.CommandText = "select * from teacher where account='" + userdeleteID + "'";
                        //查找数据库里是否有该用户名
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                
                                string username = reader.GetString(1);
                                reader.Close();
                                  if (MessageBox.Show("确定要删除用户“"+userdeleteID+"”吗?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                 {
                                     if (textBox1.Text == "")
                                     {
                                         MessageBox.Show("请先输入要删除的用户ID！");
                                         return;
                                     }
                                     try
                                     {
                                         cmd.CommandText = "delete  from teacher where account='" + userdeleteID + "'";
                                         cmd.ExecuteNonQuery();
                                         cmd.CommandText = "delete  from consume where account='" + userdeleteID + "'";
                                         cmd.ExecuteNonQuery();
                                         cmd.CommandText = "delete  from recharge where account='" + userdeleteID + "'";
                                         cmd.ExecuteNonQuery();
                                         MessageBox.Show("删除成功！");
                                         return;
                                     }
                                      catch (SqlException ex)
                                     {
                                         Console.WriteLine(ex.Message);
                                     }
   
                                     this.Close();
                                 }
                           }
                               
                        }
                        }
                    }

                    conn.Close();
                }
             }
        }
    }

